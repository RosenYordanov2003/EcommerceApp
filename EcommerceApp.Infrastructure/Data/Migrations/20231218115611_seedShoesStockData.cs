using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class seedShoesStockData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShoesStock",
                columns: new[] { "Id", "Quantity", "ShoesId", "Size" },
                values: new object[,]
                {
                    { 1, 3, 2, 40.0 },
                    { 2, 6, 2, 41.0 },
                    { 3, 7, 2, 43.0 },
                    { 4, 8, 2, 44.0 },
                    { 5, 18, 2, 45.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
