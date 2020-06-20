using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JonJobBot.src
{
    public class CommandHandler
    {
        private readonly DiscordShardedClient _client;
        private readonly IConfiguration _config;
        private readonly CommandService _service;
        private readonly IConfiguration configuration;
        private static string botPrefix;

        public CommandHandler(DiscordShardedClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
            botPrefix = _config["BOT_PREFIX"];
            _service = new CommandService();

            _service.AddModulesAsync(Assembly.GetEntryAssembly(), default);

            _client.MessageReceived += HandleCommandAsync;
        }

        /// <summary>
        /// Place commands here
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task HandleCommandAsync(SocketMessage message)
        {
            var msg = message as SocketUserMessage;
            if (msg == null)
                return;

            var context = new ShardedCommandContext(_client, msg);

            int argPos = 0;

            if (msg.HasStringPrefix(botPrefix, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos, default);

                if (!result.IsSuccess && result.Error == CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync("ganahan kog utin");
                }
            }
        }
    }
}
