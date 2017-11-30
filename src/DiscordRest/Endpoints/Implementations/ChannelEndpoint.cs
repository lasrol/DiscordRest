using System;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Endpoints.Implementations
{
    public class ChannelEndpoint : IChannelEndpoint
    {
        public ChannelEndpoint(IChannelMessageEndpoint messageService)
        {
            Message = messageService;
        }
        
        public Task<GuildChannel> Get(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<GuildChannel> Modify(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<GuildChannel> Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<DMChannel> CloseDM(ulong id)
        {
            throw new NotImplementedException();
        }

        public IChannelMessageEndpoint Message { get; set; }
        public Task<ServiceResult> CreateReaction(ulong id, ulong msgId, ulong reactionId)
        {
            throw new NotImplementedException();
        }
    }
}
