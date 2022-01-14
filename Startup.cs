using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SolucionCacao.Models;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using FluentValidation.AspNetCore;
using SolucionCacao.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Routing;

namespace SolucionCacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            string connString = ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnectionString");

            services.AddDbContext<db_concursoContext>(options => options.UseSqlServer(connString));
            /* services.AddDbContext<db_concursoContext>(
                 options => options.UseInMemoryDatabase(databaseName: "testDB")
             );*/
            //services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<db_concursoContext>();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<db_concursoContext>();
            
            //services.AddRazorPages();

            /*services.AddIdentityServer(options =>
            {
                options.UserInteraction.LoginUrl = "/Views/Login";
            });*/

            services.AddMvc().AddXmlSerializerFormatters();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddMvc().AddFluentValidation();
            //services.AddTransient<IValidator<Login>, ValidateLogin>();

            services.ConfigureApplicationCookie( options => {options.LoginPath = "/Login/Index";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie.Name = "CookieLogin";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Login/ErrorDisp";
            });

            services.Configure<RouteOptions>( options => {
                options.LowercaseQueryStrings = true;
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;

            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseMvc(routes => {
                routes.MapRoute("default","{controller=Home}/{action=Index}/{id?}");
            });

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });*/
        }
    }
}
