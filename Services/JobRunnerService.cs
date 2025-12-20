using JobRunner.ExternalApis.RandomUserGenerator;
using JobRunner.ExternalApis.RandomUserGenerator.DTO;

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
        public RandomUserGeneratorClient _random { get; set; }

        public JobRunnerService(RandomUserGeneratorClient random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public Task<RandomUserResponseDTO> Run()
        {
            return _random.DoConsume();
        }
    }
}
