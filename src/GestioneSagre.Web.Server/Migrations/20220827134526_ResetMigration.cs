using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneSagre.Web.Server.Migrations
{
    public partial class ResetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuidFesta = table.Column<string>(type: "TEXT", nullable: true),
                    CategoriaVideo = table.Column<string>(type: "TEXT", nullable: true),
                    CategoriaStampa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Festa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuidFesta = table.Column<string>(type: "TEXT", nullable: true),
                    DataInizio = table.Column<string>(type: "TEXT", nullable: true),
                    DataFine = table.Column<string>(type: "TEXT", nullable: true),
                    Titolo = table.Column<string>(type: "TEXT", nullable: true),
                    Edizione = table.Column<string>(type: "TEXT", nullable: true),
                    Luogo = table.Column<string>(type: "TEXT", nullable: true),
                    Logo = table.Column<string>(type: "TEXT", nullable: true),
                    GestioneCoperti = table.Column<bool>(type: "INTEGER", nullable: false),
                    GestioneMenu = table.Column<bool>(type: "INTEGER", nullable: false),
                    StampaCarta = table.Column<bool>(type: "INTEGER", nullable: false),
                    StampaLogo = table.Column<bool>(type: "INTEGER", nullable: false),
                    StampaRicevuta = table.Column<bool>(type: "INTEGER", nullable: false),
                    StatusFesta = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prodotto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuidFesta = table.Column<string>(type: "TEXT", nullable: true),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Prodotto = table.Column<string>(type: "TEXT", nullable: true),
                    ProdottoAttivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Prezzo_Amount = table.Column<float>(type: "REAL", nullable: true),
                    Prezzo_Currency = table.Column<string>(type: "TEXT", nullable: true),
                    Quantita = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantitaAttiva = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuantitaScorta = table.Column<int>(type: "INTEGER", nullable: false),
                    AvvisoScorta = table.Column<bool>(type: "INTEGER", nullable: false),
                    Prenotazione = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Festa");

            migrationBuilder.DropTable(
                name: "Prodotto");
        }
    }
}
