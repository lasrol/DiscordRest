using System;
using System.Threading.Tasks;
using Autofac;
using DiscordRest.Configuration;
using DiscordRest.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Configuration;
using DiscordRest.Data;
using DiscordRest.Endpoints;
using DiscordRest.Endpoints.Implementations;

namespace DiscordRest.Sample.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await Run(args); 
            }).GetAwaiter().GetResult();
            
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }

        private static async Task Run(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddUserSecrets<Program>();
            var configuration = configurationBuilder.Build();
            var container = CreateContainer(configuration);
            //This is a to identification for the provided token, would usually be a reference to the user id.
            var tokenId = Guid.NewGuid();

            container.Resolve<ICurrentUserContext>().UserIdentification = tokenId.ToString();
            await container.Resolve<ITokenStore>().SaveTokensAsync(tokenId.ToString(), new DiscordTokens
            {
                RefreshToken = configuration["token"]
            });

            var discordService = container.Resolve<IDiscordEndpoints>();

            var me = await discordService.UserEndpoint.GetCurrentAsync();
            System.Console.WriteLine($"Current user is: {me.Username}#{me.Discriminator}");
        }

        private static IContainer CreateContainer(IConfiguration config)
        {
            var containerBuilder = new ContainerBuilder();
            //Optional
            containerBuilder.RegisterInstance(config).As<IConfiguration>();
            containerBuilder.RegisterType<ConsoleLoggerProvider>().As<ILoggerProvider>();
            containerBuilder.RegisterType<ConsoleLoggerSettings>().As<IConsoleLoggerSettings>();

            containerBuilder.RegisterInstance(new HttpConnectionOptions()
            {
                ClientId = config["clientId"],
                ClientSecret = config["clientSecret"]
            });

            //Utilities and helpers
            containerBuilder.RegisterType<InMemoryTokenStore>().As<ITokenStore>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<HttpConnectionBuilder>().As<IHttpConnectionBuilder>();
            containerBuilder.RegisterType<DiscordHttpClient>().As<IDiscordHttpClient>();
            containerBuilder.RegisterType<CurrentUserContext>().As<ICurrentUserContext>().InstancePerLifetimeScope();

            //Services
            containerBuilder.RegisterType<UserEndpoint>().As<IUserEndpoint>();
            containerBuilder.RegisterType<DiscordEndpoints>().As<IDiscordEndpoints>();
            containerBuilder.RegisterType<ChannelMessageEndpoint>().As<IChannelMessageEndpoint>();
            containerBuilder.RegisterType<ChannelEndpoint>().As<IChannelEndpoint>();
            containerBuilder.RegisterType<GuildBanEndpoint>().As<IGuildBanEndpoint>();
            containerBuilder.RegisterType<GuildChannelEndpoint>().As<IGuildChannelEndpoint>();
            containerBuilder.RegisterType<GuildEmbedEndpoint>().As<IGuildEmbedEndpoint>();
            containerBuilder.RegisterType<GuildIntegrationEndpoint>().As<IGuildIntegrationEndpoint>();
            containerBuilder.RegisterType<GuildMemberEndpoint>().As<IGuildMemberEndpoint>();
            containerBuilder.RegisterType<GuildPruneEndpoint>().As<IGuildPruneEndpoint>();
            containerBuilder.RegisterType<GuildRoleEndpoint>().As<IGuildRoleEndpoint>();
            containerBuilder.RegisterType<GuildEndpoint>().As<IGuildEndpoint>();
            containerBuilder.RegisterType<InviteEndpoint>().As<IInviteEndpoint>();
            containerBuilder.RegisterType<TokenEndpoint>().As<ITokenEndpoint>();
            containerBuilder.RegisterType<VoiceEndpoint>().As<IVoiceEndpoint>();
            containerBuilder.RegisterType<WebhookEndpoint>().As<IWebhookEndpoint>();

            return containerBuilder.Build();
        }
    }
}