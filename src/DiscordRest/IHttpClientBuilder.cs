using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Configuration;

namespace DiscordRest
{
    public interface IHttpClientHelper
    {
        IHttpClientHelper Configure(Action<ConnectionOptions> options);
        IHttpClientHelper AddOptions(ConnectionOptions options);
        IHttpClientHelper AddPath(string url, HttpMethod httpMethod = null);
        Task<HttpResponseMessage> RunAsync();
    }
}
