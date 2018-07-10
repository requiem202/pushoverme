using System.Net.Http;
using System.Threading.Tasks;

namespace PushoverMe
{
    public class HttpClientHandler : IHttpHandler
    {
        private static readonly System.Net.Http.HttpClient HttpClient;
        static HttpClientHandler()
        {
            HttpClient = new System.Net.Http.HttpClient();
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await HttpClient.PostAsync(url, content);
        }
    }
}