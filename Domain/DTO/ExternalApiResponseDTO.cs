using System.Net;

namespace JobRunner.Domain.DTO
{
    public class ExternalApiResponseDTO<TResponse>
    {
        public TResponse? ResponseDTO { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
