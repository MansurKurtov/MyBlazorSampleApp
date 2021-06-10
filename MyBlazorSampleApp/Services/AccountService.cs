using MyBlazorSampleApp.Services.Abstraction;
using AuthService.Models;
using Entity.Helpers.Response;
using Entity.Models.EntityModels.Auth;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlazorSampleApp.Services
{
    public class AccountService : IAccountService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public AuthUser User { get; set; }

        public AccountService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<AuthUser>(_userKey);
        }

        public async Task<ResponseData> Login(LoginModel model)
        {
            var response = await _httpService.Post<ResponseData>(_navigationManager.BaseUri + "api/account/login", model);
            if (response == null)
                return default;

            User = JsonConvert.DeserializeObject<AuthUser>(response.Result.ToString());
            await _localStorageService.SetItem(_userKey, User);
            return response;
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("account/login");
        }

        //public async Task Register(AddUser model)
        //{
        //    await _httpService.Post("/users/register", model);
        //}

        public async Task<IList<AuthUser>> GetAll()
        {
            return await _httpService.Get<IList<AuthUser>>("/users");
        }

        public async Task<AuthUser> GetById(string id)
        {
            return await _httpService.Get<AuthUser>($"/users/{id}");
        }

        //public async Task Update(string id, EditUser model)
        //{
        //    await _httpService.Put($"/users/{id}", model);

        //    // update stored user if the logged in user updated their own record
        //    if (id == User.Id)
        //    {
        //        // update local storage
        //        User.FirstName = model.FirstName;
        //        User.LastName = model.LastName;
        //        User.Username = model.Username;
        //        await _localStorageService.SetItem(_userKey, User);
        //    }
        //}

        public async Task Delete(int id)
        {
            await _httpService.Delete($"/users/{id}");

            // auto logout if the logged in user deleted their own record
            if (id == User.Id)
                await Logout();
        }
    }
}