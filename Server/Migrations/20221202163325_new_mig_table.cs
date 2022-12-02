using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class new_mig_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "MissionVisions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "MissionVisions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Faqs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Faqs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CustomerNums",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "CustomerNums",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ContactAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "ContactAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ContactAbouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "ContactAbouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CentreNumbers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "CentreNumbers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "BankAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "BankAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MissionVisions");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "MissionVisions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CustomerNums");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "CustomerNums");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ContactAddresses");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "ContactAddresses");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ContactAbouts");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "ContactAbouts");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CentreNumbers");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "CentreNumbers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "BankAccounts");
        }
    }
}
