using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Gebruiker_GebruikerID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_GebruikerID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "GebruikerID",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "BestellingID",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bestelling",
                columns: table => new
                {
                    BestellingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotaalBedrag = table.Column<decimal>(nullable: false),
                    TicketID = table.Column<int>(nullable: false),
                    GebruikerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.BestellingID);
                    table.ForeignKey(
                        name: "FK_Bestelling_Gebruiker_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruiker",
                        principalColumn: "GebruikerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BestellingID",
                table: "Ticket",
                column: "BestellingID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_GebruikerID",
                table: "Bestelling",
                column: "GebruikerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Bestelling_BestellingID",
                table: "Ticket",
                column: "BestellingID",
                principalTable: "Bestelling",
                principalColumn: "BestellingID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Bestelling_BestellingID",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "Bestelling");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_BestellingID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "BestellingID",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "GebruikerID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_GebruikerID",
                table: "Ticket",
                column: "GebruikerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Gebruiker_GebruikerID",
                table: "Ticket",
                column: "GebruikerID",
                principalTable: "Gebruiker",
                principalColumn: "GebruikerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
