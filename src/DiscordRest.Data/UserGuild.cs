using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class UserGuild
    {
        /// <summary>
        /// 	guild id
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// 	guild.name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     guild.icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 	true if the user is an owner of the guild
        /// </summary>
        [JsonProperty("owner")]
        public bool IsOwner { get; set; }

        /// <summary>
        /// 	bit wise of the user's enabled/disabled permissions
        /// </summary>
        public uint Permissions { get; set; }
    }
}
