using System;
using System.Collections.Generic;

namespace DiscordRest.Data
{
    public class Embed : IDiscordDataObject
    {
        /// <summary>
        /// title of embed
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// type of embed (always "rich" for webhook embeds)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// description of embed
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// url of embed
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// timestamp of embed content
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// color code of the embed
        /// </summary>
        public int Color { get; set; }

        /// <summary>
        /// footer information
        /// </summary>
        public EmbedFooter Footer { get; set; }

        /// <summary>
        /// image information
        /// </summary>
        public EmbedImage Image { get; set; }

        /// <summary>
        /// thumbnail information
        /// </summary>
        public EmbedThumbnail Thumbnail { get; set; }

        /// <summary>
        /// video information
        /// </summary>
        public EmbedVideo Video { get; set; }

        /// <summary>
        /// provider information
        /// </summary>
        public EmbedProvider Provider { get; set; }

        /// <summary>
        /// author information
        /// </summary>
        public EmbedAuthor Author { get; set; }

        /// <summary>
        /// fields information
        /// </summary>
        public IEnumerable<EmbedField> Fields { get; set; }
    }
}