using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarService.Migrations
{
    public partial class CreateIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autoteenus",
                columns: table => new
                {
                    AutoteenusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    autoteenus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hind = table.Column<int>(type: "int", nullable: false),
                    Aeg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autoteenus", x => x.AutoteenusID);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    KlientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vanus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.KlientID);
                });

            migrationBuilder.CreateTable(
                name: "Tootaja",
                columns: table => new
                {
                    TootajaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vanus = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    haridus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tootaja", x => x.TootajaID);
                });

            migrationBuilder.CreateTable(
                name: "Tellimus",
                columns: table => new
                {
                    TellimusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TootajaID = table.Column<int>(type: "int", nullable: false),
                    AutoteenusID = table.Column<int>(type: "int", nullable: false),
                    KlientID = table.Column<int>(type: "int", nullable: false),
                    Kuupaev = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aeg = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tellimus", x => x.TellimusID);
                    table.ForeignKey(
                        name: "FK_Tellimus_Autoteenus_AutoteenusID",
                        column: x => x.AutoteenusID,
                        principalTable: "Autoteenus",
                        principalColumn: "AutoteenusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tellimus_Klient_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klient",
                        principalColumn: "KlientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tellimus_Tootaja_TootajaID",
                        column: x => x.TootajaID,
                        principalTable: "Tootaja",
                        principalColumn: "TootajaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tellimus_AutoteenusID",
                table: "Tellimus",
                column: "AutoteenusID");

            migrationBuilder.CreateIndex(
                name: "IX_Tellimus_KlientID",
                table: "Tellimus",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_Tellimus_TootajaID",
                table: "Tellimus",
                column: "TootajaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tellimus");

            migrationBuilder.DropTable(
                name: "Autoteenus");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Tootaja");
        }
    }
}
