using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRest.Configuration
{
    /// <summary>
    /// Configuration used to connect to Discord services
    /// </summary>
    public class HttpConnectionOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
