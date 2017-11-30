﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DiscordRest.Configuration;
using DiscordRest.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DiscordRest.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDiscordRest<TStore, TCurrentUser>(this IServiceCollection container, Action<HttpConnectionOptions> options) 
            where TStore : class, ITokenStore 
            where TCurrentUser : class, ICurrentUserContext
        {
            var connectionOptions = new HttpConnectionOptions();
            options.Invoke(connectionOptions);

            container.TryAddSingleton(connectionOptions);
            container.TryAddSingleton<ILogger>(NullLogger.Instance);

            container.TryAddScoped<IHttpConnectionBuilder, HttpConnectionBuilder>();
            container.TryAddScoped<IDiscordHttpClient, DiscordHttpClient>();


            //Required user implementations
            container.AddTransient<ITokenStore, TStore>();
            container.AddTransient<ICurrentUserContext, TCurrentUser>();

            //Dynamicly registert services
            var discordRest = typeof(IDiscordEndpoints).GetTypeInfo().Assembly;
            foreach (var type in discordRest.ExportedTypes.Where(t => t.Namespace == "DiscordRest.Endpoints"))
            {
                var implementation = discordRest.GetType(type.Name.Substring(1, type.Name.Length));
                container.AddScoped(type, implementation);
            }

            return container;
        }
    }
}