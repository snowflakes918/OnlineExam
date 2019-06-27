using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.DAL.Contexts;
using Exam.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.WebUI
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ExamCS")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );
           services.AddScoped(typeof(ISqlRepository<>), typeof(SqlRepository<>));
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Index/";
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
