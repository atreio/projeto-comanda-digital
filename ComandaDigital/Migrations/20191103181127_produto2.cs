using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigital.Migrations
{
    public partial class produto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoId",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EstabelecimentoId",
                table: "Produto",
                column: "EstabelecimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Estabelecimento_EstabelecimentoId",
                table: "Produto",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Estabelecimento_EstabelecimentoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_EstabelecimentoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                table: "Produto");
        }
    }
}
