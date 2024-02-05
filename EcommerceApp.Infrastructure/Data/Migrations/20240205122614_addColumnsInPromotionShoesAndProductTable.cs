using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addColumnsInPromotionShoesAndProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Shoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireTime",
                table: "Promotion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Clothes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da1d5d17-9c86-4768-a116-2f99a0dce29d", "AQAAAAEAACcQAAAAEKUDkaxX32GCQQItf65aXIr6o/2hYYa2xajeF/doNpitz6WywoecIwVARruzUk3YmQ==", "198bb212-01ac-46c6-9f3d-50604644fb21" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ExpireTime",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Clothes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "117664a5-fa4d-4c55-bde9-c599c856707a", "AQAAAAEAACcQAAAAEGKHMvZ14apcXOSd5KT0XAZu6QCOdbRG/eWzly8cgvm7LL/jgwxeWE23kccImIS45g==", "4631075c-987d-43ca-b591-8c152faa8e4e" });
        }
    }
}
