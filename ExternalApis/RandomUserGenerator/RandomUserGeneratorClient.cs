using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JobRunner.ExternalApis.RandomUserGenerator.DTO;
using JobRunner.Interfaces;

namespace JobRunner.ExternalApis.RandomUserGenerator
{
    public class RandomUserGeneratorClient : IExternalApiClient<RandomUserResponseDTO>
    {
        public ILogger<RandomUserGeneratorClient> _logger { get; set; }
        public const string URL_API = "https://randomuser.me/api/";

        public RandomUserGeneratorClient(ILogger<RandomUserGeneratorClient> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
        }

        public async Task<RandomUserResponseDTO> DoConsume() 
        {
            HttpClient client = new HttpClient();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            using (_logger.BeginScope("Iniciando requisição para RandomUserGenerator"))
            {
                var stopWatch = Stopwatch.StartNew();

                var response = await client.GetAsync(URL_API, cts.Token);

                stopWatch.Stop();
                _logger.LogInformation(
                    "Tempo de resposta {ElapsedMs} ms",
                    stopWatch.ElapsedMilliseconds
                );

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<RandomUserResponseDTO>(cancellationToken: cts.Token);

                    if (result == null)
                        throw new Exception("Não houve retorno da API");

                    return result;
                }

                throw new Exception($"Status Code: {response.StatusCode}");
            }
        }
    }
}
