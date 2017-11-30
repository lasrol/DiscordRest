using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DiscordRest.Utility
{
    public static class DiscordEndpointCollectionUtility
    {
        public static IDictionary<Type, Type> SearchForEndpoints()
        {
            var result = new Dictionary<Type, Type>();
            var discordRest = typeof(IDiscordEndpoints).GetTypeInfo().Assembly;
            foreach (var iface in discordRest.ExportedTypes.Where(t => t.Namespace == "DiscordRest.Endpoints"))
            {
                try
                {
                    //Removing the I in the interface, and try to find a matching implementation
                    var implementation = discordRest.ExportedTypes.First(p => p.Name == iface.Name.Substring(1, iface.Name.Length - 1));
                    result.Add(iface, implementation);
                }
                catch (Exception e)
                {
                    throw new Exception($"Failed to find endpoint for {iface.Name}", e);
                }
            }

            return result;
        }
    }
}
