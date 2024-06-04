namespace Common;

using System.Net;
using System.Text;

public interface ICallFunction
{
    Task<HttpWebResponse> SendPost(string url, string postData);
    Task<HttpWebResponse> SendGet(string url, string GETData);
}
