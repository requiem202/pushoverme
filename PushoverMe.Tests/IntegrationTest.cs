using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PushoverMe.Tests
{
    public class IntegrationTest
    {
        private const string ApiKey = "";
        private const string UserKey = "";
        
        [Fact]
        public async Task Send_Get_Ok()
        {
            var client = new PushoverClient(ApiKey);
            var message = client.NewMessage("Hello world");
            var response = await client.SendAsync(message, UserKey);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
    }
}