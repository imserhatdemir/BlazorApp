using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class new_data_categoryconnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainCategories_Categories_CategoryId",
                table: "MainCategories");

            migrationBuilder.DropIndex(
                name: "IX_MainCategories_CategoryId",
                table: "MainCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MainCategories");

            migrationBuilder.CreateTable(
                name: "CategoryConnects",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryConnects", x => new { x.CategoryId, x.MainCategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryConnects_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryConnects_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryConnects_MainCategoryId",
                table: "CategoryConnects",
                column: "MainCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryConnects");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MainCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MainCategories_CategoryId",
                table: "MainCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCategories_Categories_CategoryId",
                table: "MainCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
