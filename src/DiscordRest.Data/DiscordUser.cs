using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DiscordRest.Data
{
    public class DiscordUser
    {
        /// <summary>
        /// the user's id
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// the user's username, not unique across the platform
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// the user's 4-digit discord-tag
        /// </summary>
        public string Discriminator { get; set; }

        /// <summary>
        /// the user's avatar hash
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// whether the user belongs to an OAuth2 application
        /// </summary>
        [JsonProperty("bot")]
        public bool IsBot { get; set; }

        /// <summary>
        /// whether the user has two factor enabled on their account
        /// </summary>
        [JsonProperty("mfa_enabled")]
        public bool HasTwoFactorEnabled { get; set; }

        /// <summary>
        /// whether the email on this account has been verified
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// the user's email
        /// </summary>
        public string Email { get; set; }
    }
}
