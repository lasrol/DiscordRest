namespace DiscordRest.Data
{
    public class DMChannel : IDiscordDataObject
    {
        /// <summary>
        /// the id of this private message
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// should always be true for DM channels
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// the user object of the DM recipient
        /// </summary>
        public DiscordUser Recipient { get; set; }

        /// <summary>
        /// the id of the last message sent in this DM
        /// </summary>
        public ulong LastMessageId { get; set; }
    }
}