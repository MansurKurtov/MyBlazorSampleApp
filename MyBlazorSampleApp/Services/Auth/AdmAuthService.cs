using Entity.Enums;
using Entity.Helpers.Response;
using Entity.Models.EntityModels.Auth;
using Entity.Models.PostModels.Auth;
using Entity.Repository;
using System;
using System.Threading.Tasks;

namespace MyBlazorSampleApp.Services.Auth
{
    public class AdmAuthService : IAdmAuthService
    {
        private readonly ILocalStorageService _localStorageService;
        private IRepository<AuthUser> _repository;

        public AdmAuthService(ILocalStorageService storageService, IRepository<AuthUser> repository)
        {
            _localStorageService = storageService;
            _repository = repository;
        }
        public async Task<bool> Add(AuthUserPostModel userPostModel)
        {
            try
            {
                var user = new AuthUser();
                user.Login = userPostModel.Login;
                user.FullName = userPostModel.FullName;
                user.OrgId = userPostModel.OrgId;
                user.Description = userPostModel.Description;
                user.Password = userPostModel.Password;
                user.CreateDate = DateTime.Now;
                user.Status = AdmUserStatus.Active;
                user.Role = AdmRole.SimpleUser;

                await _repository.InsertAsync(user);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(AuthUserPostModel userPostModel)
        {
            try
            {
                var user = await _repository.GetByIdAsync(userPostModel.Id);
                if (user == null)
                    return false;

                user.Login = userPostModel.Login;
                user.FullName = userPostModel.FullName;
                user.OrgId = userPostModel.OrgId;
                user.Description = userPostModel.Description;
                user.Password = userPostModel.Password;                
                await _repository.UpdateAsync(user);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<AuthUserPostModel> GetAccountById(int id)
        {
            try
            {
                var authUser = await _repository.GetByIdAsync(id);

                var result = new AuthUserPostModel();
                result.Id = authUser.Id;
                result.Login = authUser.Login;
                result.FullName = authUser.FullName;
                result.Description = authUser.Description;
                result.OrgId = authUser.OrgId;
                result.Password = authUser.Password;
                result.ConfirmPassword = authUser.Password;

                return result;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
