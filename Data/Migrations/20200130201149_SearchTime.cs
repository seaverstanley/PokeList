using Microsoft.EntityFrameworkCore.Migrations;

namespace PokeList.Data.Migrations
{
    public partial class SearchTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Pokemon",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pokemon");
        }
    }
}
