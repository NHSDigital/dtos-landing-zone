using System.Net;
using System.Text;
using Common;
using Grpc.Core;
using Microsoft.Azure.Functions.Worker.Http;

namespace Common;

public class CreateResponse : ICreateResponse
{
    public HttpResponseData CreateHttpResponse(HttpStatusCode statusCode, HttpRequestData httpRequestData, string responseBody = "")
    {
        var response = httpRequestData.CreateResponse(statusCode);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        byte[] data = Encoding.UTF8.GetBytes(responseBody);

        response.Body = new MemoryStream(data);
        return response;
    }
}