using System.Collections.Generic;

namespace DiscordRest.Data
{
    public class Attachment
    {
        /// <summary>
        /// attachment id
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// name of file attached
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// source url of file
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// A proxied url of file
        /// </summary>
        public string ProxyUrl { get; set; }

        /// <summary>
        /// height of file (if image)
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// width of file (if image)
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// size of file in bytes
        /// </summary>
        public int Size { get; set; }
    }
}   