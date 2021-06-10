using Entity.Helpers.Response;
using Entity.Models.EntityModels.Auth;
using Entity.Models.PostModels.Auth;
using System.Threading.Tasks;

namespace MyBlazorSampleApp.Services.Auth
{
    public interface IAdmAuthService
    {
        Task<bool> Add(AuthUserPostModel user);
        Task<bool> Update(AuthUserPostModel userPostModel);
        Task<AuthUserPostModel> GetAccountById(int id);
    }
}