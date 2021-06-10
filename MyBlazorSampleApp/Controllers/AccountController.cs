using AuthService.Models;
using Entity.Helpers.Response;
using Entity.Models.EntityModels.Auth;
using Entity.Repository;
using Entitys.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlazorSampleApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private IRepository<AuthPermission> _permission;
        private readonly IDbContextFactory<DataContext> _context;

        public AccountController(IRepository<AuthPermission> repository,
                                 IDbContextFactory<DataContext> context)
        {
            _permission = repository;
            _context = context;
        }

        [HttpPost]
        public async Task<ResponseData> Login([FromBody] LoginModel model)
        {
            if (model == null)
            {
                return new ResponseData(ResponseStatus.BadRequest);
            }

            var user = _context.CreateDbContext().AuthUsers.Where(w => w.Login.Equals(model.Login) && w.Password.Equals(model.Password)).FirstOrDefault();
            if (user == null)
            {
                return this.GetResponse("Неверный логин !", ResponseStatus.BadRequest);
                //Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //return new ResponseData("Неверный логин !", ResponseStatus.BadRequest);
            }
            return new ResponseData() { Result = user };
        }
    }
}
