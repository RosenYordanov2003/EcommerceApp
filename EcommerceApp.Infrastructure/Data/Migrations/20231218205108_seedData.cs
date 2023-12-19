using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShoesStock",
                columns: new[] { "Id", "Quantity", "ShoesId", "Size" },
                values: new object[] { 6, 0, 2, 46.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
