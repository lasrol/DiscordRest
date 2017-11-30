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

        public const string ProjectUrl = "https://github.com/lasrol/DiscordRest";

        /// <summary>
        /// Version of DiscordRest library
        /// </summary>
        public static string Version = typeof(DiscordConstants).GetTypeInfo().Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        
        /// <summary>
        /// UserAgent value passed to discord on queries
        /// </summary>
        public static string UserAgent = $"DiscordBot ({ProjectUrl}, {Version})";

        /// <summary>
        /// Valid authentication Schemes
        /// </summary>
        public static class AuthenticationSchemes
        {
            public const string Bearer = "Bearer";
            public const string Basic = "Basic";
        }

    }
}
