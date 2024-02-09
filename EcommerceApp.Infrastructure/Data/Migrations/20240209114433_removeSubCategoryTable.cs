using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class removeSubCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_SubCategory_SubCategoryId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_SubCategory_SubCategoryId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_SubCategoryId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_SubCategoryId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Clothes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14ef66e2-c371-4515-9a52-8dc8bdf86cda", "AQAAAAEAACcQAAAAEFzTWlfBydNYzIHh/Vtb0T1FGr2zgTg6tXJQMh+1E3l+EH3z4lrLPo7f749jMuGKPg==", "39a9f235-bfc8-4ac7-bc2e-bc7022f002cd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Categories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84fb3096-eef9-4de6-80f7-ef2f1778b07c", "AQAAAAEAACcQAAAAEPmZYSklaH8klhlTdLOAAU6xsKqv5T0sDp75SeRxduMUscaPoE4fC8Dg8vbPVAV7Zg==", "071d92e1-a394-4b7e-805f-1620127f7e50" });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "MainCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 9, "Sports Shoes" },
                    { 2, 9, "Sandals" },
                    { 3, 9, "Trainers" },
                    { 4, 9, "Football Boats" },
                    { 5, 8, "Football Shirts" },
                    { 6, 8, "Long sleeve shirts" },
                    { 7, 8, "Short sleeve shirts" },
                    { 8, 8, "Dress Shirts" },
                    { 9, 7, "Swimming Shorts" },
                    { 10, 7, "Football Shorts" },
                    { 11, 7, "Cargo Shorts" },
                    { 12, 7, "Bermuda Shorts" },
                    { 13, 6, "Line Skirts" },
                    { 14, 6, "Tube Skirts" },
                    { 15, 6, "Cicle Skirts" },
                    { 16, 4, "Wrap Coats" },
                    { 17, 4, "Trench Coats" },
                    { 18, 4, "Fur Coats" },
                    { 19, 3, "Bomber Jackets" },
                    { 20, 3, "Denim Jackets" },
                    { 21, 3, "Biker Jackets" },
                    { 22, 2, "Straight leg jeans" },
                    { 23, 2, "Tapered jeans" },
                    { 24, 1, "Polo T-Shirts" },
                    { 25, 1, "Singlet T-shirts" },
                    { 26, 1, "Pocket T-shirts" },
                    { 27, 10, "Hooded Sweatshirts" },
                    { 28, 10, "Sweatshirts without a hood" }
                });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubCategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubCategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubCategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubCategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubCategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubCategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 7,
                column: "SubCategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 8,
                column: "SubCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 9,
                column: "SubCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 10,
                column: "SubCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 11,
                column: "SubCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 12,
                column: "SubCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 7,
                column: "SubCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 8,
                column: "SubCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "SubCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 10,
                column: "SubCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 11,
                column: "SubCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 12,
                column: "SubCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 13,
                column: "SubCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 14,
                column: "SubCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 15,
                column: "SubCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 16,
                column: "SubCategoryId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_SubCategoryId",
                table: "Shoes",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_SubCategoryId",
                table: "Clothes",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_MainCategoryId",
                table: "SubCategory",
                column: "MainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_SubCategory_SubCategoryId",
                table: "Clothes",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_SubCategory_SubCategoryId",
                table: "Shoes",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id");
        }
    }
}
