using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;
using System.Net.Http;

namespace DiscordRest.Endpoints.Implementations
{
    /// <summary>
    /// All endpoints for handling guilds
    /// </summary>
    public class GuildEndpoint : IGuildEndpoint
    {
        private readonly IDiscordHttpClient _httpClient;

        public GuildEndpoint(IDiscordHttpClient httpClient, IGuildMemberEndpoint memberEndpoint)
        {
            _httpClient = httpClient;
            Member = memberEndpoint;
        }

        public IGuildChannelEndpoint Channel => throw new NotImplementedException();

        public IGuildMemberEndpoint Member { get; }
        public IGuildBanEndpoint Ban => throw new NotImplementedException();
        public IGuildRoleEndpoint Role => throw new NotImplementedException();
        public IGuildPruneEndpoint Prune => throw new NotImplementedException();
        public IGuildIntegrationEndpoint Integration => throw new NotImplementedException();
        public IGuildEmbedEndpoint Embed => throw new NotImplementedException();

        /// <inheritdoc />
        public Task<Guild> CreateAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Guild> DeleteAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Guild> GetAsync(ulong id) => _httpClient.RunAsync<Guild>(HttpMethod.Get, $"/guilds/{id}", null);

        /// <inheritdoc />
        public Task<IEnumerable<Invite>> GetInvitesAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<IEnumerable<VoiceRegion>> GetVoiceRegionsAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Guild> ModifyAsync(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
