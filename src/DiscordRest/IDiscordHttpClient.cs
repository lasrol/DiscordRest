using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest
{
    /// <summary>
    /// Client created to handle HTTP request against the discord REST API
    /// </summary>
    public interface IDiscordHttpClient
    {
        /// <summary>
        /// Pass the request to the http connection, and handle the response and deserialization of the requested object
        /// </summary>
        /// <typeparam name="T">Data object the API returns</typeparam>
        /// <param name="method">Valid <see cref="HttpMethod"/></param>
        /// <param name="url">Relativ url for request</param>
        /// <param name="requestBody">any KeyValues to be passed along the request in the body</param>
        T Run<T>(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody);

        /// <summary>
        /// Pass the request to the http connection, and handle the response and deserialization of the requested object
        /// </summary>
        /// <typeparam name="T">Data object the API returns</typeparam>
        /// <param name="method">Valid <see cref="HttpMethod"/></param>
        /// <param name="url">Relativ url for request</param>
        /// <param name="requestBody">any KeyValues to be passed along the request in the body</param>
        Task<T> RunAsync<T>(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody);

        Task<ServiceResult> RunAsync(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody);
    }
}