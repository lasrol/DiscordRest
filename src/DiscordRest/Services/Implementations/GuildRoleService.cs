using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Services.Implementations
{
    public class GuildRoleService : IGuildRoleService
    {
        public Task<DiscordRole> AddAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> DeleteAsync(ulong id, ulong roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DiscordRole>> GetAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DiscordRole>> ModifyPositionAsync(ulong id, ulong roleId)
        {
            throw new NotImplementedException();
        }
    }
}
