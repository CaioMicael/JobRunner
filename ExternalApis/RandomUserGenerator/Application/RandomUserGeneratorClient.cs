using JobRunner.Domain.DTO;
using JobRunner.ExternalApis.RandomUserGenerator.Domain.DTO;
using JobRunner.Interfaces;

namespace JobRunner.ExternalApis.RandomUserGenerator.Application
{
    public class RandomUserGeneratorClient : IExternalApiClient<RandomUserResponseDTO>
    {
        public ILogger<RandomUserGeneratorClient> _logger { get; set; }
        public const string URL_API = "https://randomuser.me/api/";

        public RandomUserGeneratorClient(ILogger<RandomUserGeneratorClient> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
        }

        public async Task<ExternalApiResponseDTO<RandomUserResponseDTO>> DoConsume() 
        {
            HttpClient client = new HttpClient();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            var response = await client.GetAsync(URL_API, cts.Token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RandomUserResponseDTO>(cancellationToken: cts.Token);
                return new ExternalApiResponseDTO<RandomUserResponseDTO>
                {
                    ResponseDTO = result,
                    StatusCode = response.StatusCode
                };
            }

            return new ExternalApiResponseDTO<RandomUserResponseDTO>
            {
                ResponseDTO = null,
                StatusCode = response.StatusCode
            };
        }

        public string GetApiDescription()
        {
            return "Random User Generator";
        }
    }
}
