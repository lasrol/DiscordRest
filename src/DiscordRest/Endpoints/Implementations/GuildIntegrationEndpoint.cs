﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Endpoints.Implementations
{
    public class GuildIntegrationEndpoint : IGuildIntegrationEndpoint
    {
        public Task<ServiceResult> CreateAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> DeleteAsync(ulong id, ulong integrationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuildIntegrations>> GetAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ModifyAsync(ulong id, ulong integrationId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SyncAsync(ulong id, ulong integrationId)
        {
            throw new NotImplementedException();
        }
    }
}
