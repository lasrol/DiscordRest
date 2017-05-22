using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;


namespace DiscordRest.Services
{
    public interface IGuildChannelService
    {
        /// <summary>
        /// Get all channels in the guild.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>Enumerable of <see cref="GuildChannel"/></returns>
        Task<IEnumerable<GuildChannel>> GetAsync(ulong id);

        /// <summary>
        /// Create a new channel object for the guild. Requires the 'MANAGE_CHANNELS' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>The new <see cref="GuildChannel"/> on success</returns>
        Task<GuildChannel> CreateAsync(ulong id);

        /// <summary>
        /// Modify the positions of a set of channel objects for the guild. Requires 'MANAGE_CHANNELS' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="channelId">channel id</param>
        /// <param name="position">wanted position</param>
        /// <returns>All <see cref="GuildChannel"/> on success</returns>
        Task<IEnumerable<GuildChannel>> ModifyPositionsAsync(ulong id, ulong channelId, int position);
    }
}