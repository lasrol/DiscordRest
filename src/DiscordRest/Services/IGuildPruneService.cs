using System.Threading.Tasks;

namespace DiscordRest.Services
{
    public interface IGuildPruneService
    {
        /// <summary>
        /// Returns an object with one 'pruned' key indicating the number of members that would be removed in a prune operation. Requires the 'KICK_MEMBERS' permission.
        /// </summary>
        /// <param name="id">guild id</param>
        /// <param name="days">number of days to prune (1 or more)</param>
        /// <returns>the number of members that would be removed in a prune operation.</returns>
        Task<int> GetPruneCountAsync(ulong id, int days = 1);

        /// <summary>
        /// Begin a prune operation. Requires the 'KICK_MEMBERS' permission.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the number of members that were removed in the prune operation.</returns>
        Task<int> BeginPruneAsync(ulong id);
    }
}