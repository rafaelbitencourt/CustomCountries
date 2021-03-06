using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomCountries.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    area = table.Column<float>(type: "real", nullable: false),
                    population = table.Column<float>(type: "real", nullable: false),
                    populationdensity = table.Column<float>(type: "real", nullable: false),
                    capital = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
