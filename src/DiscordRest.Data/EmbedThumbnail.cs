namespace DiscordRest.Data
{
    public class EmbedThumbnail
    {
        /// <summary>
        /// source url of thumbnail (only supports http(s) and attachments)
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// a proxied url of the thumbnail
        /// </summary>
        public string ProxyUrl { get; set; }

        /// <summary>
        /// height of thumbnail
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// width of thumbnail
        /// </summary>
        public int Width { get; set; }
    }
}