using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeClientes.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clientes_endereco_endereco_id",
                table: "clientes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_endereco",
                table: "endereco");

            migrationBuilder.RenameTable(
                name: "endereco",
                newName: "enderecos");

            migrationBuilder.AddPrimaryKey(
                name: "pk_enderecos",
                table: "enderecos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_clientes_enderecos_endereco_id",
                table: "clientes",
                column: "endereco_id",
                principalTable: "enderecos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clientes_enderecos_endereco_id",
                table: "clientes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_enderecos",
                table: "enderecos");

            migrationBuilder.RenameTable(
                name: "enderecos",
                newName: "endereco");

            migrationBuilder.AddPrimaryKey(
                name: "pk_endereco",
                table: "endereco",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_clientes_endereco_endereco_id",
                table: "clientes",
                column: "endereco_id",
                principalTable: "endereco",
                principalColumn: "id");
        }
    }
}
