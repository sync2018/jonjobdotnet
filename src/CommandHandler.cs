using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JonJobBot.src
{
    public class CommandHandler
    {
        private readonly DiscordShardedClient _client;
        private readonly IServiceProvider _services;
        private readonly IConfiguration _config;
        private readonly CommandService _command;
        private static string _botPrefix;
        

        public CommandHandler(
            DiscordShardedClient client, 
            CommandService command,
            IServiceProvider services,
            IConfiguration config)
        {
            _client = client;
            _services = services;
            _config = config;
            _command = command;
            _botPrefix = _config["BOT_PREFIX"];

            _client.MessageReceived += HandleCommandAsync;
            _command.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            var msg = message as SocketUserMessage;
            if (msg == null)
                return;

            var context = new ShardedCommandContext(_client, msg);

            int argPos = 0;

            if (msg.Author.IsBot)
                return;

            if (msg.HasStringPrefix(_botPrefix, ref argPos))
            {
                var result = await _command.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                    return;
                }
            }
        }
    }
}
