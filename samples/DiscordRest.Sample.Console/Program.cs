using System;
using System.Threading.Tasks;
using Autofac;
using DiscordRest.Configuration;
using DiscordRest.Models;
using DiscordRest.Services.Implementations;
using DiscordRest.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using DiscordRest.Services;
using Microsoft.Extensions.Configuration;
using DiscordRest.Data;

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

            var discordService = container.Resolve<IDiscordServices>();

            var me = await discordService.UserService.GetCurrentAsync();
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
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<DiscordServices>().As<IDiscordServices>();
            containerBuilder.RegisterType<ChannelMessageService>().As<IChannelMessageService>();
            containerBuilder.RegisterType<ChannelService>().As<IChannelService>();
            containerBuilder.RegisterType<GuildBanService>().As<IGuildBanService>();
            containerBuilder.RegisterType<GuildChannelService>().As<IGuildChannelService>();
            containerBuilder.RegisterType<GuildEmbedService>().As<IGuildEmbedService>();
            containerBuilder.RegisterType<GuildIntegrationService>().As<IGuildIntegrationService>();
            containerBuilder.RegisterType<GuildMemberService>().As<IGuildMemberService>();
            containerBuilder.RegisterType<GuildPruneService>().As<IGuildPruneService>();
            containerBuilder.RegisterType<GuildRoleService>().As<IGuildRoleService>();
            containerBuilder.RegisterType<GuildService>().As<IGuildService>();
            containerBuilder.RegisterType<InviteService>().As<IInviteService>();
            containerBuilder.RegisterType<TokenService>().As<ITokenService>();
            containerBuilder.RegisterType<VoiceService>().As<IVoiceService>();
            containerBuilder.RegisterType<WebhookService>().As<IWebhookService>();

            return containerBuilder.Build();
        }
    }
}