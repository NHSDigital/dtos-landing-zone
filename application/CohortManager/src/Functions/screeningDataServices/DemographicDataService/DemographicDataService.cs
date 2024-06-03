using System.Data.Common;
using System.Net;
using System.Text;
using System.Text.Json;
using Common;
using Data.Database;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Model;

namespace screeningDataServices
{
    public class DemographicDataService
    {
        private readonly ILogger<DemographicDataService> _logger;
        private readonly ICreateResponse _createResponse;
        private ICreateDemographicData _createDemographicData;

        public DemographicDataService(ILogger<DemographicDataService> logger, ICreateResponse createResponse, ICreateDemographicData createDemographicData)
        {
            _logger = logger;
            _createResponse = createResponse;
            _createDemographicData = createDemographicData;
        }

        [Function("DemographicDataService")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            string requestBody = "";
            var participantData = new Participant();

            using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();
                participantData = JsonSerializer.Deserialize<Participant>(requestBody);
            }

            var created = _createDemographicData.InsertDemographicData(participantData);
            if (!created)
            {
                return _createResponse.CreateHttpResponse(HttpStatusCode.InternalServerError, req);
            }
            return _createResponse.CreateHttpResponse(HttpStatusCode.OK, req);
        }
    }
}
