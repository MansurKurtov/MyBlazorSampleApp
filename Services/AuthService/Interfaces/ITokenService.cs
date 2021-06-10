using AuthService.Models;
using Entity.Helpers.Response;
using Entity.Models.EntityModels.Auth;
using System.Threading.Tasks;

namespace AuthService.Interfaces
{
    public interface ITokenService
    {
        AuthUserRToken FindToken(string refreshtoken);
        Task<AuthUserRToken> InsertToken(AuthUserRToken model);
        Task UpdateToken(AuthUserRToken model);
        Task<ResponseData> DeleteToken(string refresh);
        Task<ResponseData> DoPassword(LoginModel model);
        Task<ResponseData> DoRefreshToken(string refreshtoken);


    }
}
