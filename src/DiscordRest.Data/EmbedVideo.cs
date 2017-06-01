namespace DiscordRest.Data
{
    public class EmbedVideo : IDiscordDataObject
    {
        /// <summary>
        /// source url of video 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// height of video
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// width of video
        /// </summary>
        public int Width { get; set; }
    }
}