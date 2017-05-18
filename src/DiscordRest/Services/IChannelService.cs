using System.Threading.Tasks;

using DiscordRest.Models;

namespace DiscordRest.Services
{
    using DiscordRest.Data;

    public interface IChannelService
    {
        /// <summary>
        /// Get a channel by ID
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns><see cref="GuildChannel"/> object</returns>
        Task<GuildChannel> Get(ulong id);

        /// <summary>
        /// Update a channels settings. Requires the 'MANAGE_GUILD' permission for the guild. 
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns><see cref="GuildChannel"/> on success</returns>
        Task<GuildChannel> Modify(ulong id);

        /// <summary>
        /// Delete a guild channel, or close a private message. Requires the 'MANAGE_CHANNELS' permission for the guild.
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns><see cref="GuildChannel"/> object</returns>
        Task<GuildChannel> Delete(ulong id);

        /// <summary>
        /// Close a private message
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns>A <see cref="DMChannel"/> on success</returns>
        Task<DMChannel> CloseDM(ulong id);

        /// <summary>
        /// Services to query Discord Channel Messages endpoints
        /// </summary>
        IChannelMessageService Message { get; set; }

        /// <summary>
        /// Create a reaction for the message. This endpoint requires the 'READ_MESSAGE_HISTORY' permission to be present on the current user. Additionally, if nobody else has reacted to the message using this emoji, this endpoint requires the 'ADD_REACTIONS' permission to be present on the current user. 
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <param name="msgId">Message id</param>
        /// <param name="reactionId">emoji id</param>
        /// <returns><see cref="ServiceResult"/> for the operation</returns>
        Task<ServiceResult> CreateReaction(ulong id, ulong msgId, ulong reactionId);
    }
}