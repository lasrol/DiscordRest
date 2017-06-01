using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Services.Implementations
{
    public class GuildMemberService : IGuildMemberService
    {
        public Task<GuildMember> AddAsync(ulong id, ulong userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> AddToRoleAsync(ulong id, ulong userId, ulong roleId)
        {
            throw new NotImplementedException();
        }

        public Task<GuildMember> GetAsync(ulong id, ulong userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuildMember>> GetAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ModifyAsync(ulong id, ulong userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ModifyCurrentUserNickAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> RemoveAsync(ulong id, ulong userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> RemoveFromRoleAsync(ulong id, ulong userId, ulong roleId)
        {
            throw new NotImplementedException();
        }
    }
}
