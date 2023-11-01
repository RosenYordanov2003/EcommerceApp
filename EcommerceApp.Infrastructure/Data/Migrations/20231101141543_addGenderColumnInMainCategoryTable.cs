using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addGenderColumnInMainCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "MainCategory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "Women Men");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: "Women Men");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: "Women Men");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: "Women Men");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "Gender",
                value: "Women Men");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "Gender",
                value: "Women");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "Gender",
                value: "Women Men");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "Gender",
                value: "Women Men");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "Gender",
                value: "Women Men");

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "Gender",
                value: "Women Men");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "MainCategory");
        }
    }
}
