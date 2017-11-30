using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Endpoints
{
    /// <summary>
    /// queries and services for Guild Roles
    /// </summary>
    public interface IGuildRoleEndpoint
    {
        /// <summary>
        /// Gets all roles in the guild. Requires the 'MANAGE_ROLES' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>Enumerable <see cref="DiscordRole"/></returns>
        Task<IEnumerable<DiscordRole>> GetAsync(ulong id);

        /// <summary>
        /// Create a new role for the guild. Requires the 'MANAGE_ROLES' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>The new <see cref="DiscordRole"/> on success</returns>
        Task<DiscordRole> AddAsync(ulong id);

        /// <summary>
        /// Modify the positions of a set of role objects for the guild. Requires the 'MANAGE_ROLES' permission. 
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="roleId">role id</param>
        /// <returns>Enumerable of <see cref="DiscordRole"/> on success</returns>
        Task<IEnumerable<DiscordRole>> ModifyPositionAsync(ulong id, ulong roleId);

        /// <summary>
        /// Delete a guild role. Requires the 'MANAGE_ROLES' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="roleId">role id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> DeleteAsync(ulong id, ulong roleId);
    }
}