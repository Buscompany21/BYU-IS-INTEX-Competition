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
        //private string _IntexDbConnection = null;
        //private string _ApplicationDbConnection = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //_IntexDbConnection = Configuration["IntexDbConnection"];
            //_ApplicationDbConnection = Configuration["ApplicationDbConnection"];
            
            services.AddDbContext<IntexDbContext>(options =>
            {
                options.UseMySql(DbSecret.GetRDSConnectionString());
            });

            //Uncomment this in just a moment

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(DbSecret.GetRDSConnectionString());
            });

            //services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton<InferenceSession>(
            new InferenceSession("wwwroot/best_clf_model.onnx")
            );

            services.AddScoped<ICrashesRepository, EFCrashesRepository>();
            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IntexDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 1;
            });
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
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                context.Response.Headers.Add("Expect-CT", "max-age=0");
                context.Response.Headers.Add("Feature-Policy",
                "vibrate 'self' ; " +
                "camera 'self' ; " +
                "microphone 'self' ; " +
                "speaker 'self'  ;" +
                "geolocation 'self' ; " +
                "gyroscope 'self' ; " +
                "magnetometer 'self' ; " +
                "midi 'self' ; " +
                "sync-xhr 'self' ; " +
                "push 'self' ; " +
                "notifications 'self' ; " +
                "fullscreen '*' ; " +
                "payment 'self' ; ");

                context.Response.Headers.Add(
                "Content-Security-Policy",
                "default-src 'self' 'unsafe-inline' https://app.termly.io/ https://www.youtube.com/; " +
                "script-src-elem 'self' 'unsafe-inline'   https://app.termly.io/ https://app.termly.io/embed.min.js https://cdn.metroui.org.ua/v4.3.2/js/metro.min.js https://app.termly.io/299.embed.min.js https://app.termly.io/531.embed.min.js https://zerofatalities.com/wp-content/uploads/2020/11/zero-logo@2x-8.png https://pbs.twimg.com/profile_images/568447784525647872/kQ_uH5TR_400x400.jpeg " +
                "style-src-elem 'self' 'unsafe-inline'; " +
                "img-src 'self' https://zerofatalities.com/wp-content/uploads/2020/11/zero-logo@2x-8.png https://pbs.twimg.com/media/EhC9XQOWoAAP5KM.jpg; " +
                "font-src 'self'" +
                "media-src 'self'" +
                "frame-src 'self' https://www.youtube.com/;" +
                "connect-src  https://app.termly.io/api/v1/snippets/websites/bd768242-0caf-4596-be95-3d56795fa394 https://app.termly.io/"

                );
                await next();
            });
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

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Here you could create a super user who will maintain the web app
            var poweruser = new ApplicationUser
            {

                UserName = Configuration["AppSettings:UserName"],
                Email = Configuration["AppSettings:UserEmail"],
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = Configuration["AppSettings:UserPassword"];
            var _user = await UserManager.FindByEmailAsync(Configuration["AppSettings:AdminUserEmail"]);

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }
    }
}
