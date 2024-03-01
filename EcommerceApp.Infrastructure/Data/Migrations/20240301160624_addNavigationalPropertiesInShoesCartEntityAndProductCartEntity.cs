using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addNavigationalPropertiesInShoesCartEntityAndProductCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6b42fe6-7c84-4565-9457-e41df84c7397", "AQAAAAEAACcQAAAAEMMblkv2RmCuqqZyqx0ZhccdJG93uohyGuGRBx5Mzg2bXk4s+3PjCjvpTaGTsc2M3g==", "94522364-c0bf-4b5a-a2ad-ea89ec51be49" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b90cc7fd-d6be-41d3-b5e7-e91b665faf4f", "AQAAAAEAACcQAAAAEEgcXynYaDLRAa6nXPLaAgvYhyE7SzfJYjRidziGGUnTNgJltaFHISdOIeRtRj3jrA==", "2c6c14b0-429f-4af6-bd57-8ac15acebfca" });
        }
    }
}
