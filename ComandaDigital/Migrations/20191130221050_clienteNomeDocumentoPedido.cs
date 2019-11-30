using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigital.Migrations
{
    public partial class clienteNomeDocumentoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuarios_ClienteId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedido");

            migrationBuilder.AddColumn<string>(
                name: "ClienteDocumento",
                table: "Pedido",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClienteNome",
                table: "Pedido",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteDocumento",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ClienteNome",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuarios_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
