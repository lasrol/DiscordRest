using System.Threading.Tasks;
namespace DiscordRest.Services
{
    using DiscordRest.Data;

    public interface IInviteService
    {
        /// <summary>
        /// Return the invite for the specified code.
        /// </summary>
        /// <param name="code">invitation code</param>
        /// <returns>A <see cref="Invite"/></returns>
        Task<Invite> Get(string code);

        /// <summary>
        /// Delete an invite. Requires the MANAGE_CHANNELS permission.
        /// </summary>
        /// <param name="code">invitation code</param>
        /// <returns>A <see cref="Invite"/> on success</returns>
        Task<Invite> Delete(string code);

        /// <summary>
        /// Accept an invite. This is not available to bot accounts, and requires the guilds.join OAuth2 scope to accept on behalf of normal users.
        /// </summary>
        /// <param name="code">invitation code</param>
        /// <returns>A <see cref="Invite"/></returns>
        Task<Invite> Accept(string code);
    }
}