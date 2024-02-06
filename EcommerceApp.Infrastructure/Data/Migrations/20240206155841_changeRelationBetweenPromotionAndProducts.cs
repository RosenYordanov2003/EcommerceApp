using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class changeRelationBetweenPromotionAndProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84fb3096-eef9-4de6-80f7-ef2f1778b07c", "AQAAAAEAACcQAAAAEPmZYSklaH8klhlTdLOAAU6xsKqv5T0sDp75SeRxduMUscaPoE4fC8Dg8vbPVAV7Zg==", "071d92e1-a394-4b7e-805f-1620127f7e50" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a9403f-0304-4e02-b736-80c0e7d8e1ba", "AQAAAAEAACcQAAAAEK09DLDSU+jTAyxRzMGQGCwrFDoA6WGlZMB+kAvaFhDc/rWnRZwfwxQKn3PfJm3qyA==", "a76f0152-b618-40ce-ab2c-b964084d7bbf" });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes",
                column: "PromotionId");
        }
    }
}
