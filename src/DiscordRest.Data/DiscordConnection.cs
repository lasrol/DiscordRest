using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class DiscordConnection
    {
        /// <summary>
        /// id of the connection account
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the username of the connection account
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the service of the connection (twitch, youtube)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// whether the connection is revoked
        /// </summary>
        [JsonProperty("revoked")]
        public bool IsRevoked { get; set; }
    }
}