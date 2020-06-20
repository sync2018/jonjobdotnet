using Discord.Commands;
using JonJobBot.src.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        [Command(Constants.BotCommands.Yawa)]
        public async Task Yawa()
        {
            if (Context.Guild.Users.Count < 1)
                return;

            var users = Context.Guild.Users
                .Where(x => (x.Status == Discord.UserStatus.Online || x.Status == Discord.UserStatus.Idle || x.Status == Discord.UserStatus.AFK) && !x.IsBot);
            var rand = new Random();
            var randomIndex = rand.Next(users.Count());
            var randomUser = users.Skip(randomIndex).First();
            var response = Constants.BotResponse.Yawa;
            await ReplyAsync(TextFormattingHelper.ParseMergeFields(response, new string[] { randomUser.Mention }));
        } 
    }
}
