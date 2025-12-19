using JobRunner.ExternalApis.RandomUserGenerator.DTO;
using JobRunner.Interfaces;

namespace JobRunner.ExternalApis.RandomUserGenerator
{
    public class RandomUserGeneratorConsumer : IExternalApiConsumer<RandomUserResponseDTO>
    {
        public string URL_API { get; } = "https://randomuser.me/api/";

        public RandomUserResponseDTO DoConsume() 
        {

        }
    }
}
