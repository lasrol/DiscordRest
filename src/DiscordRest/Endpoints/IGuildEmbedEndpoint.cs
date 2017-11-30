using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Endpoints
{
    public interface IGuildEmbedEndpoint
    {
        /// <summary>
        /// Gets the embed object from the guild. Requires the 'MANAGE_GUILD' permission.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GuildEmbed> GetAsync(ulong id);

        /// <summary>
        /// Modify a guild embed object for the guild. All attributes may be passed in with JSON and modified. Requires the 'MANAGE_GUILD' permission.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The modified <see cref="GuildEmbed"/></returns>
        Task<GuildEmbed> ModifyAsync(ulong id);
    }
}