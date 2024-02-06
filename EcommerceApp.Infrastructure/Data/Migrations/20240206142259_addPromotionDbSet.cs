using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addPromotionDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Promotion_PromotionId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Promotion_PromotionId",
                table: "Shoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotion",
                table: "Promotion");

            migrationBuilder.RenameTable(
                name: "Promotion",
                newName: "Promotions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a9403f-0304-4e02-b736-80c0e7d8e1ba", "AQAAAAEAACcQAAAAEK09DLDSU+jTAyxRzMGQGCwrFDoA6WGlZMB+kAvaFhDc/rWnRZwfwxQKn3PfJm3qyA==", "a76f0152-b618-40ce-ab2c-b964084d7bbf" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Promotions_PromotionId",
                table: "Clothes",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Promotions_PromotionId",
                table: "Shoes",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Promotions_PromotionId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Promotions_PromotionId",
                table: "Shoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions");

            migrationBuilder.RenameTable(
                name: "Promotions",
                newName: "Promotion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotion",
                table: "Promotion",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da1d5d17-9c86-4768-a116-2f99a0dce29d", "AQAAAAEAACcQAAAAEKUDkaxX32GCQQItf65aXIr6o/2hYYa2xajeF/doNpitz6WywoecIwVARruzUk3YmQ==", "198bb212-01ac-46c6-9f3d-50604644fb21" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Promotion_PromotionId",
                table: "Clothes",
                column: "PromotionId",
                principalTable: "Promotion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Promotion_PromotionId",
                table: "Shoes",
                column: "PromotionId",
                principalTable: "Promotion",
                principalColumn: "Id");
        }
    }
}
