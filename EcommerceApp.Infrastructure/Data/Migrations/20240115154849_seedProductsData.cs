using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class seedProductsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductStocks",
                columns: new[] { "Id", "ProductId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, 1, 19, "S" },
                    { 2, 1, 15, "M" },
                    { 3, 1, 8, "L" },
                    { 4, 1, 9, "XL" },
                    { 5, 1, 10, "XXL" },
                    { 6, 2, 2, "S" },
                    { 7, 2, 16, "M" },
                    { 8, 2, 13, "L" },
                    { 9, 2, 7, "XL" },
                    { 10, 2, 0, "XXL" },
                    { 11, 3, 15, "S" },
                    { 12, 3, 18, "M" },
                    { 13, 3, 20, "L" },
                    { 14, 3, 19, "XL" },
                    { 15, 3, 9, "XXL" },
                    { 16, 4, 14, "S" },
                    { 17, 4, 17, "M" },
                    { 18, 4, 8, "L" },
                    { 19, 4, 3, "XL" },
                    { 20, 4, 5, "XXL" },
                    { 21, 5, 12, "S" },
                    { 22, 5, 19, "M" },
                    { 23, 5, 13, "L" },
                    { 24, 5, 14, "XL" },
                    { 25, 5, 3, "XXL" },
                    { 26, 6, 2, "S" },
                    { 27, 6, 11, "M" },
                    { 28, 6, 5, "L" },
                    { 29, 6, 17, "XL" },
                    { 30, 6, 16, "XXL" },
                    { 31, 7, 15, "S" },
                    { 32, 7, 17, "M" },
                    { 33, 7, 13, "L" },
                    { 34, 7, 13, "XL" },
                    { 35, 7, 14, "XXL" },
                    { 36, 8, 14, "S" },
                    { 37, 8, 7, "M" },
                    { 38, 8, 1, "L" },
                    { 39, 8, 8, "XL" },
                    { 40, 8, 14, "XXL" },
                    { 41, 9, 4, "S" },
                    { 42, 9, 3, "M" }
                });

            migrationBuilder.InsertData(
                table: "ProductStocks",
                columns: new[] { "Id", "ProductId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 43, 9, 0, "L" },
                    { 44, 9, 18, "XL" },
                    { 45, 9, 3, "XXL" },
                    { 46, 10, 9, "S" },
                    { 47, 10, 11, "M" },
                    { 48, 10, 14, "L" },
                    { 49, 10, 3, "XL" },
                    { 50, 10, 18, "XXL" },
                    { 51, 11, 10, "S" },
                    { 52, 11, 0, "M" },
                    { 53, 11, 4, "L" },
                    { 54, 11, 8, "XL" },
                    { 55, 11, 18, "XXL" },
                    { 56, 12, 10, "S" },
                    { 57, 12, 16, "M" },
                    { 58, 12, 16, "L" },
                    { 59, 12, 5, "XL" },
                    { 60, 12, 2, "XXL" }
                });

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 16,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 17,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 22,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 23,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 26,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 27,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 28,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 29,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 30,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 31,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 32,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 33,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 34,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 35,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 36,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 37,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 38,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 39,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 41,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 42,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 43,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 44,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 46,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 47,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 48,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 49,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 50,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 51,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 52,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 53,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 54,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 55,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 56,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 57,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 58,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 59,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 60,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 61,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 62,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 63,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 64,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 65,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 66,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 67,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 68,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 69,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 70,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 71,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 72,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 73,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 74,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 75,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 76,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 77,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 78,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 79,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 80,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 81,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 82,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 83,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 84,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 85,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 86,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 87,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 88,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 89,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 90,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 91,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 92,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 93,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 94,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 95,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 96,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 97,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 98,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 99,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 100,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 102,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 103,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 104,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 105,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 106,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 107,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 108,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 109,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 110,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 111,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 112,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 113,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 114,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 115,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 116,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 118,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 120,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 121,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 122,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 124,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 125,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 126,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 127,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 128,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 129,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 130,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 131,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 132,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 133,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 134,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 135,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 136,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 137,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 138,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 139,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 140,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 141,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 142,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 143,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 144,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 145,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 146,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 147,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 148,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 149,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 150,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 151,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 152,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 153,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 154,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 155,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 156,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 157,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 158,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 159,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 160,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 161,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 162,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 163,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 164,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 165,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 166,
                column: "Quantity",
                value: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 16,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 17,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 22,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 23,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 26,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 27,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 28,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 29,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 30,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 31,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 32,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 33,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 34,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 35,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 36,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 37,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 38,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 39,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 41,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 42,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 43,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 44,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 46,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 47,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 48,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 49,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 50,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 51,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 52,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 53,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 54,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 55,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 56,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 57,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 58,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 59,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 60,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 61,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 62,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 63,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 64,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 65,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 66,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 67,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 68,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 69,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 70,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 71,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 72,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 73,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 74,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 75,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 76,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 77,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 78,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 79,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 80,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 81,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 82,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 83,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 84,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 85,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 86,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 87,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 88,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 89,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 90,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 91,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 92,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 93,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 94,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 95,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 96,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 97,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 98,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 99,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 100,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 102,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 103,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 104,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 105,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 106,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 107,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 108,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 109,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 110,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 111,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 112,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 113,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 114,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 115,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 116,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 118,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 120,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 121,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 122,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 124,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 125,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 126,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 127,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 128,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 129,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 130,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 131,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 132,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 133,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 134,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 135,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 136,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 137,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 138,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 139,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 140,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 141,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 142,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 143,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 144,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 145,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 146,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 147,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 148,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 149,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 150,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 151,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 152,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 153,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 154,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 155,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 156,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 157,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 158,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 159,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 160,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 161,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 162,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 163,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 164,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 165,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 166,
                column: "Quantity",
                value: 13);
        }
    }
}
