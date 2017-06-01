using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Models;
using DiscordRest.Data;

namespace DiscordRest.Services.Implementations
{
    public class ChannelService : IChannelService
    {
        public ChannelService(IChannelMessageService messageService)
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

        public IChannelMessageService Message { get; set; }
        public Task<ServiceResult> CreateReaction(ulong id, ulong msgId, ulong reactionId)
        {
            throw new NotImplementedException();
        }
    }
}
