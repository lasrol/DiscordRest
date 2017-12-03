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
        IUserEndpoint UserEndpoint { get; }

        /// <summary>
        /// Services to query Discord Guild endpoints
        /// </summary>
        IGuildEndpoint GuildEndpoint { get; }

        /// <summary>
        /// Services to query Discord Channel endpoints
        /// </summary>
        IChannelEndpoint ChannelEndpoint { get; }

        /// <summary>
        /// Services to query Discord Invite endpoints
        /// </summary>
        IInviteEndpoint InviteEndpoint { get; }

        /// <summary>
        /// Services to query Discord Voice endpoints
        /// </summary>
        IVoiceEndpoint VoiceEndpoint { get; }

        /// <summary>
        /// Services to query Discord Webhook endpoints
        /// </summary>
        IWebhookEndpoint WebhookEndpoint { get; }
    }
}
        