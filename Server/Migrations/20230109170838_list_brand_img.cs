using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class list_brand_img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "BrandImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BrandImages_BrandId",
                table: "BrandImages",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandImages_Brands_BrandId",
                table: "BrandImages",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandImages_Brands_BrandId",
                table: "BrandImages");

            migrationBuilder.DropIndex(
                name: "IX_BrandImages_BrandId",
                table: "BrandImages");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "BrandImages");
        }
    }
}
