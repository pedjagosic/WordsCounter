using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoveFieldCountOfWordsFromText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfWordsFromText",
                table: "Texts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfWordsFromText",
                table: "Texts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
