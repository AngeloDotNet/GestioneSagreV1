using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneSagre.Web.ExternalApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenotazione",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuidFesta = table.Column<string>(type: "TEXT", nullable: true),
                    Riferimento = table.Column<string>(type: "TEXT", nullable: true),
                    Nominativo = table.Column<string>(type: "TEXT", nullable: true),
                    DataPrenotazione = table.Column<string>(type: "TEXT", nullable: true),
                    OraPrenotazione = table.Column<string>(type: "TEXT", nullable: true),
                    StatoPrenotazione = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazione", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrenotazioneDettaglio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrenotazioneId = table.Column<int>(type: "INTEGER", nullable: false),
                    Prodotto = table.Column<string>(type: "TEXT", nullable: true),
                    Quantita = table.Column<int>(type: "INTEGER", nullable: false),
                    Prezzo_Amount = table.Column<float>(type: "REAL", nullable: true),
                    Prezzo_Currency = table.Column<string>(type: "TEXT", nullable: true),
                    Totale_Amount = table.Column<float>(type: "REAL", nullable: true),
                    Totale_Currency = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrenotazioneDettaglio", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazione");

            migrationBuilder.DropTable(
                name: "PrenotazioneDettaglio");
        }
    }
}
