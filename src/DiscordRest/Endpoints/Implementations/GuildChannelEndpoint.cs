using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Endpoints.Implementations
{
    public class GuildChannelEndpoint : IGuildChannelEndpoint
    {
        public Task<GuildChannel> CreateAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuildChannel>> GetAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuildChannel>> ModifyPositionsAsync(ulong id, ulong channelId, int position)
        {
            throw new NotImplementedException();
        }
    }
}
