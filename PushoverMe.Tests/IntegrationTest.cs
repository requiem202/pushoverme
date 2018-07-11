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
        public async Task Send_Default_Got_Ok()
        {
            var client = new PushoverClient(ApiKey);
            
            var message = client.NewMessage("Hello world");
            var response = await client.SendAsync(message, UserKey);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
        [Fact]
        public async Task Send_With_Sound_Got_Ok()
        {
            var client = new PushoverClient(ApiKey);
            
            var message = client.NewMessageWithSound("Hello world", Sound.CashRegister);
            var response = await client.SendAsync(message, UserKey);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task Send_Multiple_Got_Ok()
        {
            var client = new PushoverClient(ApiKey);
            
            var message = client.NewMessage("Hello world");
            var responses = await client.SendAsync(message, UserKey, UserKey);

            foreach (var response in responses)
            {
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            }
        }
    }
}