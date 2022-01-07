using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiest_LineUp_LineUpID",
                table: "Artiest");

            migrationBuilder.AlterColumn<int>(
                name: "LineUpID",
                table: "Artiest",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Artiest_LineUp_LineUpID",
                table: "Artiest",
                column: "LineUpID",
                principalTable: "LineUp",
                principalColumn: "LineUpID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiest_LineUp_LineUpID",
                table: "Artiest");

            migrationBuilder.AlterColumn<int>(
                name: "LineUpID",
                table: "Artiest",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artiest_LineUp_LineUpID",
                table: "Artiest",
                column: "LineUpID",
                principalTable: "LineUp",
                principalColumn: "LineUpID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
