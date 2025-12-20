namespace JobRunner.Interfaces
{
    public interface IExternalApiClient<TResponse>
    {
        /// <summary>
        /// Realiza o consumo da API e retorna um DTO pronto com o resultado
        /// </summary>
        /// <returns>DTO</returns>
        Task<TResponse> DoConsume();
    }
}
