using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigital.Migrations
{
    public partial class alteracao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Usuarios_UsuarioId",
                table: "ItemPedido");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ItemPedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CozinheiroId",
                table: "ItemPedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GarcomId",
                table: "ItemPedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Usuarios_UsuarioId",
                table: "ItemPedido",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Usuarios_UsuarioId",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "CozinheiroId",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "GarcomId",
                table: "ItemPedido");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ItemPedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Usuarios_UsuarioId",
                table: "ItemPedido",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
