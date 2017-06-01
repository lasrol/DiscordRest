using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DiscordRest.Utility
{
    public interface IHttpConnection : IDisposable
    {
        HttpRequestMessage Run();
        Task<HttpResponseMessage> RunAsync();
        void SetBearerToken(string token);

    }
}