using WebApplication1.Integracao.Interface;
using WebApplication1.Integracao.Refit;
using WebApplication1.Integracao.Response;

namespace WebApplication1.Integracao
{
    /// <summary>
    /// Implementação da interface de integração com a API ViaCep usando Refit.
    /// </summary>
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;

        /// <summary>
        /// Construtor da classe ViaCepIntegracao.
        /// </summary>
        /// <param name="viaCepIntegracaoRefit">Instância da interface Refit para integração com a API ViaCep.</param>
        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
        {
            _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }

        /// <summary>
        /// Obtém dados de endereço da API ViaCep com base no CEP.
        /// </summary>
        /// <param name="cep">CEP a ser consultado.</param>
        /// <returns>Objeto contendo os dados do endereço.</returns>
        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            // Chama o método da interface Refit para obter os dados do endereço.
            var responseData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);

            // Verifica se a resposta é bem-sucedida antes de retornar os dados.
            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            // Retorna null em caso de falha na integração.
            return null;
        }
    }
}