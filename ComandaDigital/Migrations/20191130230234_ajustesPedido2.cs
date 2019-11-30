using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigital.Migrations
{
    public partial class ajustesPedido2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesa_Estabelecimento_EstabelecimentoId",
                table: "Mesa");

            migrationBuilder.DropIndex(
                name: "IX_Mesa_EstabelecimentoId",
                table: "Mesa");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                table: "Mesa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoId",
                table: "Mesa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_EstabelecimentoId",
                table: "Mesa",
                column: "EstabelecimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesa_Estabelecimento_EstabelecimentoId",
                table: "Mesa",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
