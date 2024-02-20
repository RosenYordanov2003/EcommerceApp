using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addForeignKeyAtributeOnPromotionIdInShoesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Promotions_ShoesId",
                table: "Promotions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "705edde7-c8d5-4080-ac10-b8fdf7f5d1db", "AQAAAAEAACcQAAAAEOCaNKDN+2gn43nPHjs42tX8TpfkiozGNaGDhDKWdMAZDHCn1l7DAkDLF5s+bEdeVA==", "20e12363-90fc-43ee-bf32-91d5aa4615ab" });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ShoesId",
                table: "Promotions",
                column: "ShoesId");

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
                name: "FK_Shoes_Promotions_PromotionId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_ShoesId",
                table: "Promotions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98bac5d1-73b9-4e8d-847a-821950f8521b", "AQAAAAEAACcQAAAAEGzHdreqiYP2ShvvBjhubO1GZd5DBQSpkKzIjJ0WD/qUGjnckcpK9KLwdaVjrmpBRA==", "cff4194a-acf6-4c02-8f20-179aee2cf052" });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ShoesId",
                table: "Promotions",
                column: "ShoesId",
                unique: true,
                filter: "[ShoesId] IS NOT NULL");
        }
    }
}
