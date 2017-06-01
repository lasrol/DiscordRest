using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class Reaction : IDiscordDataObject
    {
        /// <summary>
        ///     times this emoji has been used to react
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        ///     whether the current user reacted using this emoji
        /// </summary>
        [JsonProperty("me")]
        public bool HasReacted { get; set; }

        /// <summary>
        ///     emoji information
        /// </summary>
        public Emoji Emoji { get; set; }
    }
}