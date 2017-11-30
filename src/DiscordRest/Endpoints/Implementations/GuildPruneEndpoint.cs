using System;
using System.Threading.Tasks;

namespace DiscordRest.Endpoints.Implementations
{
    public class GuildPruneEndpoint : IGuildPruneEndpoint
    {
        public Task<int> BeginPruneAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPruneCountAsync(ulong id, int days = 1)
        {
            throw new NotImplementedException();
        }
    }
}
