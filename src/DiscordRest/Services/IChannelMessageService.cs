using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Services
{
    public interface IChannelMessageService
    {
        /// <summary>
        /// Gets a specific message in the channel. If operating on a guild channel, this endpoints requires the 'READ_MESSAGE_HISTORY' permission to be present on the current user.
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <param name="msgId">Message id</param>
        /// <returns>The specified <see cref="Message"/></returns>
        Task<Message> GetMessage(ulong id, ulong msgId);

        /// <summary>
        /// Gets messages for a channel. If operating on a guild channel, this endpoint requires the 'READ_MESSAGES' permission to be present on the current user.  
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns>Enumerable of <see cref="Message"/> for the specified guild</returns>
        Task<IEnumerable<Message>> GetMessages(ulong id);

        /// <summary>
        /// Post a message to a guild text or DM channel. If operating on a guild channel, this endpoint requires the 'SEND_MESSAGES' permission to be present on the current user. 
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns>A <see cref="Message"/></returns>
        Task<Message> CreateMessage(ulong id);
    }
}