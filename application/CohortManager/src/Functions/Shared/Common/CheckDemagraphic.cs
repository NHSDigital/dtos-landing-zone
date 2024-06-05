
using System.ComponentModel;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Model;

namespace Common
{
    public class CheckDemographic : ICheckDemographic
    {
        private readonly ICallFunction _callFunction;
        public readonly ILogger _logger;
        public CheckDemographic(ICallFunction callFunction, ILogger logger)
        {
            _callFunction = callFunction;
            _logger = logger;
        }

        public async Task<Demographic> GetDemographicAsync(string NhsId, string DemographicFunctionURI)
        {
            var DemographicData = await _callFunction.SendGet(DemographicFunctionURI, JsonSerializer.Serialize(NhsId));
            if (DemographicData.StatusCode == HttpStatusCode.OK)
            {
                var demographicDataResponse = new Demographic();
                using (var reader = new StreamReader(DemographicData.GetResponseStream()))
                {
                    var dataRead = reader.ReadToEnd();
                    demographicDataResponse = JsonSerializer.Deserialize<Demographic>(dataRead);
                }
                return demographicDataResponse;
            }
            _logger.LogError($"The demographic function has failed with NHSId {NhsId}");
            return null;
        }

        public async Task<bool> PostDemographicDataAsync(Participant participant, string DemographicFunctionURI)
        {
            var response = await _callFunction.SendPost(DemographicFunctionURI, JsonSerializer.Serialize(participant));
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }
            return true;
        }
    }
}