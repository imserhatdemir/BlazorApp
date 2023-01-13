using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class cartitem_images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartItemProductId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartItemProductTypeId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartItemUserId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CartItemUserId_CartItemProductId_CartItemProductTypeId",
                table: "Images",
                columns: new[] { "CartItemUserId", "CartItemProductId", "CartItemProductTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_CartItems_CartItemUserId_CartItemProductId_CartItemProductTypeId",
                table: "Images",
                columns: new[] { "CartItemUserId", "CartItemProductId", "CartItemProductTypeId" },
                principalTable: "CartItems",
                principalColumns: new[] { "UserId", "ProductId", "ProductTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_CartItems_CartItemUserId_CartItemProductId_CartItemProductTypeId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CartItemUserId_CartItemProductId_CartItemProductTypeId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CartItemProductId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CartItemProductTypeId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CartItemUserId",
                table: "Images");
        }
    }
}
