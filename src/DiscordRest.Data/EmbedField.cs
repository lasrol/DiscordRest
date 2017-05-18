using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class EmbedField
    {
        /// <summary>
        /// name of the field
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// value of the field
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// whether or not this field should display inline
        /// </summary>
        [JsonProperty("inline")]
        public bool IsInline { get; set; } 
    }
}