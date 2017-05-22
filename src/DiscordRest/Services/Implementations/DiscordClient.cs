using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DiscordRest.Services.Implementations
{
    /// <summary>
    /// Implementation of the IDiscordClient
    /// </summary>
    public class DiscordClient : IDiscordClient
    {
        /// <summary>
        /// Discord Clients is the main entry to communicate with Discord REST API.
        /// </summary>
        /// <param name="userService">A <see cref="IUserService"/> instance</param>
        /// <param name="guildService">A <see cref="IGuildService"/> instance</param>
        /// <param name="channelService">A <see cref="IChannelService"/> instance</param>
        /// <param name="inviteService">A <see cref="IInviteService"/> instance</param>
        /// <param name="voiceService">A <see cref="IVoiceService"/> instance</param>
        /// <param name="webhookService">A <see cref="IWebhookService"/> instance</param>
        public DiscordClient(
            IUserService userService, 
            IGuildService guildService, 
            IChannelService channelService, 
            IInviteService inviteService, 
            IVoiceService voiceService, 
            IWebhookService webhookService)
        {
            UserService = userService;
            GuildService = guildService;
            ChannelService = channelService;
            InviteService = inviteService;
            VoiceService = voiceService;
            WebhookService = webhookService;
        }

        /// <summary>
        /// Instance of User specific services
        /// </summary>
        public IUserService UserService { get; }

        /// <summary>
        /// Instance of Guild specific services
        /// </summary>
        public IGuildService GuildService { get; }

        /// <summary>
        /// Instance of Channel specific services
        /// </summary>
        public IChannelService ChannelService { get; }

        /// <summary>
        /// Instance for Invite specific queries and operations
        /// </summary>
        public IInviteService InviteService { get; }

        /// <summary>
        /// Instance of Voice specific services
        /// </summary>
        public IVoiceService VoiceService { get; }

        /// <summary>
        /// Instance of Webhook specific services
        /// </summary>
        public IWebhookService WebhookService { get; }
    }
}
