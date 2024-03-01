using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class removeShoesOrderTableAndClothOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCartEntities_Orders_OrderId",
                table: "ProductCartEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesCartEntities_Orders_OrderId",
                table: "ShoesCartEntities");

            migrationBuilder.DropTable(
                name: "ClothesOrders");

            migrationBuilder.DropTable(
                name: "ShoesOrders");

            migrationBuilder.DropIndex(
                name: "IX_ShoesCartEntities_OrderId",
                table: "ShoesCartEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProductCartEntities_OrderId",
                table: "ProductCartEntities");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShoesCartEntities");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductCartEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "ShoesOrderEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "ProductOrderEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12aacfe0-36b6-4fea-9299-dc277753b8d9", "AQAAAAEAACcQAAAAECC1+RKeiWvqXPRQdF3yGzR528/Jvqh1d4+DNmi4CxQ+lrNhNnGrgosWDvZ5TOdGBA==", "01169d71-b00d-46ff-8737-80072c6f25d5" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoesOrderEntities_OrderId",
                table: "ShoesOrderEntities",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderEntities_OrderId",
                table: "ProductOrderEntities",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderEntities_Orders_OrderId",
                table: "ProductOrderEntities",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoesOrderEntities_Orders_OrderId",
                table: "ShoesOrderEntities",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderEntities_Orders_OrderId",
                table: "ProductOrderEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesOrderEntities_Orders_OrderId",
                table: "ShoesOrderEntities");

            migrationBuilder.DropIndex(
                name: "IX_ShoesOrderEntities_OrderId",
                table: "ShoesOrderEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrderEntities_OrderId",
                table: "ProductOrderEntities");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShoesOrderEntities");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductOrderEntities");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "ShoesCartEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "ProductCartEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClothesOrders",
                columns: table => new
                {
                    ProductOrderEntityId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesOrders", x => new { x.ProductOrderEntityId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ClothesOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothesOrders_ProductOrderEntities_ProductOrderEntityId",
                        column: x => x.ProductOrderEntityId,
                        principalTable: "ProductOrderEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoesOrders",
                columns: table => new
                {
                    ShoesOrderEntityId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesOrders", x => new { x.ShoesOrderEntityId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ShoesOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoesOrders_ShoesOrderEntities_ShoesOrderEntityId",
                        column: x => x.ShoesOrderEntityId,
                        principalTable: "ShoesOrderEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6b42fe6-7c84-4565-9457-e41df84c7397", "AQAAAAEAACcQAAAAEMMblkv2RmCuqqZyqx0ZhccdJG93uohyGuGRBx5Mzg2bXk4s+3PjCjvpTaGTsc2M3g==", "94522364-c0bf-4b5a-a2ad-ea89ec51be49" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoesCartEntities_OrderId",
                table: "ShoesCartEntities",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCartEntities_OrderId",
                table: "ProductCartEntities",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesOrders_OrderId",
                table: "ClothesOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesOrders_OrderId",
                table: "ShoesOrders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCartEntities_Orders_OrderId",
                table: "ProductCartEntities",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoesCartEntities_Orders_OrderId",
                table: "ShoesCartEntities",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
