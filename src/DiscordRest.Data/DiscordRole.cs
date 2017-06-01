using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class DiscordRole : IDiscordDataObject
    {
        /// <summary>
        /// role id
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// integer representation of hexadecimal color code
        /// </summary>
        public int Color { get; set; }

        /// <summary>
        /// if this role is pinned in the user listing
        /// </summary>
        [JsonProperty("hoist")]
        public bool IsHoist { get; set; }

        /// <summary>
        /// position of this role
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// permission bit set
        /// </summary>
        public int Permissions { get; set; }

        /// <summary>
        /// whether this role is managed by an integration
        /// </summary>
        [JsonProperty("managed")]
        public bool IsManaged { get; set; }

        /// <summary>
        /// whether this role is mentionable
        /// </summary>
        [JsonProperty("mentionable")]
        public bool IsMentionable { get; set; }
    }
}