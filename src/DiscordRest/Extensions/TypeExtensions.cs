using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DiscordRest.Extensions
{
    public static class TypeExtensions
    {
        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            return type.GetTypeInfo().GetCustomAttribute<T>();
        }
    }
}
