using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CS_asked_client
{
    internal class RequestClient
    {
        private readonly string _baseUrl;
        private readonly HttpClient _client;

        public RequestClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36");
        }

        public async Task<HttpResponseMessage> Post(string path, Dictionary<string, string> data, string cookie = null)
        {
            if (cookie == null) _client.DefaultRequestHeaders.Add("Cookie", cookie);
            var encoded = new FormUrlEncodedContent(data);
            var response = await _client.PostAsync(_baseUrl + path, encoded).ConfigureAwait(false);

            return response;
        }
    }
}
