using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JonJobBot.src.Features
{
    public class Commands : ModuleBase<ShardedCommandContext>
    {
        [Command(Constants.BotCommands.Greet)]
        public async Task Greet()
        {
            await ReplyAsync(Constants.BotResponse.Greet);
        }

    }
}
