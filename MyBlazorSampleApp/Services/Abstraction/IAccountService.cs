using AuthService.Models;
using Entity.Helpers.Response;
using Entity.Models.EntityModels.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlazorSampleApp.Services.Abstraction
{
    public interface IAccountService
    {
        AuthUser User { get; set; }

        Task Delete(int id);
        Task<IList<AuthUser>> GetAll();
        Task<AuthUser> GetById(string id);
        Task Initialize();
        Task<ResponseData> Login(LoginModel model);
        Task Logout();
    }
}