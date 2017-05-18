using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class GuildMember
    {
        /// <summary>
        /// <see cref="DiscordUser"/> object
        /// </summary>
        public DiscordUser User { get; set; }

        /// <summary>
        /// this users guild nickname (if one is set)
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// array of <see cref="DiscordRole"/> object id's
        /// </summary>
        public ICollection<DiscordRole> Roles { get; set; }

        /// <summary>
        /// date the user joined the guild
        /// </summary>
        public DateTime JoinedAt { get; set; }

        /// <summary>
        /// if the user is deafened
        /// </summary>
        [JsonProperty("deaf")]
        public bool IsDeaf { get; set; }

        /// <summary>
        /// if the user is muted
        /// </summary>
        [JsonProperty("mute")]
        public bool IsMute{ get; set; }
    }
}