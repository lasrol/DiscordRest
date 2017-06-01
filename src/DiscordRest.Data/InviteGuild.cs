namespace DiscordRest.Data
{
    public class InviteGuild : IDiscordDataObject
    {
        /// <summary>
        /// id of the guild
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// name of the guild
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// hash of the guild splash (or null)
        /// </summary>
        public string Splash { get; set; }

        /// <summary>
        /// hash of the guild icon (or null)
        /// </summary>
        public string Icon { get; set; }
    }
}