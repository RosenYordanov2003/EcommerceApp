using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class addSubjectColumnInReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Reviews",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83482f06-a914-44b9-ada2-9a0cdaaf52df", "AQAAAAEAACcQAAAAEOvMJc0/LuDft/OluKWNj/HWjk1oJoGR0iemLLu61J6/+HocpUDYUPu26LV+59VAiA==", "0b8e2375-d24d-4bdf-851f-47a94de56acf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "705edde7-c8d5-4080-ac10-b8fdf7f5d1db", "AQAAAAEAACcQAAAAEOCaNKDN+2gn43nPHjs42tX8TpfkiozGNaGDhDKWdMAZDHCn1l7DAkDLF5s+bEdeVA==", "20e12363-90fc-43ee-bf32-91d5aa4615ab" });
        }
    }
}
