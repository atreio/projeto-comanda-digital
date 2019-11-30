using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigital.Migrations
{
    public partial class ajustesPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesa_Pedido_PedidoAtivoId",
                table: "Mesa");

            migrationBuilder.DropIndex(
                name: "IX_Mesa_PedidoAtivoId",
                table: "Mesa");

            migrationBuilder.DropColumn(
                name: "PedidoAtivoId",
                table: "Mesa");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Mesa",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_PedidoId",
                table: "Mesa",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesa_Pedido_PedidoId",
                table: "Mesa",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesa_Pedido_PedidoId",
                table: "Mesa");

            migrationBuilder.DropIndex(
                name: "IX_Mesa_PedidoId",
                table: "Mesa");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Mesa");

            migrationBuilder.AddColumn<int>(
                name: "PedidoAtivoId",
                table: "Mesa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_PedidoAtivoId",
                table: "Mesa",
                column: "PedidoAtivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesa_Pedido_PedidoAtivoId",
                table: "Mesa",
                column: "PedidoAtivoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
