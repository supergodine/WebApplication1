using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Integracao;
using WebApplication1.Integracao.Interface;
using WebApplication1.Integracao.Response;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador para manipulação de dados relacionados a CEP.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        /// <summary>
        /// Construtor da classe CepController.
        /// </summary>
        /// <param name="viaCepIntegracao">Instância da interface de integração com ViaCep.</param>
        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }

        /// <summary>
        /// Obtém os dados do endereço associados a um CEP.
        /// </summary>
        /// <param name="cep">CEP para consulta.</param>
        /// <returns>Dados do endereço associados ao CEP.</returns>
        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
            // Chama a interface de integração para obter os dados do CEP.
            var responseData = await _viaCepIntegracao.ObterDadosViaCep(cep);

            // Verifica se os dados foram encontrados.
            if (responseData == null)
            {
                return BadRequest("CEP Não encontrado!");
            }

            // Retorna os dados do endereço associados ao CEP.
            return Ok(responseData);
        }
    }
}