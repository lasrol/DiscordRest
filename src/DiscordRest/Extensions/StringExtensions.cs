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

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
