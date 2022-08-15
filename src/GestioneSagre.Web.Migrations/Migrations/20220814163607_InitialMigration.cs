using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneSagre.Web.Migrations.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    StatusFesta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Festa");
        }
    }
}
