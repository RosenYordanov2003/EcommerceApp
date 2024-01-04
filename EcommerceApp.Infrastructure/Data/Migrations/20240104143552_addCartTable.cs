using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addCartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "Shoes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "Clothes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_CartId",
                table: "Shoes",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_CartId",
                table: "Clothes",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_CartId",
                table: "AspNetUsers",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Carts_CartId",
                table: "Clothes",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Carts_CartId",
                table: "Shoes",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Carts_CartId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Carts_CartId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_CartId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_CartId",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "AspNetUsers");
        }
    }
}
