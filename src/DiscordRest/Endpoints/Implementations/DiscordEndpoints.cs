namespace DiscordRest.Endpoints.Implementations
{
    /// <summary>
    /// Implementation of the IDiscordClient
    /// </summary>
    public class DiscordEndpoints : IDiscordEndpoints
    {
        /// <summary>
        /// Discord Clients is the main entry to communicate with Discord REST API.
        /// </summary>
        /// <param name="userEndpoint">A <see cref="IUserEndpoint"/> instance</param>
        /// <param name="guildEndpoint">A <see cref="IGuildEndpoint"/> instance</param>
        /// <param name="channelEndpoint">A <see cref="IChannelEndpoint"/> instance</param>
        /// <param name="inviteEndpoint">A <see cref="IInviteEndpoint"/> instance</param>
        /// <param name="voiceEndpoint">A <see cref="IVoiceEndpoint"/> instance</param>
        /// <param name="webhookEndpoint">A <see cref="IWebhookEndpoint"/> instance</param>
        public DiscordEndpoints(
            IUserEndpoint userEndpoint,
            IGuildEndpoint guildEndpoint,
            IChannelEndpoint channelEndpoint,
            IInviteEndpoint inviteEndpoint,
            IVoiceEndpoint voiceEndpoint,
            IWebhookEndpoint webhookEndpoint)
        {
            UserEndpoint = userEndpoint;
            GuildEndpoint = guildEndpoint;
            ChannelEndpoint = channelEndpoint;
            InviteEndpoint = inviteEndpoint;
            VoiceEndpoint = voiceEndpoint;
            WebhookEndpoint = webhookEndpoint;
        }

        /// <summary>
        /// Instance of User specific services
        /// </summary>
        public IUserEndpoint UserEndpoint { get; }

        /// <summary>
        /// Instance of Guild specific services
        /// </summary>
        public IGuildEndpoint GuildEndpoint { get; }

        /// <summary>
        /// Instance of Channel specific services
        /// </summary>
        public IChannelEndpoint ChannelEndpoint { get; }

        /// <summary>
        /// Instance for Invite specific queries and operations
        /// </summary>
        public IInviteEndpoint InviteEndpoint { get; }

        /// <summary>
        /// Instance of Voice specific services
        /// </summary>
        public IVoiceEndpoint VoiceEndpoint { get; }

        /// <summary>
        /// Instance of Webhook specific services
        /// </summary>
        public IWebhookEndpoint WebhookEndpoint { get; }
    }
}
