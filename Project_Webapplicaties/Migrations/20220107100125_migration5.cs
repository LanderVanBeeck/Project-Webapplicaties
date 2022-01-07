using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Bestelling_BestellingID",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "BestellingID",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Bestelling_BestellingID",
                table: "Ticket",
                column: "BestellingID",
                principalTable: "Bestelling",
                principalColumn: "BestellingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Bestelling_BestellingID",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "BestellingID",
                table: "Ticket",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Bestelling_BestellingID",
                table: "Ticket",
                column: "BestellingID",
                principalTable: "Bestelling",
                principalColumn: "BestellingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
