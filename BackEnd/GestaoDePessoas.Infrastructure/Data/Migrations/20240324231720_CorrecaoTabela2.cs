using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeClientes.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabela2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clientes_enderecos_endereco_id",
                table: "clientes");

            migrationBuilder.AddForeignKey(
                name: "fk_clientes_enderecos_endereco_id",
                table: "clientes",
                column: "endereco_id",
                principalTable: "enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clientes_enderecos_endereco_id",
                table: "clientes");

            migrationBuilder.AddForeignKey(
                name: "fk_clientes_enderecos_endereco_id",
                table: "clientes",
                column: "endereco_id",
                principalTable: "enderecos",
                principalColumn: "id");
        }
    }
}
