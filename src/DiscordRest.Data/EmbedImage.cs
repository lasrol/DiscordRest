namespace DiscordRest.Data
{
    public class EmbedImage
    {
        /// <summary>
        /// source url of image (only supports http(s) and attachments)
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// a proxied url of the image
        /// </summary>
        public string ProxyUrl { get; set; }

        /// <summary>
        /// height of image
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// width of image
        /// </summary>
        public int Width { get; set; }
    }
}