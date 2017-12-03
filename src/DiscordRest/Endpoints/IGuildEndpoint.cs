using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Endpoints
{
    public interface IGuildEndpoint
    {
        /// <summary>
        /// Returns the guild object for the given id.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>A <see cref="Guild"/></returns>
        Task<Guild> GetAsync(ulong id);

        /// <summary>
        /// Create a new guild.
        /// </summary>
        /// <returns>Returns a <see cref="Guild"/> on success</returns>
        Task<Guild> CreateAsync();

        /// <summary>
        /// Modify a guild's settings. 
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>Updated <see cref="Guild"/> on success</returns>
        Task<Guild> ModifyAsync(ulong id);

        /// <summary>
        /// Delete a guild permanently. User must be owner. 
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>The <see cref="Guild"/> object on success</returns>
        Task<Guild> DeleteAsync(ulong id);

        /// <summary>
        /// All guild channel services
        /// </summary>
        IGuildChannelEndpoint Channel { get; }

        /// <summary>
        /// All guild member services
        /// </summary>
        IGuildMemberEndpoint Member { get; }

        /// <summary>
        /// All guild ban services
        /// </summary>
        IGuildBanEndpoint Ban { get; }

        /// <summary>
        /// All guild role services
        /// </summary>
        IGuildRoleEndpoint Role { get; }

        /// <summary>
        /// All guild prune services
        /// </summary>
        IGuildPruneEndpoint Prune { get; }

        /// <summary>
        /// this returns VIP servers when the guild is VIP-enabled.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>Enumerable of <see cref="VoiceRegion"/></returns>
        Task<IEnumerable<VoiceRegion>> GetVoiceRegionsAsync(ulong id);

        /// <summary>
        /// Get invites for the specified guild. Requires the 'MANAGE_GUILD' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <returns>Enumerable of <see cref="Invite"/></returns>
        Task<IEnumerable<Invite>> GetInvitesAsync(ulong id);

        /// <summary>
        /// All guild integration services
        /// </summary>
        IGuildIntegrationEndpoint Integration { get; }

        /// <summary>
        /// All guild embed services
        /// </summary>
        IGuildEmbedEndpoint Embed { get; }
    }
}