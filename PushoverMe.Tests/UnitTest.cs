using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PushoverMe.Tests
{
    public class UnitTest
    {
        [Fact]
        public async Task Send_Default_Got_Ok()
        {
            var client = new PushoverClient(string.Empty);
            PushoverClient.HttpHandler = new MockHandler();
            
            var message = client.NewMessage("Hello world");
            var response = await client.SendAsync(message, string.Empty);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
        [Fact]
        public async Task Send_With_Sound_Got_Ok()
        {
            var client = new PushoverClient(string.Empty);
            PushoverClient.HttpHandler = new MockHandler();
            
            var message = client.NewMessageWithSound("Hello world", Sound.CashRegister);
            var response = await client.SendAsync(message, string.Empty);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
        [Fact]
        public async Task Send_Multiple_Got_Ok()
        {
            var client = new PushoverClient(string.Empty);
            PushoverClient.HttpHandler = new MockHandler();
            
            var message = client.NewMessage("Hello world");
            var responses = await client.SendAsync(message, string.Empty, string.Empty);

            foreach (var response in responses)
            {
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            }
        }
    }
}