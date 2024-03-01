using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addDbSetsOnNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothesOrder_Orders_OrderId",
                table: "ClothesOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothesOrder_ProductOrderEntity_ProductOrderEntityId",
                table: "ClothesOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderEntity_Clothes_ProductId",
                table: "ProductOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesOrder_Orders_OrderId",
                table: "ShoesOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesOrder_ShoesOrderEntity_ShoesOrderEntityId",
                table: "ShoesOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesOrderEntity_Shoes_ShoesId",
                table: "ShoesOrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoesOrderEntity",
                table: "ShoesOrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoesOrder",
                table: "ShoesOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrderEntity",
                table: "ProductOrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothesOrder",
                table: "ClothesOrder");

            migrationBuilder.RenameTable(
                name: "ShoesOrderEntity",
                newName: "ShoesOrderEntities");

            migrationBuilder.RenameTable(
                name: "ShoesOrder",
                newName: "ShoesOrders");

            migrationBuilder.RenameTable(
                name: "ProductOrderEntity",
                newName: "ProductOrderEntities");

            migrationBuilder.RenameTable(
                name: "ClothesOrder",
                newName: "ClothesOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ShoesOrderEntity_ShoesId",
                table: "ShoesOrderEntities",
                newName: "IX_ShoesOrderEntities_ShoesId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoesOrder_OrderId",
                table: "ShoesOrders",
                newName: "IX_ShoesOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrderEntity_ProductId",
                table: "ProductOrderEntities",
                newName: "IX_ProductOrderEntities_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClothesOrder_OrderId",
                table: "ClothesOrders",
                newName: "IX_ClothesOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoesOrderEntities",
                table: "ShoesOrderEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoesOrders",
                table: "ShoesOrders",
                columns: new[] { "ShoesOrderEntityId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrderEntities",
                table: "ProductOrderEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothesOrders",
                table: "ClothesOrders",
                columns: new[] { "ProductOrderEntityId", "OrderId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a02377ba-1005-4453-966f-1bda159bcad0", "AQAAAAEAACcQAAAAENdr19o93AeV6lEgAZpDkbmBhrQFPO1zuIU+GBfNZRR1FzDnuVIzbJsmjE4IRPE/Mg==", "aa613b59-a8fa-4bda-826d-8458e6599deb" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesOrders_Orders_OrderId",
                table: "ClothesOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesOrders_ProductOrderEntities_ProductOrderEntityId",
                table: "ClothesOrders",
                column: "ProductOrderEntityId",
                principalTable: "ProductOrderEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderEntities_Clothes_ProductId",
                table: "ProductOrderEntities",
                column: "ProductId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoesOrderEntities_Shoes_ShoesId",
                table: "ShoesOrderEntities",
                column: "ShoesId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoesOrders_Orders_OrderId",
                table: "ShoesOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoesOrders_ShoesOrderEntities_ShoesOrderEntityId",
                table: "ShoesOrders",
                column: "ShoesOrderEntityId",
                principalTable: "ShoesOrderEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothesOrders_Orders_OrderId",
                table: "ClothesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothesOrders_ProductOrderEntities_ProductOrderEntityId",
                table: "ClothesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderEntities_Clothes_ProductId",
                table: "ProductOrderEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesOrderEntities_Shoes_ShoesId",
                table: "ShoesOrderEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesOrders_Orders_OrderId",
                table: "ShoesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesOrders_ShoesOrderEntities_ShoesOrderEntityId",
                table: "ShoesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoesOrders",
                table: "ShoesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoesOrderEntities",
                table: "ShoesOrderEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrderEntities",
                table: "ProductOrderEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothesOrders",
                table: "ClothesOrders");

            migrationBuilder.RenameTable(
                name: "ShoesOrders",
                newName: "ShoesOrder");

            migrationBuilder.RenameTable(
                name: "ShoesOrderEntities",
                newName: "ShoesOrderEntity");

            migrationBuilder.RenameTable(
                name: "ProductOrderEntities",
                newName: "ProductOrderEntity");

            migrationBuilder.RenameTable(
                name: "ClothesOrders",
                newName: "ClothesOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ShoesOrders_OrderId",
                table: "ShoesOrder",
                newName: "IX_ShoesOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoesOrderEntities_ShoesId",
                table: "ShoesOrderEntity",
                newName: "IX_ShoesOrderEntity_ShoesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrderEntities_ProductId",
                table: "ProductOrderEntity",
                newName: "IX_ProductOrderEntity_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClothesOrders_OrderId",
                table: "ClothesOrder",
                newName: "IX_ClothesOrder_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoesOrder",
                table: "ShoesOrder",
                columns: new[] { "ShoesOrderEntityId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoesOrderEntity",
                table: "ShoesOrderEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrderEntity",
                table: "ProductOrderEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothesOrder",
                table: "ClothesOrder",
                columns: new[] { "ProductOrderEntityId", "OrderId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8846a23e-1587-47cc-b3c7-e88014b3f44d", "AQAAAAEAACcQAAAAEIaOuL7XIGpiFNrJo5GteaqbhF12dLHK7lVrB+gOGeoG7qvqC0whdPkm2c6ukDJNew==", "aa58f791-b234-404a-8225-39fe4a37850a" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesOrder_Orders_OrderId",
                table: "ClothesOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesOrder_ProductOrderEntity_ProductOrderEntityId",
                table: "ClothesOrder",
                column: "ProductOrderEntityId",
                principalTable: "ProductOrderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderEntity_Clothes_ProductId",
                table: "ProductOrderEntity",
                column: "ProductId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoesOrder_Orders_OrderId",
                table: "ShoesOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoesOrder_ShoesOrderEntity_ShoesOrderEntityId",
                table: "ShoesOrder",
                column: "ShoesOrderEntityId",
                principalTable: "ShoesOrderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoesOrderEntity_Shoes_ShoesId",
                table: "ShoesOrderEntity",
                column: "ShoesId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
