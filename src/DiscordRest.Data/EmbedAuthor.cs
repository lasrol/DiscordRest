namespace DiscordRest.Data
{
    public class EmbedAuthor
    {
        /// <summary>
        /// name of author
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// url of author
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// url of author icon (only supports http(s) and attachments)
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// a proxied url of author icon
        /// </summary>
        public string ProxyIconUrl { get; set; }    
    }
}