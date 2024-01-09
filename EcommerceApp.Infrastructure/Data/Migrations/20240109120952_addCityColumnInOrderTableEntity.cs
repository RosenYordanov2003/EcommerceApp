using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addCityColumnInOrderTableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 16,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 17,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 1);

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
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 25,
                column: "Quantity",
                value: 17);

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
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 28,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 29,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 30,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 31,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 32,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 33,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 34,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 36,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 37,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 38,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 39,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 40,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 41,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 42,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 43,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 44,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 45,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 46,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 47,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 48,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 49,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 51,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 52,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 53,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 54,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 55,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 56,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 57,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 58,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 59,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 60,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 61,
                column: "Quantity",
                value: 5);

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
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 64,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 65,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 66,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 67,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 68,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 69,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 70,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 71,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 72,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 73,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 74,
                column: "Quantity",
                value: 4);

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
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 77,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 78,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 79,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 80,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 81,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 82,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 83,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 84,
                column: "Quantity",
                value: 17);

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
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 87,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 88,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 89,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 90,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 91,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 92,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 93,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 94,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 95,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 96,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 97,
                column: "Quantity",
                value: 20);

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
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 101,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 102,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 103,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 104,
                column: "Quantity",
                value: 16);

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
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 107,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 108,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 109,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 110,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 111,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 112,
                column: "Quantity",
                value: 10);

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
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 115,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 116,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 117,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 118,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 119,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 120,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 121,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 122,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 123,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 124,
                column: "Quantity",
                value: 16);

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
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 127,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 128,
                column: "Quantity",
                value: 14);

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
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 132,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 133,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 134,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 135,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 136,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 138,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 139,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 140,
                column: "Quantity",
                value: 7);

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
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 143,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 144,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 145,
                column: "Quantity",
                value: 8);

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
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 148,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 149,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 151,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 153,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 154,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 155,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 156,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 157,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 158,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 159,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 160,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 161,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 162,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 163,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 164,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 165,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 166,
                column: "Quantity",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: 1);

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
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 22,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 23,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 25,
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
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 28,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 29,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 30,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 31,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 32,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 33,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 34,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 36,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 37,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 38,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 39,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 40,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 41,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 42,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 43,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 44,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 45,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 46,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 47,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 48,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 49,
                column: "Quantity",
                value: 0);

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
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 53,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 54,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 55,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 56,
                column: "Quantity",
                value: 15);

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
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 59,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 60,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 61,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 62,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 63,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 64,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 65,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 66,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 67,
                column: "Quantity",
                value: 2);

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
                value: 2);

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
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 72,
                column: "Quantity",
                value: 15);

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
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 75,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 76,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 77,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 78,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 79,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 80,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 81,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 82,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 83,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 84,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 85,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 86,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 87,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 88,
                column: "Quantity",
                value: 20);

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
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 91,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 92,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 93,
                column: "Quantity",
                value: 0);

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
                value: 13);

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
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 98,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 99,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 100,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 101,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 102,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 103,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 104,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 105,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 106,
                column: "Quantity",
                value: 1);

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
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 109,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 110,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 111,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 112,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 113,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 114,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 115,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 116,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 117,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 118,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 119,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 120,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 121,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 122,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 123,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 124,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 125,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 126,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 127,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 128,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 130,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 131,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 132,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 133,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 134,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 135,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 136,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 138,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 139,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 140,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 141,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 142,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 143,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 144,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 145,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 146,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 147,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 148,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 149,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 151,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 153,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 154,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 155,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 156,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 157,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 158,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 159,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 160,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 161,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 162,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 163,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 164,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 165,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 166,
                column: "Quantity",
                value: 3);
        }
    }
}
