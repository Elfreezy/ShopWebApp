using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebApp.Migrations
{
    public partial class fckit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Products_ProductsId",
                table: "ProductShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Shops_ShopsId",
                table: "ProductShop");

            migrationBuilder.DropIndex(
                name: "IX_ProductShop_ShopsId",
                table: "ProductShop");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductShop",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "ProductShop",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca761232-ed42-11ce-bacd-00aa0057b223",
                column: "ConcurrencyStamp",
                value: "35c378ee-13fd-4e36-b84c-a5939356baad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca761232-ed42-11ce-bacd-00aa0057b223",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d40808d-d624-4c3a-98e7-de188ddce3f6", "AQAAAAEAACcQAAAAEEclgT2euM4fqOg7z0NuAL51IOmlKLnyMlBBW1nXNwCGk3O6qG8C1mn7ClQyMwDkAQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2875ba3-2e10-4969-b262-b2fbc5014f09"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 11, 51, 56, 104, DateTimeKind.Utc).AddTicks(3154));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("b9964b01-1d81-47b9-b2ab-10b23af399c0"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 11, 51, 56, 104, DateTimeKind.Utc).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("3c345af4-2678-4a3a-a170-4433e0caa87c"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 11, 51, 56, 103, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("419b11ca-1cfe-4789-b86a-be0c4f19f98c"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 11, 51, 56, 104, DateTimeKind.Utc).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("5a315af2-d467-4b53-ad25-043efe4cbdd7"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 11, 51, 56, 104, DateTimeKind.Utc).AddTicks(1101));

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ProductId",
                table: "ProductShop",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ShopId",
                table: "ProductShop",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Products_ProductId",
                table: "ProductShop",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Shops_ShopId",
                table: "ProductShop",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Products_ProductId",
                table: "ProductShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Shops_ShopId",
                table: "ProductShop");

            migrationBuilder.DropIndex(
                name: "IX_ProductShop_ProductId",
                table: "ProductShop");

            migrationBuilder.DropIndex(
                name: "IX_ProductShop_ShopId",
                table: "ProductShop");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductShop");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "ProductShop");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca761232-ed42-11ce-bacd-00aa0057b223",
                column: "ConcurrencyStamp",
                value: "60920439-ddad-481c-9199-0aa074ea6572");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca761232-ed42-11ce-bacd-00aa0057b223",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "192b89d0-0a01-4c2b-a9a1-d63a667461fb", "AQAAAAEAACcQAAAAEAbrk4jjUlBdSQ02RbnRD9EdBChP9th59g8u4VHWFj1w9U3w5yLJH9Jp62rSMGSxVw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2875ba3-2e10-4969-b262-b2fbc5014f09"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 1, 26, 4, 121, DateTimeKind.Utc).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("b9964b01-1d81-47b9-b2ab-10b23af399c0"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 1, 26, 4, 121, DateTimeKind.Utc).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("3c345af4-2678-4a3a-a170-4433e0caa87c"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 1, 26, 4, 120, DateTimeKind.Utc).AddTicks(9113));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("419b11ca-1cfe-4789-b86a-be0c4f19f98c"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 1, 26, 4, 121, DateTimeKind.Utc).AddTicks(651));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("5a315af2-d467-4b53-ad25-043efe4cbdd7"),
                column: "DateAdd",
                value: new DateTime(2021, 12, 26, 1, 26, 4, 121, DateTimeKind.Utc).AddTicks(618));

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ShopsId",
                table: "ProductShop",
                column: "ShopsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Products_ProductsId",
                table: "ProductShop",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Shops_ShopsId",
                table: "ProductShop",
                column: "ShopsId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
