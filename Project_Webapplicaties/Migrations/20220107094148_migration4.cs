using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Ticket",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Ticket");
        }
    }
}
