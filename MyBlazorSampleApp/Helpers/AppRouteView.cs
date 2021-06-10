using MyBlazorSampleApp.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Net;

namespace MyBlazorSampleApp.Helpers
{
    public class AppRouteView : RouteView
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAccountService AccountService { get; set; }

        protected override void Render(RenderTreeBuilder builder)
        {
            var attribute = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute));
            var authorize = attribute != null;

            if (authorize && AccountService.User == null)
            {
                var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
                if (string.IsNullOrWhiteSpace(returnUrl))
                    NavigationManager.NavigateTo($"/login");
                else 
                NavigationManager.NavigateTo($"/login?returnUrl={returnUrl}");
            }
            else
            {
                base.Render(builder);
            }
        }
    }
}
