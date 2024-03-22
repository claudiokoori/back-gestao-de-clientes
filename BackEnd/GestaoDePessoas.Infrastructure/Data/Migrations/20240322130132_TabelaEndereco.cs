using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeClientes.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_clientes_cpf",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "ix_clientes_telefone",
                table: "clientes");

            migrationBuilder.AlterColumn<string>(
                name: "telefone",
                table: "clientes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "nome_completo",
                table: "clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "clientes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "endereco_id",
                table: "clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ibge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ddd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    siafi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    casa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_endereco", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_clientes_cpf",
                table: "clientes",
                column: "cpf",
                unique: true,
                filter: "[cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_clientes_endereco_id",
                table: "clientes",
                column: "endereco_id",
                unique: true,
                filter: "[endereco_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_clientes_telefone",
                table: "clientes",
                column: "telefone",
                unique: true,
                filter: "[telefone] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_clientes_endereco_endereco_id",
                table: "clientes",
                column: "endereco_id",
                principalTable: "endereco",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clientes_endereco_endereco_id",
                table: "clientes");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropIndex(
                name: "ix_clientes_cpf",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "ix_clientes_endereco_id",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "ix_clientes_telefone",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "endereco_id",
                table: "clientes");

            migrationBuilder.AlterColumn<string>(
                name: "telefone",
                table: "clientes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome_completo",
                table: "clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_clientes_cpf",
                table: "clientes",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_clientes_telefone",
                table: "clientes",
                column: "telefone",
                unique: true);
        }
    }
}
