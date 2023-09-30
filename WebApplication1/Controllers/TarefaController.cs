using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador para manipulação de dados relacionados a tarefas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        /// <summary>
        /// Construtor da classe TarefaController.
        /// </summary>
        /// <param name="tarefaRepositorio">Instância da interface de repositório de tarefas.</param>
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        /// <summary>
        /// Obtém todas as tarefas cadastradas.
        /// </summary>
        /// <returns>Lista de todas as tarefas.</returns>
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas()
        {
            // Chama o repositório para buscar todas as tarefas.
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();

            // Retorna a lista de tarefas.
            return Ok(tarefas);
        }

        /// <summary>
        /// Obtém uma tarefa específica pelo seu ID.
        /// </summary>
        /// <param name="id">ID da tarefa a ser buscada.</param>
        /// <returns>Tarefa correspondente ao ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            // Chama o repositório para buscar a tarefa pelo ID.
            TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);

            // Retorna a tarefa encontrada.
            return Ok(tarefa);
        }

        /// <summary>
        /// Cadastra uma nova tarefa.
        /// </summary>
        /// <param name="tarefaModel">Modelo da tarefa a ser cadastrada.</param>
        /// <returns>Tarefa cadastrada.</returns>
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            // Chama o repositório para adicionar a nova tarefa.
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);

            // Retorna a tarefa cadastrada.
            return Ok(tarefa);
        }

        /// <summary>
        /// Atualiza uma tarefa existente pelo seu ID.
        /// </summary>
        /// <param name="tarefaModel">Modelo da tarefa com as atualizações.</param>
        /// <param name="id">ID da tarefa a ser atualizada.</param>
        /// <returns>Tarefa atualizada.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            // Define o ID da tarefa no modelo antes de chamar o repositório.
            tarefaModel.Id = id;

            // Chama o repositório para atualizar a tarefa.
            TarefaModel tarefa = await _tarefaRepositorio.Atualizar(tarefaModel, id);

            // Retorna a tarefa atualizada.
            return Ok(tarefa);
        }

        /// <summary>
        /// Apaga uma tarefa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da tarefa a ser apagada.</param>
        /// <returns>Indica se a tarefa foi apagada com sucesso.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            // Chama o repositório para apagar a tarefa pelo ID.
            bool apagado = await _tarefaRepositorio.Apagar(id);

            // Retorna um indicativo se a tarefa foi apagada com sucesso.
            return Ok(apagado);
        }
    }
}