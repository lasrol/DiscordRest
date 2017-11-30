using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Endpoints.Implementations
{
    public class ChannelMessageEndpoint : IChannelMessageEndpoint
    {
        public Task<Message> CreateMessage(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetMessage(ulong id, ulong msgId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetMessages(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
