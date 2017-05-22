namespace DiscordRest.Data
{
    public class EmbedProvider : IDiscordDataObject
    {
        /// <summary>
        /// name of provider
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// url of provider
        /// </summary>
        public string Url { get; set; }
    }
}