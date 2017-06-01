using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRest.Utility
{
    public class CurrentUserContext : ICurrentUserContext
    {
        public CurrentUserContext()
        {
            UserIdentification = string.Empty;
        }

        public CurrentUserContext(string id)
        {
            UserIdentification = id;
        }

        public string UserIdentification { get; set; }
    }
}
