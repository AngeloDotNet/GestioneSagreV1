using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneSagre.Web.Migrations.Migrations
{
    public partial class AddTabellaProdotto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Prodotto");
        }
    }
}
