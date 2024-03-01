using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addNewEntitiesProductAndShoesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductOrderEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrderEntity_Clothes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoesOrderEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoesId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesOrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoesOrderEntity_Shoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClothesOrder",
                columns: table => new
                {
                    ProductOrderEntityId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesOrder", x => new { x.ProductOrderEntityId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ClothesOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothesOrder_ProductOrderEntity_ProductOrderEntityId",
                        column: x => x.ProductOrderEntityId,
                        principalTable: "ProductOrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoesOrder",
                columns: table => new
                {
                    ShoesOrderEntityId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesOrder", x => new { x.ShoesOrderEntityId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ShoesOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoesOrder_ShoesOrderEntity_ShoesOrderEntityId",
                        column: x => x.ShoesOrderEntityId,
                        principalTable: "ShoesOrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8846a23e-1587-47cc-b3c7-e88014b3f44d", "AQAAAAEAACcQAAAAEIaOuL7XIGpiFNrJo5GteaqbhF12dLHK7lVrB+gOGeoG7qvqC0whdPkm2c6ukDJNew==", "aa58f791-b234-404a-8225-39fe4a37850a" });

            migrationBuilder.CreateIndex(
                name: "IX_ClothesOrder_OrderId",
                table: "ClothesOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderEntity_ProductId",
                table: "ProductOrderEntity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesOrder_OrderId",
                table: "ShoesOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesOrderEntity_ShoesId",
                table: "ShoesOrderEntity",
                column: "ShoesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothesOrder");

            migrationBuilder.DropTable(
                name: "ShoesOrder");

            migrationBuilder.DropTable(
                name: "ProductOrderEntity");

            migrationBuilder.DropTable(
                name: "ShoesOrderEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86d51c38-826f-49cb-b047-fff442f31b11", "AQAAAAEAACcQAAAAEM0d9PhF1WdY6mR1xfjwKzq+/Et1sFAOyUAbHAT64r3q2rheMqCoa54SEdYfEavg6Q==", "eef34420-d0b7-47d9-916e-07aa87e7bf66" });
        }
    }
}
