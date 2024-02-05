using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addPromotionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PromotionId",
                table: "Shoes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PromotionId",
                table: "Clothes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PercantageDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "117664a5-fa4d-4c55-bde9-c599c856707a", "AQAAAAEAACcQAAAAEGKHMvZ14apcXOSd5KT0XAZu6QCOdbRG/eWzly8cgvm7LL/jgwxeWE23kccImIS45g==", "4631075c-987d-43ca-b591-8c152faa8e4e" });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes",
                column: "PromotionId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Promotion_PromotionId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Promotion_PromotionId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_PromotionId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_PromotionId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Clothes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "862c1e76-ccef-4e70-81c9-588d45b031c0", "AQAAAAEAACcQAAAAEEPWe0sefz/Thg5u1aSbade38tzmRm4Qte/d66iVMAp7GnvxW4lOZKZheYprMcfxjg==", "7a8e5e46-e393-4c0a-b8bf-9c2a584c272c" });
        }
    }
}
