using INTEX2.Data;
using INTEX2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2
{
    public class Startup
    {
        private string _IntexDbConnection = null;
        private string _ApplicationDbConnection = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _IntexDbConnection = Configuration["IntexDbConnection"];
            _ApplicationDbConnection = Configuration["ApplicationDbConnection"];
            services.AddDbContext<IntexDbContext>(options =>
            {
                options.UseMySql(_IntexDbConnection);
            });

            //Uncomment this in just a moment

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(_ApplicationDbConnection);
            });

            //services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton<InferenceSession>(
            new InferenceSession("Models/best_clf_model.onnx")
            );

            services.AddScoped<ICrashesRepository, EFCrashesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "countypage",
                    pattern: "{COUNTY_NAME}/Page{pageNum}",
                    defaults: new { Controller = "Home", action = "DataSummary" });

                //endpoints.MapControllerRoute(
                //    name: "severitypage",
                //    pattern: "Page{pageNum}/Severity{CRASH_SEVERITY_ID}",
                //    defaults: new { Controller = "Home", action = "DataSummary", COUNTY_NAME = ""});

                //endpoints.MapControllerRoute(
                //    name: "severitypage2",
                //    pattern: "{CRASH_SEVERITY_ID}/Page{pageNum}",
                //    defaults: new { Controller = "Home", action = "DataSummary" });

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "DataSummary", pageNum = 1});

                endpoints.MapControllerRoute(
                    name: "county",
                    pattern: "County{COUNTY_NAME}",
                    defaults: new { Controller = "Home", action = "DataSummary", pageNum = 1 });

                //endpoints.MapControllerRoute(
                //    name: "severity",
                //    pattern: "Severity{CRASH_SEVERITY_ID}",
                //    defaults: new { Controller = "Home", action = "DataSummary", pageNum = 1 });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
