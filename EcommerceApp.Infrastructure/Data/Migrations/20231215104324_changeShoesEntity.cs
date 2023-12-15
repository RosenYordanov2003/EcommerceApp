using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class changeShoesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 110m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 0m);
        }
    }
}
