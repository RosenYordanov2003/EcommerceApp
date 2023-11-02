using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Infrastructure.Migrations
{
    public partial class seedMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Brand_BrandId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_MainCategory_CategoryId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Brand_BrandId",
                table: "Shoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_MainCategory_CategoryId",
                table: "Shoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_MainCategory_MainCategoryId",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainCategory",
                table: "MainCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "MainCategory",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Brands_BrandId",
                table: "Clothes",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Categories_CategoryId",
                table: "Clothes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Brands_BrandId",
                table: "Shoes",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Categories_CategoryId",
                table: "Shoes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Categories_MainCategoryId",
                table: "SubCategory",
                column: "MainCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Brands_BrandId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Categories_CategoryId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Brands_BrandId",
                table: "Shoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Categories_CategoryId",
                table: "Shoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Categories_MainCategoryId",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "MainCategory");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainCategory",
                table: "MainCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Brand_BrandId",
                table: "Clothes",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_MainCategory_CategoryId",
                table: "Clothes",
                column: "CategoryId",
                principalTable: "MainCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Brand_BrandId",
                table: "Shoes",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_MainCategory_CategoryId",
                table: "Shoes",
                column: "CategoryId",
                principalTable: "MainCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_MainCategory_MainCategoryId",
                table: "SubCategory",
                column: "MainCategoryId",
                principalTable: "MainCategory",
                principalColumn: "Id");
        }
    }
}
