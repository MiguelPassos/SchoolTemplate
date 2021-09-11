using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SchoolBusiness.Interfaces;
using SchoolBusiness.Services;
using SchoolRepository.Configuration;
using SchoolRepository.Inte3rfaces;
using SchoolRepository.Services;

namespace SchoolTemplate
{
    public class Startup
    {
        private IOptions<SchoolConfigOptions> schoolOptions;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            schoolOptions = ConfigureSchoolOptions(services);

            //adicionando o serviço de cookies na aplicação
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            
            //Inicio da Injeção de Dependência
            services.AddTransient<IHomeBusiness, HomeBusiness>();
            services.AddTransient<IHomeRepository, HomeRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "api", template: "api/{controller}");
            });
        }

        private IOptions<SchoolConfigOptions> ConfigureSchoolOptions(IServiceCollection services)
        {
            services.Configure<SchoolConfigOptions>(Configuration.GetSection("ConnectionStrings"));
            var schoolOptions = GetIOptionsService(services);

            return schoolOptions;
        }

        private IOptions<SchoolConfigOptions> GetIOptionsService(IServiceCollection services)
        {
            return services.BuildServiceProvider().GetService<IOptions<SchoolConfigOptions>>();
        }
    }
}
