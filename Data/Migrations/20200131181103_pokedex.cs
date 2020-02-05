using Microsoft.EntityFrameworkCore.Migrations;

namespace PokeList.Data.Migrations
{
    public partial class pokedex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PokeDexEntry",
                table: "Pokemon",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokeDexEntry",
                table: "Pokemon");
        }
    }
}
