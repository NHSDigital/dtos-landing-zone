using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

using System.Text;
using Model;
using System.Text.Json;
using Data.Database;
using Microsoft.EntityFrameworkCore;
using Common;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace updateParticipant
{
    public class UpdateParticipantFunction
    {
        private readonly ILogger<UpdateParticipantFunction> _logger;
        private readonly ICreateResponse _createResponse;
        private readonly ICallFunction _callFunction;

        private readonly ICheckDemographic _checkDemographic;

        private readonly ICreateParticipant _createParticipant;

        public UpdateParticipantFunction(ILogger<UpdateParticipantFunction> logger, ICreateResponse createResponse, ICallFunction callFunction, ICheckDemographic checkDemographic, ICreateParticipant createParticipant)
        {
            _logger = logger;
            _createResponse = createResponse;
            _callFunction = callFunction;
            _checkDemographic = checkDemographic;
            _createParticipant = createParticipant;
        }

        [Function("updateParticipant")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# Update called.");
            HttpWebResponse createResponse;

            // convert body to json and then deserialize to object
            string postdata = "";
            using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8))
            {
                postdata = reader.ReadToEnd();
            }
            var participant = JsonSerializer.Deserialize<Participant>(postdata);

            // Any validation or decisions go in here

            try
            {
                var demographicData = await _checkDemographic.GetDemographicAsync(participant.NHSId, Environment.GetEnvironmentVariable("DemographicURIGet"));
                participant = _createParticipant.CreateResponseParticipantModel(participant, demographicData);
                if (demographicData == null)
                {
                    _logger.LogInformation("demographic function failed");
                }

                var json = JsonSerializer.Serialize(participant);
                createResponse = await _callFunction.SendPost(Environment.GetEnvironmentVariable("UpdateParticipant"), json);

                if (createResponse.StatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation("participant updated");
                    return _createResponse.CreateHttpResponse(HttpStatusCode.OK, req);
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Unable to call function.\nMessage:{ex.Message}\nStack Trace: {ex.StackTrace}");
            }

            _logger.LogInformation("the user has not been updated due to a bad request");
            return _createResponse.CreateHttpResponse(HttpStatusCode.BadRequest, req);

        }
    }
}
