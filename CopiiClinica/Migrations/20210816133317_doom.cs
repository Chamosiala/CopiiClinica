using Microsoft.EntityFrameworkCore.Migrations;

namespace CopiiClinica.Migrations
{
    public partial class doom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prezente_Notite_NotitaID",
                table: "Prezente");

            migrationBuilder.DropIndex(
                name: "IX_Prezente_NotitaID",
                table: "Prezente");

            migrationBuilder.DropColumn(
                name: "NotitaID",
                table: "Prezente");

            migrationBuilder.AddColumn<int>(
                name: "PrezentaID",
                table: "Notite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notite_PrezentaID",
                table: "Notite",
                column: "PrezentaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notite_Prezente_PrezentaID",
                table: "Notite",
                column: "PrezentaID",
                principalTable: "Prezente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notite_Prezente_PrezentaID",
                table: "Notite");

            migrationBuilder.DropIndex(
                name: "IX_Notite_PrezentaID",
                table: "Notite");

            migrationBuilder.DropColumn(
                name: "PrezentaID",
                table: "Notite");

            migrationBuilder.AddColumn<int>(
                name: "NotitaID",
                table: "Prezente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prezente_NotitaID",
                table: "Prezente",
                column: "NotitaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prezente_Notite_NotitaID",
                table: "Prezente",
                column: "NotitaID",
                principalTable: "Notite",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
