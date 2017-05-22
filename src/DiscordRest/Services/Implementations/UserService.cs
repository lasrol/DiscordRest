using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Services.Implementations
{
    public class UserService : IUserService
    {
        public UserService()
        {
             
        }

        public Task<DiscordUser> GetCurrent()
        {
            throw new NotImplementedException();
        }

        public Task<DiscordUser> Get(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<DiscordUser> ModifyCurrent()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGuild>> GetCurrentGuilds()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> LeaveGuild(ulong guildId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DMChannel>> GetDMs()
        {
            throw new NotImplementedException();
        }

        public Task<DMChannel> CreateDM(ulong toUser)
        {
            throw new NotImplementedException();
        }

        public Task<DMChannel> CreateGroupDM(string[] tokens, Dictionary<ulong, string> nicks)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DiscordConnection>> GetConnections()
        {
            throw new NotImplementedException();
        }
    }
}
