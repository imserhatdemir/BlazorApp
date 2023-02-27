using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class new_product_main : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MainCategoryId",
                table: "Products",
                column: "MainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MainCategories_MainCategoryId",
                table: "Products",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MainCategories_MainCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MainCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MainCategoryId",
                table: "Products");
        }
    }
}
