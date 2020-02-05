using Microsoft.EntityFrameworkCore.Migrations;

namespace PokeList.Data.Migrations
{
    public partial class UpdateDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caught",
                table: "Pokemon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Caught",
                table: "Pokemon",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
