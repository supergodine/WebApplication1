using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        // Obtém todas as tarefas
        Task<List<TarefaModel>> BuscarTodasTarefas();

        // Obtém uma tarefa pelo ID
        Task<TarefaModel> BuscarPorId(int id);

        // Adiciona uma nova tarefa
        Task<TarefaModel> Adicionar(TarefaModel tarefa);

        // Atualiza uma tarefa pelo ID
        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);

        // Apaga uma tarefa pelo ID
        Task<bool> Apagar(int id);
    }
}