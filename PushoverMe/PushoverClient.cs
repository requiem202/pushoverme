using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PushoverMe
{
    public class PushoverClient
    {
        public static IHttpHandler HttpHandler;
        private const string RequestUri = "https://api.pushover.net/1/messages.json";
        private readonly string _appToken;

        static PushoverClient()
        {
            HttpHandler = new HttpClientHandler();
        }
        
        public PushoverClient(string appToken)
        {
            _appToken = appToken;
        }

        public PushoverMessage NewMessage(string message)
        {
            return new PushoverMessage(message);
        }
        
        public async Task<HttpResponseMessage> SendAsync(PushoverMessage message, string userKey)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("token", _appToken));
            parameters.Add(new KeyValuePair<string, string>("user", userKey));
            parameters.Add(new KeyValuePair<string, string>("message", message.Text));
            
            var content = new System.Net.Http.FormUrlEncodedContent(parameters);

            var response = await HttpHandler.PostAsync(RequestUri, content);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            return response;
        }
    }
}