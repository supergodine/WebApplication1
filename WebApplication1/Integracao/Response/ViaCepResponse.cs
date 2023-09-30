namespace WebApplication1.Integracao.Response
{
    /// <summary>
    /// Representa a resposta da API ViaCep contendo dados de endereço.
    /// </summary>
    public class ViaCepResponse
    {
        /// <summary>
        /// Obtém ou define o CEP.
        /// </summary>
        public string? Cep { get; set; }

        /// <summary>
        /// Obtém ou define o logradouro.
        /// </summary>
        public string? Logradouro { get; set; }

        /// <summary>
        /// Obtém ou define o complemento.
        /// </summary>
        public string? Complemento { get; set; }

        /// <summary>
        /// Obtém ou define o bairro.
        /// </summary>
        public string? Bairro { get; set; }

        /// <summary>
        /// Obtém ou define a localidade.
        /// </summary>
        public string? Localidade { get; set; }

        /// <summary>
        /// Obtém ou define a UF (Unidade Federativa).
        /// </summary>
        public string? Uf { get; set; }

        /// <summary>
        /// Obtém ou define o código IBGE.
        /// </summary>
        public string? Ibge { get; set; }

        /// <summary>
        /// Obtém ou define o código GIA.
        /// </summary>
        public string? Gia { get; set; }

        /// <summary>
        /// Obtém ou define o DDD (Código de Discagem Direta).
        /// </summary>
        public string? Ddd { get; set; }

        /// <summary>
        /// Obtém ou define o código SIAFI.
        /// </summary>
        public string? Siafi { get; set; }
    }
}