using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class new_mig_newdata_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Adverts");
        }
    }
}
