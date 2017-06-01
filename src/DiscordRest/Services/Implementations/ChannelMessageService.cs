using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Services.Implementations
{
    public class ChannelMessageService : IChannelMessageService
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
