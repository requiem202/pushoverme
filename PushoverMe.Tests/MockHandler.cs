using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PushoverMe.Tests
{
    public class MockHandler : IHttpHandler
    {
        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}