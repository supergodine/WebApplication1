namespace WebApplication1.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }

        // Nome da tarefa
        public string? Name { get; set; }

        // Descrição da tarefa
        public string? Descricao { get; set; }

        // Status da tarefa (representado por um inteiro)
        public int Status { get; set; }

        // ID do usuário associado a esta tarefa
        public int? UsuarioId { get; set; }

        // Propriedade de navegação para o usuário associado a esta tarefa
        public virtual UsuarioModel? Usuario { get; set; }
    }
}