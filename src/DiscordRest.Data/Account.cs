namespace DiscordRest.Data
{
    public class Account : IDiscordDataObject
    {
        /// <summary>
        /// 	id of the account
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 	name of the account
        /// </summary>
        public string Name { get; set; }
    }
}