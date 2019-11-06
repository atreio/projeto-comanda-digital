using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigital.Migrations
{
    public partial class Varios2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Mesa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Mesa");
        }
    }
}
