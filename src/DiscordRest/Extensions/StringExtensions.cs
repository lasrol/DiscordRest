using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRest.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Ensures the string is prefixed with "/"
        /// </summary>
        /// <param name="obj">any string</param>
        /// <returns></returns>
        public static string EnsureSlashPrefixed(this string obj)
        {
            if(obj.StartsWith("/"))
                return obj;

            return "/" + obj;
        }

        public static bool IsValidHttpUrl(this string obj)
        {
            return true;
        }
    }
}
