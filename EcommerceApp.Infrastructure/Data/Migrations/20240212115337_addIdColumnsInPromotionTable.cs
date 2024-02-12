using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addIdColumnsInPromotionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Promotions_PromotionId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Promotions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoesId",
                table: "Promotions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72073c18-c55d-4c1e-9e25-59240aaf8b77", "AQAAAAEAACcQAAAAEJdLpadGcUpCk2xBkW+KvCMTWKoDnZaKUGEHPU8v1kUZjVjzX9OvzcARSfKlO6IHDg==", "88988052-45a7-4a4f-8c66-0d16540526d2" });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ProductId",
                table: "Promotions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ShoesId",
                table: "Promotions",
                column: "ShoesId",
                unique: true,
                filter: "[ShoesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Clothes_ProductId",
                table: "Promotions",
                column: "ProductId",
                principalTable: "Clothes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Shoes_ShoesId",
                table: "Promotions",
                column: "ShoesId",
                principalTable: "Shoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Clothes_ProductId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Shoes_ShoesId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_ProductId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_ShoesId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ShoesId",
                table: "Promotions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ffb3608-9478-4927-b8b5-61a7a4efac07", "AQAAAAEAACcQAAAAEHyBCFa6Oc7CgeyzPI+1C61f0xagrlFef1dAEIMk4nxPawcuxhYankAFrjoTHTq5nQ==", "90cabd18-04b4-4b9d-a1ea-2c0899287782" });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes",
                column: "PromotionId",
                unique: true,
                filter: "[PromotionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes",
                column: "PromotionId",
                unique: true,
                filter: "[PromotionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Promotions_PromotionId",
                table: "Shoes",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");
        }
    }
}
