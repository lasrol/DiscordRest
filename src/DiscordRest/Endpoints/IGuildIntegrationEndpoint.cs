using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Endpoints
{   
    public interface IGuildIntegrationEndpoint
    {
        /// <summary>
        /// Get all integrations for the specified guild. Requires the 'MANAGE_GUILD' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>Enumerable of <see cref="GuildIntegrations"/></returns>
        Task<IEnumerable<GuildIntegrations>> GetAsync(ulong id);

        /// <summary>
        /// Attach an integration object from the current user to the guild. Requires the 'MANAGE_GUILD' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> CreateAsync(ulong id);

        /// <summary>
        /// Modify the behavior and settings of a integration object for the guild. Requires the 'MANAGE_GUILD' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="integrationId">integration id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> ModifyAsync(ulong id, ulong integrationId);

        /// <summary>
        /// Delete the specified integration from the guild. Requires the 'MANAGE_GUILD' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="integrationId">integration id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> DeleteAsync(ulong id, ulong integrationId);

        /// <summary>
        /// Sync an integration. Requires the 'MANAGE_GUILD' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="integrationId">integration id</param>
        /// <returns>A <see cref="ServiceResult"/></returns>
        Task<ServiceResult> SyncAsync(ulong id, ulong integrationId);
    }
}