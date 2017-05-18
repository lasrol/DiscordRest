namespace DiscordRest.Data
{
    public class Invite
    {
        /// <summary>
        /// the invite code (unique ID)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// the guild this invite is for
        /// </summary>
        public InviteGuild Guild { get; set; }

        /// <summary>
        /// the channel this invite is for
        /// </summary>
        public InviteChannel Channel { get; set; }
    }
}