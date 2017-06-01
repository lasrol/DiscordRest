using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Services.Implementations
{
    public class GuildBanService : IGuildBanService
    {
        public Task<ServiceResult> AddAsync(ulong id, ulong userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DiscordUser>> GetAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> RemoveAsync(ulong id, ulong userId)
        {
            throw new NotImplementedException();
        }
    }
}
