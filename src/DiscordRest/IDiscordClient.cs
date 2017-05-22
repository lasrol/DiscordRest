using System.Text;
using DiscordRest.Services;

namespace DiscordRest
{
    /// <summary>
    /// Client used to connect and query Discord Rest API
    /// </summary>
    public interface IDiscordClient
    {
        /// <summary>
        /// Services to query Discord User endpoints
        /// </summary>
        IUserService UserService { get; }

        /// <summary>
        /// Services to query Discord Guild endpoints
        /// </summary>
        IGuildService GuildService { get; }

        /// <summary>
        /// Services to query Discord Channel endpoints
        /// </summary>
        IChannelService ChannelService { get; }

        /// <summary>
        /// Services to query Discord Invite endpoints
        /// </summary>
        IInviteService InviteService { get; }

        /// <summary>
        /// Services to query Discord Voice endpoints
        /// </summary>
        IVoiceService VoiceService { get; }

        /// <summary>
        /// Services to query Discord Webhook endpoints
        /// </summary>
        IWebhookService WebhookService { get; }
    }
}
        