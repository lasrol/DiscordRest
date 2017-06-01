using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class VoiceRegion : IDiscordDataObject
    {
        /// <summary>
        /// 	unique ID for the region
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 	name of the region
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 	an example hostname for the region
        /// </summary>
        public string SampleHostname { get; set; }

        /// <summary>
        /// 	an example port for the region
        /// </summary>
        public int SamplePort { get; set; }

        /// <summary>
        /// 	true if this is a vip-only server
        /// </summary>
        [JsonProperty("vip")]
        public bool IsVIP { get; set; }

        /// <summary>
        ///     true for a single server that is closest to the current user's client
        /// </summary>
        [JsonProperty("optimal")]
        public bool IsOptimal { get; set; }

        /// <summary>
        ///     whether this is a deprecated voice region (avoid switching to these)
        /// </summary>
        [JsonProperty("deprecated")]
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// 	whether this is a custom voice region (used for events/etc)
        /// </summary>
        [JsonProperty("custom")]
        public bool IsCustom { get; set; }
    }
}