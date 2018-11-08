using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Cardstone.Data.Models;
using Cardstone.Services;
using Cardstone.Services.Contracts.General;
using Cardstone.Services.Contracts;
using Cardstone.Database.Data;
using Cardstone.Data.Data;

namespace Cardstone.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;
            this.Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.RegisterServices(services);
            this.RegisterAuthentication(services);
            this.RegisterData(services);
            this.RegisterInfrastructure(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IApplicationDbContext, CardstoneContext>();

            services.AddTransient<ICardService, CardService>();
            services.AddTransient<ICombatService, CombatService>();
            services.AddTransient<IPlayersCardsService, PlayersCardsService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IPurchaseService, PurchaseService>();
        }

        private void RegisterAuthentication(IServiceCollection services)
        {
            services.AddIdentity<Player, IdentityRole>()
               .AddEntityFrameworkStores<CardstoneContext>()
               .AddDefaultTokenProviders();

            if (this.Environment.IsDevelopment())
            {
                services.Configure<IdentityOptions>(options =>
                {
                    // Password settings
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(1);
                    options.Lockout.MaxFailedAccessAttempts = 999;
                });
            }
        }

        private void RegisterData(IServiceCollection services)
        {
            services.AddDbContext<CardstoneContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        private void RegisterInfrastructure(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

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
