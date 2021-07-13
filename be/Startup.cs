using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Area.DALS;
using api.Models.Area.Interfaces;
using api.Models.Branch.DALS;
using api.Models.Branch.Interfaces;
using api.Models.BranchType.DALS;
using api.Models.BranchType.Interfaces;
using api.Models.Divisi.DALS;
using api.Models.Divisi.Interfaces;
using api.Models.Profile.DALS;
using api.Models.Profile.Interfaces;
using api.Models.Status.DALS;
using api.Models.Status.Interfaces;
using api.Models.Team.DALS;
using api.Models.Team.Interfaces;
using CargoV3API.Models.Users.DALS;
using CargoV3API.Models.Users.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.JsonResult;

namespace CargoV3API
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
            services.AddControllers();
                

            //services.AddCors();

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            //services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(x => x.ValueCountLimit = 10000);

            // Add framework services.
            /// Publish Harus On
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new ErrorHandlingFilter());
            //});

            
            //services.AddHttpContextAccessor();
            //services.AddSession(options =>
            //{
            //    // Set a short timeout for easy testing.
            //    options.IdleTimeout = TimeSpan.FromHours(3);
            //    options.Cookie.HttpOnly = true;
            //    // Make the session cookie essential
            //    options.Cookie.IsEssential = true;
            //});
            services
                   .AddTransient<IUser, UserDAL>()
                   .AddTransient<IBranch, BranchDAL>()
                  .AddTransient<IBranchType, BranchTypeDAL>()
                  .AddTransient<IProfile, ProfileDAL>()
                  .AddTransient<IDivisi, DivisiDAL>()
                  .AddTransient<IStatus, StatusDAL>()
                  .AddTransient<IArea, AreaDAL>()
                  .AddTransient<ITeam, TeamDAL>()
                  ;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
