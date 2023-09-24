using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OnlineShop.db;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShop.db.Storages;
using OnlineShopWebApp.Helper;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;
using System;
using System.Globalization;

namespace OnlineShopWebApp
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
            string connection = Configuration.GetConnectionString("OnlineShop");
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection));


            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.ConfigureApplicationCookie(options => 
            { 
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
                options.LoginPath = "/Profile/SingIn";
                options.LogoutPath = "/Profile/LogOut";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            services.AddTransient<IFavoriteStorage, FavoriteStorage>();
            services.AddTransient<ICartStorage, CartStorage>();
            services.AddTransient<IProductsStorage, ProductsStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();

            services.AddSingleton<IFileProvider, FileProvider>();
            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMemoryCache();
            services.AddHostedService<ProductCashe>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCulcures = new[]
                {
                    new CultureInfo("es-US")
                };
                options.DefaultRequestCulture = new RequestCulture("es-US");
                options.SupportedCultures = supportedCulcures;
                options.SupportedUICultures = supportedCulcures;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Add("Content-Control", "public, max-agee=600");
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}") ;
                    
        });
        }
    }
}
