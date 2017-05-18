namespace DiscordRest.Data
{
    public class EmbedFooter
    {
        /// <summary>
        /// footer text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// url of footer icon (only supports http(s) and attachments)
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// a proxied url of footer icon
        /// </summary>
        public string ProxyIconUrl { get; set; }
    }
}