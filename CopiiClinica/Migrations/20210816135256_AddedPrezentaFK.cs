using Microsoft.EntityFrameworkCore.Migrations;

namespace CopiiClinica.Migrations
{
    public partial class AddedPrezentaFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notite_Prezente_PrezentaID",
                table: "Notite");

            migrationBuilder.AlterColumn<int>(
                name: "PrezentaID",
                table: "Notite",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notite_Prezente_PrezentaID",
                table: "Notite",
                column: "PrezentaID",
                principalTable: "Prezente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notite_Prezente_PrezentaID",
                table: "Notite");

            migrationBuilder.AlterColumn<int>(
                name: "PrezentaID",
                table: "Notite",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Notite_Prezente_PrezentaID",
                table: "Notite",
                column: "PrezentaID",
                principalTable: "Prezente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
