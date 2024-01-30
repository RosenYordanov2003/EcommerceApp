using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addUserConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"), 0, null, "862c1e76-ccef-4e70-81c9-588d45b031c0", "admin123@gmail.com", false, false, null, "ADMIN123@GMAIL.COM", "АDMIN", "AQAAAAEAACcQAAAAEEPWe0sefz/Thg5u1aSbade38tzmRm4Qte/d66iVMAp7GnvxW4lOZKZheYprMcfxjg==", null, false, null, "7a8e5e46-e393-4c0a-b8bf-9c2a584c272c", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"));
        }
    }
}
