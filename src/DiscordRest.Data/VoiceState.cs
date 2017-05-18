using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class VoiceState
    {
        /// <summary>
        /// the guild id this voice state is for
        /// </summary>
        public ulong? GuildId { get; set; }

        /// <summary>
        /// the channel id this user is connected to
        /// </summary>
        public ulong ChannelId { get; set; }

        /// <summary>
        /// the user id this voice state is for
        /// </summary>
        public ulong UserId { get; set; }

        /// <summary>
        /// the session id for this voice state
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// whether this user is deafened by the server
        /// </summary>
        [JsonProperty("deaf")]
        public bool IsDeaf { get; set; }

        /// <summary>
        /// whether this user is muted by the server
        /// </summary>
        [JsonProperty("mute")]
        public bool IsMute { get; set; }

        /// <summary>
        /// whether this user is locally deafened
        /// </summary>
        [JsonProperty("self_deaf")]
        public bool IsSelfDeaf { get; set; }

        /// <summary>
        /// whether this user is locally muted
        /// </summary>
        [JsonProperty("self_mute")]
        public bool IsSelfMute { get; set; }

        /// <summary>
        /// whether this user is muted by the current user
        /// </summary>
        [JsonProperty("suppress")]
        public bool IsSuppressed { get; set; }
    }
}