namespace DiscordRest.Data
{
    public class Permissions
    {
        private ulong _rawValue { get; set; }

        public Permissions(ulong rawPermissions)
        {
            _rawValue = rawPermissions;
        }

        public ulong RawValue => _rawValue;
    }
}   