using System.Collections.Generic;

namespace DiscordRest.Data
{
    public class Emoji
    {
        /// <summary>
        /// emoji id
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// emoji name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see cref="DiscordRole"/> this emoji is active for
        /// </summary>
        public ICollection<DiscordRole> Roles { get; set; }

        /// <summary>
        /// whether this emoji must be wrapped in colons
        /// </summary>
        public bool RequireColons { get; set; }

        /// <summary>
        /// whether this emoji is managed
        /// </summary>
        public bool IsManaged { get; set; }
    }
}