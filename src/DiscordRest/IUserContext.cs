using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRest
{
    public interface ICurrentUserContext
    {
        string UserIdentification { get; set; }
    }
}
    