using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        // Obtém todos os usuários
        Task<List<UsuarioModel>> BuscarTodosUsuarios();

        // Obtém um usuário pelo ID
        Task<UsuarioModel> BuscarPorId(int id);

        // Adiciona um novo usuário
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        // Atualiza um usuário pelo ID
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

        // Apaga um usuário pelo ID
        Task<bool> Apagar(int id);
    }
}