using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PushoverMe.Tests
{
    public class UnitTest
    {
        [Fact]
        public async Task Send_Get_Ok()
        {
            var client = new PushoverClient(string.Empty);
            PushoverClient.HttpHandler = new MockHandler();
            
            var message = client.NewMessage("Hello world");
            var response = await client.SendAsync(message, string.Empty);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
    }
}