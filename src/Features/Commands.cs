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
        Random _rand = new Random();

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

            var insults = Constants.Insults.GetAll();

            var randomUserIndex = _rand.Next(users.Count());
            var randomInsultIndex = _rand.Next(insults.Count());
            var randomUser = users.Skip(randomUserIndex).First();
            var randomInsult = insults.Skip(randomInsultIndex).First();
            var response = Constants.BotResponse.Yawa;
            await ReplyAsync(TextFormattingHelper.ParseMergeFieldsValues(response, new string[] { randomInsult, randomUser.Mention }));
        } 
    }
}
