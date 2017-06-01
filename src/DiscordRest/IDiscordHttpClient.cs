using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest
{
    public interface IDiscordHttpClient
    {
        T Run<T>(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody);
        Task<T> RunAsync<T>(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody);
    }
}