using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Services.Implementations
{
    public class GuildService : IGuildService
    {
        public IGuildChannelService Channel => throw new NotImplementedException();

        public IGuildMemberService Member { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildBanService Ban { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildRoleService Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildPruneService Prune { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildIntegrationService Integration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildEmbedService Embed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<Guild> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Guild> DeleteAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<Guild> GetAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invite>> GetInvitesAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VoiceRegion>> GetVoiceRegionsAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<Guild> ModifyAsync(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
