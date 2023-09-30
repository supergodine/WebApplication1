using Microsoft.Data.SqlClient.Server;
using WebApplication1.Integracao.Response;

namespace WebApplication1.Integracao.Interface
{
    /// <summary>
    /// Interface para integração com a API ViaCep para obter dados de endereço por CEP.
    /// </summary>
    public interface IViaCepIntegracao
    {
        /// <summary>
        /// Obtém dados de endereço da API ViaCep com base no CEP.
        /// </summary>
        /// <param name="cep">CEP a ser consultado.</param>
        /// <returns>Objeto contendo os dados do endereço.</returns>
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}






