using System;
using DiscordRest.Data;

namespace DiscordRest.Data
{
    public class GuildIntegrations : IDiscordDataObject
    {
        /// <summary>
        ///     integration id
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        ///     integration name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     integration type (twitch, youtube, etc)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 	is this integration enabled
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 	is this integration syncing
        /// </summary>
        public bool IsSyncing { get; set; }

        /// <summary>
        ///     id that this integration uses for "subscribers"
        /// </summary>
        public ulong RoleId { get; set; }

        /// <summary>
        ///     the behavior of expiring subscribers
        /// </summary>
        public int ExpireBehavior { get; set; }

        /// <summary>
        ///     the grace period before expiring subscribers
        /// </summary>
        public int ExpireGracePeriod { get; set; }

        /// <summary>
        ///     user for this integration
        /// </summary>
        public DiscordUser User { get; set; }

        /// <summary>
        ///     integration account information
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        ///     when this integration was last synced
        /// </summary>
        public DateTime SyncedAt { get; set; }

    }
}