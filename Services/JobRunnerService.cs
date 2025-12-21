using System.Diagnostics;
using JobRunner.Domain.DTO;
using JobRunner.ExternalApis.RandomUserGenerator.Application;
using JobRunner.ExternalApis.RandomUserGenerator.Domain.DTO;

namespace JobRunner.Services
{
    /// <summary>
    /// Serviço responsável por rodar o JobRunner
    /// </summary>
    public class JobRunnerService
    {
        //private readonly IServiceProvider _provider;

        //public JobRunner(IServiceProvider provider)
        //{
        //    _provider = provider;
        //}

        //public void Run()
        //{
        //    var job = _provider.GetRequiredService<MeuJob>();
        //    job.Execute();
        //}
        public ILogger<RandomUserGeneratorClient> _logger { get; set; }
        public RandomUserGeneratorClient _random { get; set; }

        public JobRunnerService(RandomUserGeneratorClient random, ILogger<RandomUserGeneratorClient> logger)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RandomUserResponseDTO> Run()
        {
            _logger.LogInformation(
                "Iniciando requisição para API {ApiDescription}",
                _random.GetApiDescription()
            );

            var stopWatch = Stopwatch.StartNew();
            var apiResponse = await _random.DoConsume();
            stopWatch.Stop();

            _logger.LogInformation(
                "Tempo de resposta {ElapsedMs} ms",
                stopWatch.ElapsedMilliseconds
            );

            return apiResponse.ResponseDTO;
        }
    }
}
