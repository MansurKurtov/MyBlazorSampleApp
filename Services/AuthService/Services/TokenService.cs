using AuthService.Helpers;
using AuthService.Interfaces;
using AuthService.Models;
using Entity.Enums;
using Entity.Helpers.Response;
using Entity.Models.EntityModels.Auth;
using Entity.Models.QueryModels.Auth;
using Entity.Repository;
using Entitys.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Services
{
    public class TokenService : ITokenService
    {
        private IRepository<AuthUserRToken> _token;
        private DataContext _context;
        public TokenService(DataContext context,
                            IRepository<AuthUserRToken> token)
        {
            _context = context;
            _token = token;
        }


        public async Task<AuthUserRToken> InsertToken(AuthUserRToken model)
        {
            var userTokens = (await _token.GetListAsync(x => x.UserId == model.UserId)).OrderByDescending(x => x.Id);

            int n = 1;
            foreach (var token in userTokens)
            {
                if (AuthParams.MAX_DEVICE_COUNT <= n++)
                {
                    await _token.DeleteAsync(token);  //oxirgi 3 ta token qoladi qolganlari o`chiriladi
                }
            }
            await _token.InsertAsync(model);
            return model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdateToken(AuthUserRToken model)
        {
            await _token.UpdateAsync(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public async Task<ResponseData> DeleteToken(string token)
        {
            var model = await _token.GetAsync(x => x.RefreshToken == token);
            if (model == null)
            {
                return new ResponseData(ResponseStatus.NoContent);
            }

            try
            {
                await _token.DeleteAsync(model);
            }
            catch (Exception err)
            {
                return err;
            }

            return true;
        }

        public AuthUserRToken FindToken(string refreshtoken)
        {
            var UserToken = _context.Set<AuthUserRToken>();
            return UserToken.Where(x => x.RefreshToken == refreshtoken).Include(x => x.UserModel).FirstOrDefault();
        }

        public async Task<ResponseData> DoPassword(LoginModel model)
        {
            if (model == null)
            {
                return new ResponseData(ResponseStatus.NoContent);
            }
            var Users = _context.Set<AuthUser>();
            var user = Users.FirstOrDefault(x => x.Login.ToLower() == model.Login.ToLower());

            if (user == null)
                return "Не найден пользователь";
            if (user.Status != AdmUserStatus.Active)
                return "Данная учетная запись заблокирована или не активирована";

            //var hash = CryptoHelper.CreateHashSalted("pass@word");
            if (user.Password != CryptoPasword.GetHashSalted(model.Password, user.Salt))
                return "Неправильный пароль";

            var refresh_token = Guid.NewGuid().ToString().Replace("-", "");

            var token = new AuthUserRToken
            {
                ClientId = model.ClientId,
                RefreshToken = refresh_token,
                UserId = user.Id,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            try
            {
                await this.InsertToken(token);
            }
            catch (Exception err)
            {
                return err;
            }
            var userToken = FindToken(refresh_token);
            var data = GetJwt(userToken, refresh_token);

            return new ResponseData(data, ResponseStatus.OK);

        }

        //scenario 2 ： get the access_token by refresh_token
        public async Task<ResponseData> DoRefreshToken(string refreshtoken)
        {
            if (refreshtoken == null)
            {
                return "Invalid Parameters";
            }

            var usertoken = this.FindToken(refreshtoken);

            if (usertoken == null)
            {
                return "Invalid Parameters";
            }

            var min = DateTime.Now.Subtract(usertoken.Updated).TotalMinutes;

            if (min > AuthParams.EXPIRE_MINUTES_REFRESH)
            {
                return "Refresh token has expired";
            }

            var refresh_token = Guid.NewGuid().ToString().Replace("-", "");

            //expire the old refresh_token and add a new refresh_token
            usertoken.RefreshToken = refresh_token;
            usertoken.Updated = DateTime.Now;

            try
            {

                await _token.UpdateAsync(usertoken);
                var data = GetJwt(usertoken, refresh_token);

                return new ResponseData(data, ResponseStatus.OK);
            }
            catch (Exception err)
            {
                return err;
            }
        }

        private TokenModel GetJwt(AuthUserRToken usertoken, string refreshToken)
        {
            var now = DateTime.UtcNow;

            var model = GetUserPermissions(usertoken);
            var permissions = "";
            var uielements = "";

            if (model.uielements != null)
            {
                var uielements_list = model.uielements.Split(",").Distinct().ToList();
                uielements = string.Join(",", uielements_list);
            }
            if (model.permissions != null)
            {
                var permission_list = model.permissions.Split(",").Distinct().ToList();
                permissions = string.Join(",", permission_list);
            }

            int orgId = usertoken.UserModel.OrgId ?? 0;


            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usertoken.ClientId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Name, usertoken.UserModel.Login),
                new Claim("UserName", usertoken.UserModel.Login),
                new Claim("UserId", usertoken.UserId.ToString()),
                new Claim("OrgId", orgId.ToString()),
                new Claim("Permissions", permissions)
            };



            var symmetricKeyAsBase64 = AuthParams.PARAM_SECRET_KEY;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var jwt = new JwtSecurityToken(
                issuer: AuthParams.PARAM_ISS,
                audience: AuthParams.PARAM_AUD,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(AuthParams.EXPIRE_MINUTES)),

                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            int exp_time = (int)TimeSpan.FromMinutes(AuthParams.EXPIRE_MINUTES).TotalSeconds;

            var token = new TokenModel
            {
                access_token = encodedJwt,
                expires_in = exp_time,
                refresh_token = refreshToken,
                uielements = uielements,

            };

            return token;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        private UserPermissionsQueryModel GetUserPermissions(AuthUserRToken UserToken)
        {
            string userPermissions = "";
            string userUIelements = "";
            var result = new UserPermissionsQueryModel();
            try
            {

                var permissions = _context.AuthPermissions;

                if (UserToken.UserModel.Role == AdmRole.Administrator)  // agar biror structurani admini bo`lsa shu strukturaga tegishli barcha modullar biriktiriladi
                {
                    var modules = permissions.ToList();
                    foreach (var item in modules)
                    {
                        userPermissions += item.PermissionCode + ",";
                        if (item.RelatedUielementCodes != null && item.RelatedUielementCodes?.Length > 0)
                            userUIelements += item.RelatedUielementCodes + ",";
                    }
                }

                else
                {
                    string sql = "select distinct  p.permission_code , p.rel_uielement_codes, p.rel_permission_codes  from auth_role_permissions rp " +
                                 " inner join auth_permissions p on rp.permission_id = p.id " +
                                 " inner join auth_user_roles ur on ur.role_id = rp.role_id " +
                                 " where ur.user_id={0}";

                    var list_user_permission = _context.PermissionQuery.FromSqlRaw(sql, UserToken.UserId).ToList();

                    foreach (var item in list_user_permission)
                    {
                        userPermissions += item.permission_code + ",";
                        if (item.related_permission_codes != null && item.related_permission_codes?.Length > 0)
                            userPermissions += item.related_permission_codes + ",";

                        if (item.related_uielement_codes != null && item.related_uielement_codes?.Length > 0)
                            userUIelements += item.related_uielement_codes + ",";
                    }
                }
            }
            catch
            {
                return new UserPermissionsQueryModel();
            }

            result.permissions = userPermissions;
            result.uielements = userUIelements;
            return result;
        }
    }

}
