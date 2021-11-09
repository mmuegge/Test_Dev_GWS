using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GWS_MVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gas_tarif",
                columns: table => new
                {
                    ID_Anbieter = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Anbieter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gas_tarif", x => x.ID_Anbieter);
                });

            migrationBuilder.CreateTable(
                name: "Gas_zaehlerstand",
                columns: table => new
                {
                    ID_Tag = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_Anbieter = table.Column<int>(nullable: false),
                    Ablesetag = table.Column<DateTime>(nullable: false),
                    Zaehlerstand = table.Column<double>(nullable: true),
                    Uhrzeit = table.Column<DateTime>(nullable: false),
                    Temperatur_aussen = table.Column<double>(nullable: true),
                    Temperatur_innen = table.Column<double>(nullable: true),
                    Bemerkungen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gas_zaehlerstand", x => x.ID_Tag);
                });

            migrationBuilder.CreateTable(
                name: "Konfiguration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konfiguration", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Strom_tarif",
                columns: table => new
                {
                    ID_Anbieter = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Anbieter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strom_tarif", x => x.ID_Anbieter);
                });

            migrationBuilder.CreateTable(
                name: "Strom_zaehlerstand",
                columns: table => new
                {
                    ID_Tag = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_Anbieter = table.Column<int>(nullable: false),
                    Ablesetag = table.Column<DateTime>(nullable: false),
                    Zaehlerstand = table.Column<double>(nullable: true),
                    Uhrzeit = table.Column<DateTime>(nullable: false),
                    Temperatur_aussen = table.Column<double>(nullable: true),
                    Temperatur_innen = table.Column<double>(nullable: true),
                    Bemerkungen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strom_zaehlerstand", x => x.ID_Tag);
                });

            migrationBuilder.CreateTable(
                name: "Wasser_tarif",
                columns: table => new
                {
                    ID_Anbieter = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Anbieter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wasser_tarif", x => x.ID_Anbieter);
                });

            migrationBuilder.CreateTable(
                name: "Wasser_zaehlerstand",
                columns: table => new
                {
                    ID_Tag = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_Anbieter = table.Column<int>(nullable: false),
                    Ablesetag = table.Column<DateTime>(nullable: false),
                    Zaehlerstand = table.Column<double>(nullable: true),
                    Uhrzeit = table.Column<DateTime>(nullable: false),
                    Temperatur_aussen = table.Column<double>(nullable: true),
                    Temperatur_innen = table.Column<double>(nullable: true),
                    Bemerkungen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wasser_zaehlerstand", x => x.ID_Tag);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gas_tarif");

            migrationBuilder.DropTable(
                name: "Gas_zaehlerstand");

            migrationBuilder.DropTable(
                name: "Konfiguration");

            migrationBuilder.DropTable(
                name: "Strom_tarif");

            migrationBuilder.DropTable(
                name: "Strom_zaehlerstand");

            migrationBuilder.DropTable(
                name: "Wasser_tarif");

            migrationBuilder.DropTable(
                name: "Wasser_zaehlerstand");
        }
    }
}
