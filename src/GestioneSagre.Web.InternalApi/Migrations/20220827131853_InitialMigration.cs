using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneSagre.Web.InternalApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Versione",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodiceVersione = table.Column<string>(type: "TEXT", nullable: true),
                    TestoVersione = table.Column<string>(type: "TEXT", nullable: true),
                    VersioneStato = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versione", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Versione");
        }
    }
}
