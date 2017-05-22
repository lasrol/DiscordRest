using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DiscordRest
{
    public static class DiscordConstants
    {
        /// <summary>
        ///     Base url for discord API endpoint
        /// </summary>
        public const string BaseUrl = "https://discordapp.com/api";

        /// <summary>
        ///     Base url for discord CDN endpoint
        /// </summary>
        public const string CDNUrl = "https://cdn.discordapp.com";

        /// <summary>
        /// Version of DiscordRest library
        /// </summary>
        public static string Version = typeof(DiscordConstants).GetTypeInfo().Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        
        /// <summary>
        /// UserAgent value passed to discord on queries
        /// </summary>
        public static string UserAgent = $"DiscordBot (DiscordRest ,{Version})";

    }
}
