using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador para manipulação de dados relacionados a usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Construtor da classe UsuarioController.
        /// </summary>
        /// <param name="usuarioRepositorio">Instância da interface de repositório de usuários.</param>
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Obtém todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de todos os usuários.</returns>
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            // Chama o repositório para buscar todos os usuários.
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();

            // Retorna a lista de usuários.
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtém um usuário específico pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser buscado.</param>
        /// <returns>Usuário correspondente ao ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            // Chama o repositório para buscar o usuário pelo ID.
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);

            // Retorna o usuário encontrado.
            return Ok(usuario);
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuarioModel">Modelo do usuário a ser cadastrado.</param>
        /// <returns>Usuário cadastrado.</returns>
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            // Chama o repositório para adicionar o novo usuário.
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);

            // Retorna o usuário cadastrado.
            return Ok(usuario);
        }

        /// <summary>
        /// Atualiza um usuário existente pelo seu ID.
        /// </summary>
        /// <param name="usuarioModel">Modelo do usuário com as atualizações.</param>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <returns>Usuário atualizado.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            // Define o ID do usuário no modelo antes de chamar o repositório.
            usuarioModel.Id = id;

            // Chama o repositório para atualizar o usuário.
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);

            // Retorna o usuário atualizado.
            return Ok(usuario);
        }

        /// <summary>
        /// Apaga um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser apagado.</param>
        /// <returns>Indica se o usuário foi apagado com sucesso.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            // Chama o repositório para apagar o usuário pelo ID.
            bool apagado = await _usuarioRepositorio.Apagar(id);

            // Retorna um indicativo se o usuário foi apagado com sucesso.
            return Ok(apagado);
        }
    }
}