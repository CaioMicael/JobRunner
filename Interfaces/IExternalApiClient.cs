using JobRunner.Domain.DTO;

namespace JobRunner.Interfaces
{
    public interface IExternalApiClient<TResponse>
    {
        /// <summary>
        /// Realiza o consumo da API e retorna um DTO pronto com o resultado
        /// </summary>
        /// <returns>DTO</returns>
        Task<ExternalApiResponseDTO<TResponse>> DoConsume();

        /// <summary>
        /// Retorna a descrição da API sendo consumida, para fins de log
        /// </summary>
        /// <returns>string</returns>
        string GetApiDescription();
    }
}
