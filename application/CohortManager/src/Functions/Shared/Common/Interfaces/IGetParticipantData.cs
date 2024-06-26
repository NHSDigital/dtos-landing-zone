namespace Common;

using Model;
using Microsoft.Azure.Functions.Worker.Http;

public interface IGetParticipantData
{
    public Task<Participant> GetParticipantAsync(string NHSId, string ParticipantFunctionURI);
    public Task<Participant> GetParticipantDetails(HttpRequestData req);
}
