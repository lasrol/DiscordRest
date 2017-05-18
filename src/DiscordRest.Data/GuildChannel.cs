using System.Collections.Generic;

namespace DiscordRest.Data
{
    /// <summary>
    /// Guild channels represent an isolated set of users and messages within a Guild.
    /// </summary>
    public class GuildChannel 
    {
        /// <summary>
        /// the id of this channel (will be equal to the guild if it's the "general" channel)
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// the id of the guild
        /// </summary>
        public ulong GuildId { get; set; }

        /// <summary>
        /// the name of the channel (2-100 characters)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// "text" or "voice"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// sorting position of the channel
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// should always be false for guild channels
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// an array of <see cref="Overwrite"/> objects
        /// </summary>
        public ICollection<Overwrite> PermissionOverwrites { get; set; }

        /// <summary>
        /// the channel topic (0-1024 characters)
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// the id of the last message sent in this channel
        /// </summary>
        public ulong LastMessageId { get; set; }

        /// <summary>
        /// the bit rate (in bits) of the voice channel
        /// </summary>
        public int BitRate { get; set; }

        /// <summary>
        /// the user limit of the voice channel
        /// </summary>
        public int UserLimit { get; set; }
    }   
}