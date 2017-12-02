using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class UserGuild : IDiscordDataObject
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
        /// Url to the guild icon
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// 	true if the user is an owner of the guild
        /// </summary>
        [JsonProperty("owner")]
        public bool IsOwner { get; set; }

        [JsonProperty("Permissions")]
        private uint Permissions { get; set; }

        /// <summary>
        ///     Users guild permissions
        /// </summary>
        public Permissions GuildPermissions => new Permissions(Permissions);
    }
}
