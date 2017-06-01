using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Services.Implementations
{
    public class GuildEmbedService : IGuildEmbedService
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
