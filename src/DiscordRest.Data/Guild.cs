using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class Guild : IDiscordDataObject
    {
        /// <summary>
        /// guild id
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// guild name (2-100 characters)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// icon hash
        /// </summary>
        public string  Icon { get; set; }

        /// <summary>
        /// splash hash
        /// </summary>
        public string Splash { get; set; }

        /// <summary>
        /// id of owner
        /// </summary>
        public ulong OwnerId { get; set; }

        /// <summary>
        /// {voice_region.id}
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// id of afk channel
        /// </summary>
        public ulong AfkChannelId { get; set; }

        /// <summary>
        /// afk timeout in seconds
        /// </summary>
        public int AfkTimeout { get; set; }

        /// <summary>
        /// is this guild embeddable (e.g. widget)
        /// </summary>
        [JsonProperty("embed_enabled")]
        public bool IsEmbedEnabled { get; set; }

        /// <summary>
        /// 	id of embedded channel
        /// </summary>
        public ulong EmbedChannelId { get; set; }

        /// <summary>
        /// level of verification
        /// </summary>
        public int VerificationLevel { get; set; }

        /// <summary>
        /// default message notifications level
        /// </summary>
        public int DefaultMessageNotifications { get; set; }

        /// <summary>
        /// array of <see cref="DiscordRole"/> objects
        /// </summary>
        public ICollection<DiscordRole> Roles { get; set; }

        /// <summary>
        /// array of <see cref="Emoji"/> objects
        /// </summary>
        public ICollection<Emoji> Emojis { get; set; }

        /// <summary>
        /// 	array of guild <see cref="DiscordFeature"/>
        /// </summary>
        public ICollection<string> Features { get; set; }

        /// <summary>
        /// required MFA level for the guild
        /// </summary>
        public int MFALevel { get; set; }

        /// <summary>
        /// date this guild was joined at
        /// </summary>
        public DateTime JoinedAt { get; set; }

        /// <summary>
        /// whether this is considered a large guild
        /// </summary>
        [JsonProperty("large")]
        public bool IsLarge { get; set; }

        /// <summary>
        /// is this guild unavailable
        /// </summary>
        [JsonProperty("unavailable")]
        public bool IsUnavailable { get; set; }

        /// <summary>
        /// 	total number of members in this guild
        /// </summary>
        public int MemberCount { get; set; }

        /// <summary>
        /// array of <see cref="VoiceState"/> objects (without the guild_id key)
        /// </summary>
        public ICollection<VoiceState> VoiceStates { get; set; }

        /// <summary>
        /// array of <see cref="GuildMember" /> objects
        /// </summary>
        public ICollection<GuildMember> Members { get; set; }

        /// <summary>
        /// array of <see cref="GuildChannel"/> objects
        /// </summary>
        public ICollection<GuildChannel> Channels { get; set; }
    }
}
