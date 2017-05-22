using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Services
{
    public interface IGuildBanService
    {
        /// <summary>
        /// Get all guild bans. Requires the 'BAN_MEMBERS' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>Enumerable of <see cref="DiscordUser"/></returns>
        Task<IEnumerable<DiscordUser>> GetAsync(ulong id);

        /// <summary>
        /// Adds a guild ban, and optionally delete previous messages sent by the banned user. Requires the 'BAN_MEMBERS' permission. 
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="userId">user id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> AddAsync(ulong id, ulong userId);

        /// <summary>
        /// Remove the ban for a user. Requires the 'BAN_MEMBERS' permissions.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="userId">user id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> RemoveAsync(ulong id, ulong userId);
    }
}