using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Models;

namespace DiscordRest.Services
{
    using DiscordRest.Data;

    public interface IGuildMemberService
    {
        /// <summary>
        /// Get a guild member
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="userId">user id</param>
        /// <returns>A <see cref="GuildMember"/></returns>
        Task<GuildMember> GetAsync(ulong id, ulong userId);

        /// <summary>
        /// Get all guild members
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>Enumerable of <see cref="GuildMember"/></returns>
        Task<IEnumerable<GuildMember>> GetAsync(ulong id);

        /// <summary>
        /// Adds a user to the guild, provided you have a valid 'OAuth2' access token for the user with the  scope.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="userId">user id</param>
        /// <returns>A <see cref="GuildMember"/></returns>
        Task<GuildMember> AddAsync(ulong id, ulong userId);

        /// <summary>
        /// Modify guild member
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="userId">user id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> ModifyAsync(ulong id, ulong userId);

        /// <summary>
        /// Modifies the nickname of the current user in a guild.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> ModifyCurrentUserNickAsync(ulong id);

        /// <summary>
        /// Adds a guild member to specified role. Requires the 'MANAGE_ROLES' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="userId">user id</param>
        /// <param name="roleId">role id</param>
        /// <returns>True on success</returns>
        Task<ServiceResult> AddToRoleAsync(ulong id, ulong userId, ulong roleId);

        /// <summary>
        /// Removes a guild member from specified role. Requires the 'MANAGE_ROLES' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="userId">user id</param>
        /// <param name="roleId">role id</param>
        /// <returns>True on success</returns>
        Task<ServiceResult> RemoveFromRoleAsync(ulong id, ulong userId, ulong roleId);

        /// <summary>
        /// Remove a member from the guild.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="userId">user id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> RemoveAsync(ulong id, ulong userId);
    }
}