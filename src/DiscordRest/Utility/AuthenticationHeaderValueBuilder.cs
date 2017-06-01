using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using DiscordRest.Extensions;

namespace DiscordRest.Utility
{
    public static class AuthenticationHeaderValueBuilder
    {
        public static AuthenticationHeaderValue Build(string scheme, string parameter)
        {
            if (scheme == DiscordConstants.AuthenticationSchemes.Basic)
            {
                return new AuthenticationHeaderValue(DiscordConstants.AuthenticationSchemes.Basic, parameter.Base64Encode());
            }

            return new AuthenticationHeaderValue(scheme, parameter);
        }
    }
}
