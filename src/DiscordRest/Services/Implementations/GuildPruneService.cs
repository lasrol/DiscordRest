using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRest.Services.Implementations
{
    public class GuildPruneService : IGuildPruneService
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
