using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain.Entities;

namespace ShopWebApp.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Shop> Shops { set; get; }
        public DbSet<ServiceItem> ServiceItems { set; get; }
        public DbSet<ProductShop> ProductShop { set; get; }

        public IQueryable<ServiceItem> ServiceItem { get; internal set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Создание новой роли
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "ca761232-ed42-11ce-bacd-00aa0057b223",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            // Создание нового пользователя
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "ca761232-ed42-11ce-bacd-00aa0057b223",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "",
                NormalizedEmail = "",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "supperpassword"),
                SecurityStamp = string.Empty
            });

            // Связь пользователь-роль
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ca761232-ed42-11ce-bacd-00aa0057b223",
                UserId = "ca761232-ed42-11ce-bacd-00aa0057b223"
            });

            builder.Entity<ProductShop>().HasKey(table => new {
                table.ProductsId,
                table.ShopsId
            });

            // Создание текстового поля
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("3C345AF4-2678-4A3A-A170-4433E0CAA87C"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            // Создание текстового поля
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("5A315AF2-D467-4B53-AD25-043EFE4CBDD7"),
                CodeWord = "PageServices",
                Title = "Услуги"
            });

            // Создание текстового поля
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("419B11CA-1CFE-4789-B86A-BE0C4F19F98C"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });

            // Создание продукта
            builder.Entity<Product>().HasData(new Product
            {
                Id = new Guid("F2875BA3-2E10-4969-B262-B2FBC5014F09"),
                Title = "SSD накопитель"
            });

            // Создание магазина
            builder.Entity<Shop>().HasData(new Shop
            {
                Id = new Guid("B9964B01-1D81-47B9-B2AB-10B23AF399C0"),
                Title = "DNS"
            });
        }
    }
}
