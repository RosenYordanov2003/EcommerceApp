using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addTwoColumnsInUserMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsResponded",
                table: "UserMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86d51c38-826f-49cb-b047-fff442f31b11", "AQAAAAEAACcQAAAAEM0d9PhF1WdY6mR1xfjwKzq+/Et1sFAOyUAbHAT64r3q2rheMqCoa54SEdYfEavg6Q==", "eef34420-d0b7-47d9-916e-07aa87e7bf66" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "IsResponded",
                table: "UserMessages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a4b3490-1356-45d8-93eb-6765d022cbef", "AQAAAAEAACcQAAAAEDsadFHoAspui8xNZfNzrWW6X3QLTYUM5OL2mHECaEkCuXgh5qTdor0lI7Qwn2C/Qw==", "b98f0c13-1925-4844-b03e-20661bbb2256" });
        }
    }
}
