using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class new_product_mig_wiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWizards");

            migrationBuilder.AddColumn<string>(
                name: "WizardDesc",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardDesc1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardDesc2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardDesc3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardDesc4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardTitle1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardTitle2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardTitle3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WizardTitle4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "WizardDesc", "WizardDesc1", "WizardDesc2", "WizardDesc3", "WizardDesc4", "WizardTitle", "WizardTitle1", "WizardTitle2", "WizardTitle3", "WizardTitle4" },
                values: new object[] { "", "", "", "", "", "", "", "", "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WizardDesc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardDesc1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardDesc2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardDesc3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardDesc4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardTitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardTitle1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardTitle2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardTitle3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WizardTitle4",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductWizards",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Wizard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WizardName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
