using Discord;
using Discord.WebSocket;
using JonJobBot.src;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JonJobBot
{
    public class DiscordSocketService : IHostedService
    {
        private readonly ILogger<DiscordSocketService> _logger;
        private readonly IApplicationLifetime _applicationLifetime;
        private readonly IConfiguration _config;
        private static string botToken;
        private static DiscordShardedClient discordClient;

        public DiscordSocketService(
            ILogger<DiscordSocketService> logger, 
            IApplicationLifetime applicationLifetime,
            IConfiguration configuration)
        {
            _logger = logger;
            _applicationLifetime = applicationLifetime;
            _config = configuration;
            botToken = _config["BOT_TOKEN"];
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _applicationLifetime.ApplicationStarted.Register(OnStarted);
            _applicationLifetime.ApplicationStarted.Register(OnStopping);
            _applicationLifetime.ApplicationStarted.Register(OnStopped);

            return Task.CompletedTask;
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            discordClient.StopAsync().Wait();
        }

        private void OnStopped()
        {
            Console.WriteLine("Application stopped");
        }

        private void OnStopping()
        {
            Console.WriteLine("Stopping...");
        }

        private void OnStarted()
        {
            LogSeverity logLevel = LogSeverity.Info;

            if (_config["LOGLEVEL"] == "DEBUG")
                logLevel = LogSeverity.Debug;
            else if (_config["LOGLEVEL"] == "WARNING")
                logLevel = LogSeverity.Warning;
            else if (_config["LOGLEVEL"] == "ERROR")
                logLevel = LogSeverity.Error;

            discordClient = new DiscordShardedClient(new DiscordSocketConfig
            {
                LogLevel = logLevel
            });

            ConfigureEventHandlers(discordClient);

            discordClient.LoginAsync(TokenType.Bot, botToken).Wait();
            discordClient.StartAsync().Wait();
        }

        private void ConfigureEventHandlers(DiscordShardedClient client)
        {
            new CommandHandler(client, _config);
        }
    }
}
