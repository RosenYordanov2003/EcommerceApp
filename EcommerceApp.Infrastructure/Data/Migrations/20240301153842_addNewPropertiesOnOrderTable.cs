using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addNewPropertiesOnOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCartEntities_Orders_OrderId",
                table: "ProductCartEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoesCartEntities_Orders_OrderId",
                table: "ShoesCartEntities");

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
                table: "ProductOrderEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4be742eb-1832-4253-b181-f175dc5d18b2", "AQAAAAEAACcQAAAAEMNdZM6yKAOMOuSTvNS5D2AkwwYXCHTa8przyLbSvFCiD6bWM3HFyUr1b6r50iFSOQ==", "ef747ab3-dd4d-4082-ad7c-25ed1d72c381" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderEntities_OrderId",
                table: "ProductOrderEntities",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderEntities_Orders_OrderId",
                table: "ProductOrderEntities",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderEntities_Orders_OrderId",
                table: "ProductOrderEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrderEntities_OrderId",
                table: "ProductOrderEntities");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a02377ba-1005-4453-966f-1bda159bcad0", "AQAAAAEAACcQAAAAENdr19o93AeV6lEgAZpDkbmBhrQFPO1zuIU+GBfNZRR1FzDnuVIzbJsmjE4IRPE/Mg==", "aa613b59-a8fa-4bda-826d-8458e6599deb" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoesCartEntities_OrderId",
                table: "ShoesCartEntities",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCartEntities_OrderId",
                table: "ProductCartEntities",
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
