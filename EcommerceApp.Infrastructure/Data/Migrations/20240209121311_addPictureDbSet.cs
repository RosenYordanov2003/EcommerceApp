using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addPictureDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Clothes_ClothId",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Shoes_ShoesId",
                table: "Picture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_ShoesId",
                table: "Pictures",
                newName: "IX_Pictures_ShoesId");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_ClothId",
                table: "Pictures",
                newName: "IX_Pictures_ClothId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ffb3608-9478-4927-b8b5-61a7a4efac07", "AQAAAAEAACcQAAAAEHyBCFa6Oc7CgeyzPI+1C61f0xagrlFef1dAEIMk4nxPawcuxhYankAFrjoTHTq5nQ==", "90cabd18-04b4-4b9d-a1ea-2c0899287782" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Clothes_ClothId",
                table: "Pictures",
                column: "ClothId",
                principalTable: "Clothes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Shoes_ShoesId",
                table: "Pictures",
                column: "ShoesId",
                principalTable: "Shoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Clothes_ClothId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Shoes_ShoesId",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_ShoesId",
                table: "Picture",
                newName: "IX_Picture_ShoesId");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_ClothId",
                table: "Picture",
                newName: "IX_Picture_ClothId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14ef66e2-c371-4515-9a52-8dc8bdf86cda", "AQAAAAEAACcQAAAAEFzTWlfBydNYzIHh/Vtb0T1FGr2zgTg6tXJQMh+1E3l+EH3z4lrLPo7f749jMuGKPg==", "39a9f235-bfc8-4ac7-bc2e-bc7022f002cd" });

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Clothes_ClothId",
                table: "Picture",
                column: "ClothId",
                principalTable: "Clothes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Shoes_ShoesId",
                table: "Picture",
                column: "ShoesId",
                principalTable: "Shoes",
                principalColumn: "Id");
        }
    }
}
