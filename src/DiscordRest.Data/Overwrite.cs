namespace DiscordRest.Data
{
    public class Overwrite
    {
        /// <summary>
        ///     role or user id
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// 	either "role" or "member"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 	permission bit set
        /// </summary>
        public int Allow { get; set; }

        /// <summary>
        /// 	permission bit set
        /// </summary>
        public int Deny { get; set; }
    }
}