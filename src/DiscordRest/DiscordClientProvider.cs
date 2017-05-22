using System;
using System.Collections.Generic;
using System.Text;
using DiscordRest.Services.Implementations;
using Microsoft.Extensions.Logging;

namespace DiscordRest
{
    /// <summary>
    /// Helper to build and create new <see cref="IDiscordClient" />
    /// </summary>
    public static class DiscordClientProvider
    {
        public static IDiscordClient Create()
        {
            return new DiscordClient(null, null, null, null, null, null);
        }

        public static IDiscordClient Create(ILoggerFactory loggerFactory)
        {
            return new DiscordClient(null, null, null, null, null, null);
        }

        public static IDiscordClient Create(ILogger logger)
        {
            return new DiscordClient(null, null, null, null, null, null);
        }
    }
}
