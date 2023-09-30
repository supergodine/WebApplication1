using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        // Nome do usuário
        public string? Name { get; set; }

        // Endereço de e-mail do usuário
        public string? Email { get; set; }

        // Número de telefone do usuário
        public int Telefone { get; set; }

        // Endereço do usuário
        public string? Endereco { get; set; }

        // Sexo do usuário
        public string? Sexo { get; set; }

        // Data de nascimento do usuário
        public string? DataNascimento { get; set; }

        // Status do usuário (usando a enumeração StatusTarefa)
        public StatusTarefa Status { get; set; }
    }
}