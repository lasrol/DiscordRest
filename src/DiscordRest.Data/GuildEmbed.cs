using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class GuildEmbed : IDiscordDataObject
    {
        /// <summary>
        ///     the embed channel id
        /// </summary>
        public ulong ChannelId { get; set; }

        /// <summary>
        ///     if the embed is enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool IsEnabled { get; set; }
    }
}
