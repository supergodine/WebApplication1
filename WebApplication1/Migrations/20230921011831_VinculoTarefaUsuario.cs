using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class VinculoTarefaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adição de novas colunas à tabela 'Usuarios'
            migrationBuilder.AddColumn<string>(
                name: "DataNascimento",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Usuarios",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telefone",
                table: "Usuarios",
                type: "int",
                maxLength: 150,
                nullable: false,
                defaultValue: 0);

            // Adição de nova coluna 'UsuarioId' à tabela 'Tarefas'
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            // Criação de índice e chave estrangeira entre 'Tarefas' e 'Usuarios'
            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remoção de índice e chave estrangeira entre 'Tarefas' e 'Usuarios'
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas");

            // Remoção das colunas adicionadas à tabela 'Usuarios'
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuarios");

            // Remoção da coluna 'UsuarioId' da tabela 'Tarefas'
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Tarefas");
        }
    }
}