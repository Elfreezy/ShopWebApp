using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain;
using ShopWebApp.Domain.Repositories.Abstract;
using ShopWebApp.Domain.Repositories.EntityFramework;
using ShopWebApp.Service;

namespace ShopWebApp
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
            // Подключение конфига из appsettings.json
            Configuration.Bind("Project", new Config());

            // Подключение нужного функционала приложения в качестве сервисов
            services.AddTransient<IServiceItemsRepository, EFServeceItemsRepository>();     // Связь интерфейс-реализация
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IShopsRepository, EFShopsRepository>();
            services.AddTransient<IProductsRepository, EFProductsRepository>();
            services.AddTransient<IProductShopRepository, EFProductShopRepository>();
            services.AddTransient<DataManager>();

            // Подключение к БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            // Настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = false;                // Подтверждение email
                opts.Password.RequiredLength = 6;                   // Минимальная длина пароля
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;                 // Использовать числа в пароле
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // Настраиваем authentication cookie
            services.ConfigureApplicationCookie(opts =>
            {
                opts.Cookie.Name = "myCompanyAuth";
                opts.Cookie.HttpOnly = true;
                opts.LoginPath = "/account/login";
                opts.AccessDeniedPath = "/account/accessdenies";
                opts.SlidingExpiration = true;
            });

            // Настраиваем политику авторизацию для AdminArea
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); }); // Требование роли admin
            });

            // Добавляем сервисы представлений и контроллеров (MVC)
            services.AddControllersWithViews(x => 
            { 
                x.Conventions.Add(new AdminAreaAutherization("Admin", "AdminArea")); 
            });

            // Регистрация контроллеров и представлений MVC
            // + Совместимость с asp.net core 3.0
            services.AddControllersWithViews().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0).AddCookieTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Порядок регистрации  в middleware очень важен!!!
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
