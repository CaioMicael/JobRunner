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
        public const string URL_API = "https://randomuser.me/api/";

        public async Task<RandomUserResponseDTO> DoConsume() 
        {
            HttpClient client = new HttpClient();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var response = await client.GetAsync(URL_API,cts.Token);

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
