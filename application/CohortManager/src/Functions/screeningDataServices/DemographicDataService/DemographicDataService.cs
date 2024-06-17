using System.Net;
using System.Text;
using System.Text.Json;
using Common;
using Data.Database;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Model;

namespace ScreeningDataServices;

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
        // parse through the HTTP request
        string requestBody = "";
        Participant participantData = new Participant();

        try
        {
            if (req.Method == "POST")
            {
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
            }
            else
            {
                string Id = req.Query["Id"];

                var demographicData = _createDemographicData.GetDemographicData(Id);
                if (demographicData != null)
                {
                    var responseBody = JsonSerializer.Serialize<Demographic>(demographicData);

                    return _createResponse.CreateHttpResponse(HttpStatusCode.OK, req, responseBody);
                }
                return _createResponse.CreateHttpResponse(HttpStatusCode.NotFound, req, "Participant not found");
            }

        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has occoured while inserting data {ex.Message}");
            return _createResponse.CreateHttpResponse(HttpStatusCode.InternalServerError, req);
        }

        return _createResponse.CreateHttpResponse(HttpStatusCode.OK, req);
    }
}
