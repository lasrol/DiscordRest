using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Models;
using DiscordRest.Data;

namespace DiscordRest.Services
{
    public interface IUserService
    {
        /// <summary>
        /// For OAuth2, this requires the identify scope, which will return the object without an email, and optionally the email scope, which returns the object with an email.
        /// </summary>
        /// <returns>the <see cref="DiscordUser"/> object of the requested account. </returns>
        Task<DiscordUser> GetCurrent();

        /// <summary>
        /// Gets a <see cref="DiscordUser" /> for the provided ID/>
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>a <see cref="DiscordUser"/></returns>
        Task<DiscordUser> Get(ulong id);

        /// <summary>
        /// Modify own user account settings
        /// </summary>
        /// <returns>Returns a <see cref="DiscordUser"/> object on success.</returns>
        Task<DiscordUser> ModifyCurrent();

        /// <summary>
        /// Gets the current users guild objects. Requires the guilds OAuth2 scope.
        /// </summary>
        /// <returns>Enumerable of <see cref="UserGuild"/></returns>
        Task<IEnumerable<UserGuild>> GetCurrentGuilds();

        /// <summary>
        /// Leave a guild. 
        /// </summary>
        /// <param name="guildId">Guild id</param>
        /// <returns>A <see cref="ServiceResult" /></returns>
        Task<ServiceResult> LeaveGuild(ulong guildId);

        /// <summary>
        /// Returns a list of <see cref="DMChannel"/>
        /// </summary>
        /// <returns>Enumerable of <see cref="DMChannel"/></returns>
        Task<IEnumerable<DMChannel>> GetDMs();

        /// <summary>
        /// Create a new DM channel with the specified user.
        /// </summary>
        /// <param name="toUser">Recipient user id</param>
        /// <returns>A <see cref="DMChannel"/></returns>
        Task<DMChannel> CreateDM(ulong toUser);

        /// <summary>
        /// Create a new group DM channel with multiple users. 
        /// </summary>
        /// <param name="tokens">access tokens of users that have granted your app the gdm.join scope</param>
        /// <param name="nicks">a dictionary of user ids to their respective nicknames</param>
        /// <returns>A <see cref="DMChannel"/></returns>
        Task<DMChannel> CreateGroupDM(string[] tokens, Dictionary<ulong, string> nicks);

        /// <summary>
        /// Gets list of <see cref="DiscordConnection"/> for the current user. Requires the connections OAuth2 scope.
        /// </summary>
        /// <returns>Enumerable of <see cref="DiscordConnection"/></returns>
        Task<IEnumerable<DiscordConnection>> GetConnections();
    }
}   