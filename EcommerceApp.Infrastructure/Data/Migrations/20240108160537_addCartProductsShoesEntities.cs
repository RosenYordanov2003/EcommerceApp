using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addCartProductsShoesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Carts_CartId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStocks_Clothes_ProductId",
                table: "ProductStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Carts_CartId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_CartId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_CartId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Clothes");

            migrationBuilder.CreateTable(
                name: "ProductCartEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCartEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCartEntity_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCartEntity_Clothes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Clothes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoesCartEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoesId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesCartEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoesCartEntity_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoesCartEntity_Shoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/e9091962695943f6a5ed67219538ad6d_9366/Ultraboost_1.0_Shoes_Grey_IF1912_04_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b8c729aec8104a78a71a1b99013b100f_9366/Ultraboost_1.0_Shoes_Grey_IF1912_02_standard_hover.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/7f359276eda44bd1b5406251b2be5d55_9366/Ultraboost_1.0_Shoes_Grey_IF1912_03_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b8c729aec8104a78a71a1b99013b100f_9366/Ultraboost_1.0_Shoes_Grey_IF1912_02_standard_hover.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b79a6a72567845b4b8a6a6cd35426ef9_9366/Pureboost_23_Running_Shoes_Green_IF1548_01_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/9a8c1e54acab4922a97463898dfa5b6b_9366/Pureboost_23_Running_Shoes_Green_IF1548_02_standard_hover.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/2850801c47684ba7a0aee1c75ca864fd_9366/Pureboost_23_Running_Shoes_Green_IF1548_03_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/b0742a0521ca4a67856b4f1fff27e6b3_9366/Pureboost_23_Running_Shoes_Green_IF1548_04_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/1856d88d74fe4d02b678ea56a7130b97_9366/Adizero_Impact_American_Football_Cleats_Black_ID1828_01_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/419feb4c7ba3459f9eed646c26645387_9366/Adizero_Impact_American_Football_Cleats_Black_ID1828_02_standard_hover.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/e12b2c6d8c4b4ec68dc2dc0ea32804dc_9366/Adizero_Impact_American_Football_Cleats_Black_ID1828_03_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 35,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/ef07175df84147b9becfe5dae432b104_9366/Adizero_Impact_American_Football_Cleats_Black_ID1828_04_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/2872eabe08dd4141a718bf2326e19ca0_9366/Adizero_Electric_American_Football_Cleats_White_IE4374_01_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/beddd0544dc94959b107e174d8a4294f_9366/Adizero_Electric_American_Football_Cleats_White_IE4374_02_standard_hover.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/09f4413fe2d54fe0b34434de76c25fdf_9366/Adizero_Electric_American_Football_Cleats_White_IE4374_03_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 39,
                column: "ImgUrl",
                value: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/6c0cac3d8958498694ae53c78ad021bc_9366/Adizero_Electric_American_Football_Cleats_White_IE4374_04_standard.jpg");

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Color",
                value: "Black");

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 14);

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
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 13,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: 8);

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
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 22,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 23,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 25,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 26,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 27,
                column: "Quantity",
                value: 11);

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
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 30,
                column: "Quantity",
                value: 13);

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
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 34,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 35,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 36,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 37,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 38,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 40,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 41,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 42,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 43,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 44,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 45,
                column: "Quantity",
                value: 5);

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
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 49,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 50,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 52,
                column: "Quantity",
                value: 12);

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
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 55,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 56,
                column: "Quantity",
                value: 19);

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
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 59,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 60,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 61,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 64,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 65,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 66,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 67,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 68,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 69,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 70,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 71,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 72,
                column: "Quantity",
                value: 12);

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
                value: 0);

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
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 77,
                column: "Quantity",
                value: 6);

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
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 80,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 81,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 82,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 83,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 84,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 85,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 86,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 87,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 88,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 89,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 90,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 91,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 92,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 93,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 94,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 95,
                column: "Quantity",
                value: 3);

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
                value: 15);

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
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 100,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 101,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 102,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 103,
                column: "Quantity",
                value: 19);

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
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 106,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 107,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 108,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 109,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 110,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 111,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 112,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 114,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 115,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 116,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 117,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 118,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 119,
                column: "Quantity",
                value: 13);

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
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 122,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 123,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 124,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 125,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 126,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 127,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 128,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 129,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 130,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 131,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 132,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 133,
                column: "Quantity",
                value: 3);

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
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 136,
                column: "Quantity",
                value: 0);

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
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 139,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 140,
                column: "Quantity",
                value: 8);

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
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 143,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 144,
                column: "Quantity",
                value: 7);

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
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 147,
                column: "Quantity",
                value: 4);

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
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 150,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 151,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 152,
                column: "Quantity",
                value: 11);

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
                value: 1);

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
                value: 14);

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
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 159,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 160,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 161,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 162,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 163,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 164,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 165,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 166,
                column: "Quantity",
                value: 10);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCartEntity_CartId",
                table: "ProductCartEntity",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCartEntity_ProductId",
                table: "ProductCartEntity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesCartEntity_CartId",
                table: "ShoesCartEntity",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesCartEntity_ShoesId",
                table: "ShoesCartEntity",
                column: "ShoesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStocks_Clothes_ProductId",
                table: "ProductStocks",
                column: "ProductId",
                principalTable: "Clothes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStocks_Clothes_ProductId",
                table: "ProductStocks");

            migrationBuilder.DropTable(
                name: "ProductCartEntity");

            migrationBuilder.DropTable(
                name: "ShoesCartEntity");

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

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_2.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_4.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20675_5.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_2.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_4.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Alphabounce%20Beyond%20Team%20-%20BG-%20673_5.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_1.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_2.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 35,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20ACE%2017%203%20Firm%20Ground%20-%20BG-O96%203371_3.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 36,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 37,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_2.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 38,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_3.jpg");

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 39,
                column: "ImgUrl",
                value: "https://www.sambabulgariashop.me/images/adidasbulgaria/Adidas%20Adizero%208%200%20-%20BG-L307B%20521_5.jpg");

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Color",
                value: "Orange");

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 13,
                column: "Quantity",
                value: 7);

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
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 16,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 17,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 22,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 23,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 25,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 26,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 27,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 28,
                column: "Quantity",
                value: 3);

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
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 32,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 33,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 34,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 35,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 36,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 37,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 38,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 40,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 41,
                column: "Quantity",
                value: 1);

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
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 44,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 45,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 46,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 47,
                column: "Quantity",
                value: 14);

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
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 52,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 53,
                column: "Quantity",
                value: 9);

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
                value: 10);

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
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 58,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 59,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 60,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 61,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 64,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 65,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 66,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 67,
                column: "Quantity",
                value: 9);

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
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 70,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 71,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 72,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 73,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 74,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 75,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 76,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 77,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 78,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 79,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 80,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 81,
                column: "Quantity",
                value: 4);

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
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 84,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 85,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 86,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 87,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 88,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 89,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 90,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 91,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 92,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 93,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 94,
                column: "Quantity",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 95,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 96,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 97,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 98,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 99,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 100,
                column: "Quantity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 101,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 102,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 103,
                column: "Quantity",
                value: 10);

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
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 106,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 107,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 108,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 109,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 110,
                column: "Quantity",
                value: 16);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 111,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 112,
                column: "Quantity",
                value: 17);

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
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 116,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 117,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 118,
                column: "Quantity",
                value: 4);

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
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 121,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 122,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 123,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 124,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 125,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 126,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 127,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 128,
                column: "Quantity",
                value: 19);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 129,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 130,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 131,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 132,
                column: "Quantity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 133,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 134,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 135,
                column: "Quantity",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 136,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 137,
                column: "Quantity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 138,
                column: "Quantity",
                value: 14);

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
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 141,
                column: "Quantity",
                value: 16);

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
                value: 20);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 144,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 145,
                column: "Quantity",
                value: 17);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 146,
                column: "Quantity",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 147,
                column: "Quantity",
                value: 17);

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
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 150,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 151,
                column: "Quantity",
                value: 14);

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
                value: 9);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 154,
                column: "Quantity",
                value: 18);

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
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 157,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 158,
                column: "Quantity",
                value: 6);

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
                value: 12);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 161,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 162,
                column: "Quantity",
                value: 13);

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
                value: 6);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 165,
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShoesStock",
                keyColumn: "Id",
                keyValue: 166,
                column: "Quantity",
                value: 14);

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_CartId",
                table: "Shoes",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_CartId",
                table: "Clothes",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Carts_CartId",
                table: "Clothes",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStocks_Clothes_ProductId",
                table: "ProductStocks",
                column: "ProductId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Carts_CartId",
                table: "Shoes",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
