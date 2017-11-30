using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Endpoints.Implementations
{
    public class GuildEndpoint : IGuildEndpoint
    {
        public IGuildChannelEndpoint Channel => throw new NotImplementedException();

        public IGuildMemberEndpoint Member { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildBanEndpoint Ban { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildRoleEndpoint Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildPruneEndpoint Prune { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildIntegrationEndpoint Integration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuildEmbedEndpoint Embed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
