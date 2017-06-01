namespace DiscordRest.Data
{
    public class InviteChannel : IDiscordDataObject
    {
        /// <summary>
        /// id of the channel
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// name of the channel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 'text' or 'voice'
        /// </summary>
        public string Type { get; set; }
    }
}