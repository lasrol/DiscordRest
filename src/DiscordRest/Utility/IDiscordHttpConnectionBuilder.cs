using System;
using System.Collections.Generic;
using System.Net.Http;
using DiscordRest.Configuration;

namespace DiscordRest.Utility
{
    public interface IHttpConnectionBuilder
    {
        IHttpConnectionBuilder Configure(Action<HttpConnectionOptions> options);
        IHttpConnectionBuilder AddOptions(HttpConnectionOptions options);
        IHttpConnectionBuilder AddMethod(HttpMethod httpMethod);
        IHttpConnectionBuilder AddParams(IEnumerable<KeyValuePair<string, string>> content);
        IHttpConnectionBuilder AddToken(string token);
        IHttpConnection Build(string authScheme);
        IHttpConnectionBuilder AddPath(string url);
    }
}
