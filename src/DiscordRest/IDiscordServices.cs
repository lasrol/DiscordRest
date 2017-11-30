using DiscordRest.Endpoints;

namespace DiscordRest
{
    /// <summary>
    /// Service used to connect and query Discord Rest API
    /// </summary>
    public interface IDiscordEndpoints
    {
        /// <summary>
        /// Services to query Discord User endpoints
        /// </summary>
        IUserEndpoint UserService { get; }

        /// <summary>
        /// Services to query Discord Guild endpoints
        /// </summary>
        IGuildEndpoint GuildService { get; }

        /// <summary>
        /// Services to query Discord Channel endpoints
        /// </summary>
        IChannelEndpoint ChannelService { get; }

        /// <summary>
        /// Services to query Discord Invite endpoints
        /// </summary>
        IInviteEndpoint InviteService { get; }

        /// <summary>
        /// Services to query Discord Voice endpoints
        /// </summary>
        IVoiceEndpoint VoiceService { get; }

        /// <summary>
        /// Services to query Discord Webhook endpoints
        /// </summary>
        IWebhookEndpoint WebhookService { get; }
    }
}
        