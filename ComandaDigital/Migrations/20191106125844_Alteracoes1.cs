using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigital.Migrations
{
    public partial class Alteracoes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Mesa_MesaId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Pedido_PedidoId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Produto_ProdutoId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Usuarios_UsuarioId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesa_Estabelecimento_EstabelecimentoId",
                table: "Mesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuarios_UsuarioId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Estabelecimento_EstabelecimentoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedido_MesaId",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "MesaId",
                table: "ItemPedido");

            migrationBuilder.AlterColumn<int>(
                name: "EstabelecimentoId",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MesaId",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstabelecimentoId",
                table: "Mesa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ItemPedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "ItemPedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItemPedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "ItemPedido",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Pedido_PedidoId",
                table: "ItemPedido",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Produto_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Usuarios_UsuarioId",
                table: "ItemPedido",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mesa_Estabelecimento_EstabelecimentoId",
                table: "Mesa",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuarios_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Estabelecimento_EstabelecimentoId",
                table: "Produto",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Pedido_PedidoId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Produto_ProdutoId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Usuarios_UsuarioId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesa_Estabelecimento_EstabelecimentoId",
                table: "Mesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuarios_UsuarioId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Estabelecimento_EstabelecimentoId",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "EstabelecimentoId",
                table: "Produto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MesaId",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EstabelecimentoId",
                table: "Mesa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ItemPedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "ItemPedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItemPedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "ItemPedido",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MesaId",
                table: "ItemPedido",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_MesaId",
                table: "ItemPedido",
                column: "MesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Mesa_MesaId",
                table: "ItemPedido",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Pedido_PedidoId",
                table: "ItemPedido",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Produto_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Usuarios_UsuarioId",
                table: "ItemPedido",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mesa_Estabelecimento_EstabelecimentoId",
                table: "Mesa",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuarios_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Estabelecimento_EstabelecimentoId",
                table: "Produto",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
