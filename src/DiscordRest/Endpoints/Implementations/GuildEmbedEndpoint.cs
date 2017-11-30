using System;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Endpoints.Implementations
{
    public class GuildEmbedEndpoint : IGuildEmbedEndpoint
    {
        public Task<GuildEmbed> GetAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<GuildEmbed> ModifyAsync(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
