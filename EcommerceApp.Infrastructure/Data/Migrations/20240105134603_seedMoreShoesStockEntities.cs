using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class seedMoreShoesStockEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "ShoesStock",
                columns: new[] { "Id", "Quantity", "ShoesId", "Size" },
                values: new object[,]
                {
                    { 7, 15, 1, 37.0 },
                    { 8, 19, 1, 38.0 },
                    { 9, 11, 1, 39.0 },
                    { 10, 18, 1, 40.0 },
                    { 11, 2, 1, 41.0 },
                    { 12, 3, 1, 42.0 },
                    { 13, 13, 1, 43.0 },
                    { 14, 7, 1, 44.0 },
                    { 15, 14, 1, 45.0 },
                    { 16, 4, 1, 46.0 },
                    { 17, 6, 2, 37.0 },
                    { 18, 17, 2, 38.0 },
                    { 19, 5, 2, 39.0 },
                    { 20, 17, 2, 40.0 },
                    { 21, 10, 2, 41.0 },
                    { 22, 13, 2, 42.0 },
                    { 23, 6, 2, 43.0 },
                    { 24, 19, 2, 44.0 },
                    { 25, 16, 2, 45.0 },
                    { 26, 7, 2, 46.0 },
                    { 27, 3, 3, 37.0 },
                    { 28, 10, 3, 38.0 },
                    { 29, 5, 3, 39.0 },
                    { 30, 10, 3, 40.0 },
                    { 31, 11, 3, 41.0 },
                    { 32, 14, 3, 42.0 },
                    { 33, 14, 3, 43.0 },
                    { 34, 11, 3, 44.0 },
                    { 35, 4, 3, 45.0 },
                    { 36, 12, 3, 46.0 },
                    { 37, 6, 4, 37.0 },
                    { 38, 17, 4, 38.0 },
                    { 39, 15, 4, 39.0 },
                    { 40, 0, 4, 40.0 },
                    { 41, 14, 4, 41.0 },
                    { 42, 17, 4, 42.0 },
                    { 43, 12, 4, 43.0 },
                    { 44, 4, 4, 44.0 },
                    { 45, 17, 4, 45.0 },
                    { 46, 1, 4, 46.0 },
                    { 47, 17, 5, 37.0 },
                    { 48, 14, 5, 38.0 }
                });

            migrationBuilder.InsertData(
                table: "ShoesStock",
                columns: new[] { "Id", "Quantity", "ShoesId", "Size" },
                values: new object[,]
                {
                    { 49, 5, 5, 39.0 },
                    { 50, 13, 5, 40.0 },
                    { 51, 5, 5, 41.0 },
                    { 52, 18, 5, 42.0 },
                    { 53, 8, 5, 43.0 },
                    { 54, 7, 5, 44.0 },
                    { 55, 8, 5, 45.0 },
                    { 56, 9, 5, 46.0 },
                    { 57, 11, 6, 37.0 },
                    { 58, 19, 6, 38.0 },
                    { 59, 17, 6, 39.0 },
                    { 60, 9, 6, 40.0 },
                    { 61, 19, 6, 41.0 },
                    { 62, 18, 6, 42.0 },
                    { 63, 20, 6, 43.0 },
                    { 64, 0, 6, 44.0 },
                    { 65, 4, 6, 45.0 },
                    { 66, 4, 6, 46.0 },
                    { 67, 19, 7, 37.0 },
                    { 68, 4, 7, 38.0 },
                    { 69, 2, 7, 39.0 },
                    { 70, 6, 7, 40.0 },
                    { 71, 4, 7, 41.0 },
                    { 72, 8, 7, 42.0 },
                    { 73, 2, 7, 43.0 },
                    { 74, 7, 7, 44.0 },
                    { 75, 15, 7, 45.0 },
                    { 76, 10, 7, 46.0 },
                    { 77, 3, 8, 37.0 },
                    { 78, 12, 8, 38.0 },
                    { 79, 8, 8, 39.0 },
                    { 80, 16, 8, 40.0 },
                    { 81, 2, 8, 41.0 },
                    { 82, 6, 8, 42.0 },
                    { 83, 13, 8, 43.0 },
                    { 84, 4, 8, 44.0 },
                    { 85, 16, 8, 45.0 },
                    { 86, 4, 8, 46.0 },
                    { 87, 9, 9, 37.0 },
                    { 88, 7, 9, 38.0 },
                    { 89, 11, 9, 39.0 },
                    { 90, 6, 9, 40.0 }
                });

            migrationBuilder.InsertData(
                table: "ShoesStock",
                columns: new[] { "Id", "Quantity", "ShoesId", "Size" },
                values: new object[,]
                {
                    { 91, 16, 9, 41.0 },
                    { 92, 18, 9, 42.0 },
                    { 93, 17, 9, 43.0 },
                    { 94, 4, 9, 44.0 },
                    { 95, 12, 9, 45.0 },
                    { 96, 4, 9, 46.0 },
                    { 97, 5, 10, 37.0 },
                    { 98, 17, 10, 38.0 },
                    { 99, 16, 10, 39.0 },
                    { 100, 6, 10, 40.0 },
                    { 101, 8, 10, 41.0 },
                    { 102, 12, 10, 42.0 },
                    { 103, 16, 10, 43.0 },
                    { 104, 13, 10, 44.0 },
                    { 105, 10, 10, 45.0 },
                    { 106, 13, 10, 46.0 },
                    { 107, 17, 11, 37.0 },
                    { 108, 11, 11, 38.0 },
                    { 109, 11, 11, 39.0 },
                    { 110, 1, 11, 40.0 },
                    { 111, 20, 11, 41.0 },
                    { 112, 19, 11, 42.0 },
                    { 113, 8, 11, 43.0 },
                    { 114, 5, 11, 44.0 },
                    { 115, 20, 11, 45.0 },
                    { 116, 5, 11, 46.0 },
                    { 117, 13, 12, 37.0 },
                    { 118, 12, 12, 38.0 },
                    { 119, 14, 12, 39.0 },
                    { 120, 12, 12, 40.0 },
                    { 121, 0, 12, 41.0 },
                    { 122, 9, 12, 42.0 },
                    { 123, 0, 12, 43.0 },
                    { 124, 2, 12, 44.0 },
                    { 125, 0, 12, 45.0 },
                    { 126, 7, 12, 46.0 },
                    { 127, 12, 13, 37.0 },
                    { 128, 17, 13, 38.0 },
                    { 129, 16, 13, 39.0 },
                    { 130, 5, 13, 40.0 },
                    { 131, 11, 13, 41.0 },
                    { 132, 14, 13, 42.0 }
                });

            migrationBuilder.InsertData(
                table: "ShoesStock",
                columns: new[] { "Id", "Quantity", "ShoesId", "Size" },
                values: new object[,]
                {
                    { 133, 3, 13, 43.0 },
                    { 134, 18, 13, 44.0 },
                    { 135, 4, 13, 45.0 },
                    { 136, 13, 13, 46.0 },
                    { 137, 1, 14, 37.0 },
                    { 138, 16, 14, 38.0 },
                    { 139, 0, 14, 39.0 },
                    { 140, 12, 14, 40.0 },
                    { 141, 4, 14, 41.0 },
                    { 142, 7, 14, 42.0 },
                    { 143, 18, 14, 43.0 },
                    { 144, 0, 14, 44.0 },
                    { 145, 3, 14, 45.0 },
                    { 146, 19, 14, 46.0 },
                    { 147, 10, 15, 37.0 },
                    { 148, 8, 15, 38.0 },
                    { 149, 10, 15, 39.0 },
                    { 150, 8, 15, 40.0 },
                    { 151, 14, 15, 41.0 },
                    { 152, 8, 15, 42.0 },
                    { 153, 0, 15, 43.0 },
                    { 154, 14, 15, 44.0 },
                    { 155, 9, 15, 45.0 },
                    { 156, 15, 15, 46.0 },
                    { 157, 9, 16, 37.0 },
                    { 158, 1, 16, 38.0 },
                    { 159, 8, 16, 39.0 },
                    { 160, 19, 16, 40.0 },
                    { 161, 6, 16, 41.0 },
                    { 162, 19, 16, 42.0 },
                    { 163, 16, 16, 43.0 },
                    { 164, 17, 16, 44.0 },
                    { 165, 17, 16, 45.0 },
                    { 166, 18, 16, 46.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.InsertData(
                table: "ShoesStock",
                columns: new[] { "Id", "Quantity", "ShoesId", "Size" },
                values: new object[,]
                {
                    { 1, 3, 2, 40.0 },
                    { 2, 6, 2, 41.0 },
                    { 3, 7, 2, 43.0 },
                    { 4, 8, 2, 44.0 },
                    { 5, 18, 2, 45.0 },
                    { 6, 0, 2, 46.0 }
                });
        }
    }
}
