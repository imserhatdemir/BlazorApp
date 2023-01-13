using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class new_mig_wizard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ProductWizards",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    WizardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wizard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWizards", x => x.ProdId);
                    table.ForeignKey(
                        name: "FK_ProductWizards_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductWizards_ProductID",
                table: "ProductWizards",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWizards");

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
    }
}
