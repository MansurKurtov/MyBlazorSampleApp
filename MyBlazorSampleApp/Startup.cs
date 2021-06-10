using MyBlazorSampleApp.ForLearning.Helpers;
using MyBlazorSampleApp.Helpers;
using MyBlazorSampleApp.Services;
using MyBlazorSampleApp.Services.Abstraction;
using MyBlazorSampleApp.Services.Auth;
using Entity.Repository;
using Entitys.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyBlazorSampleApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddCors(option =>
            {
                option.AddPolicy("allowedOrigin",
                     builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                        );
            });
            services.AddDbContextFactory<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DataContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddControllers();
            services.AddSingleton<IJsonStringLocalizer, JsonStringLocalizer>();

            services.AddHttpClient();
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAlertService, AlertService>();
            services.AddScoped<IAdmAuthService, AdmAuthService>();
            services.AddScoped<Person>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
