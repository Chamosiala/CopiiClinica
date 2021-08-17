using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CopiiClinica.Migrations
{
    public partial class Cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Copii",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copii", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notite",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Interval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notite", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prezente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CopilID = table.Column<int>(type: "int", nullable: false),
                    Prezent = table.Column<bool>(type: "bit", nullable: false),
                    NotitaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prezente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prezente_Copii_CopilID",
                        column: x => x.CopilID,
                        principalTable: "Copii",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prezente_Notite_NotitaID",
                        column: x => x.NotitaID,
                        principalTable: "Notite",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prezente_CopilID",
                table: "Prezente",
                column: "CopilID");

            migrationBuilder.CreateIndex(
                name: "IX_Prezente_NotitaID",
                table: "Prezente",
                column: "NotitaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prezente");

            migrationBuilder.DropTable(
                name: "Copii");

            migrationBuilder.DropTable(
                name: "Notite");
        }
    }
}
