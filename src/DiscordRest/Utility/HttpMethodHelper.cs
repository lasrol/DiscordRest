using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DiscordRest.Utility
{
    public static class HttpMethodHelper
    {
        public static HttpMethod Patch => new HttpMethod("PATCH");
    }
}
