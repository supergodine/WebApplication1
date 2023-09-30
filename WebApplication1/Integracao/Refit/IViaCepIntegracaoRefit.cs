using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Refit;
using WebApplication1.Integracao.Response;

namespace WebApplication1.Integracao.Refit
{
    /// <summary>
    /// Interface para integração com a API ViaCep usando Refit para obter dados de endereço por CEP.
    /// </summary>
    public interface IViaCepIntegracaoRefit
    {
        /// <summary>
        /// Obtém dados de endereço da API ViaCep com base no CEP usando Refit.
        /// </summary>
        /// <param name="cep">CEP a ser consultado.</param>
        /// <returns>Resposta da API contendo os dados do endereço.</returns>
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}