using System.Net.Http;
using System.Threading.Tasks;

namespace PushoverMe
{
    public interface IHttpHandler
    {
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}