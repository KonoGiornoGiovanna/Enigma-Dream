using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Discord;
using Discord.Commands;

namespace EnigmaBot.Core.Commands
{
    public class BotCheck : ModuleBase<SocketCommandContext>
    {
        EmbedBuilder CheckEmbed = new EmbedBuilder();

        [Command("check"), Alias("Check"), Summary("Command for bot check")]
        public async Task BotCheckingMethod()
        {
            CheckEmbed.WithColor(Color.Blue);
            CheckEmbed.AddField("<:Meat:607579880569307146>```Bot checking Embed```", "```We need to send image!```");
            await Context.Channel.SendMessageAsync("", false, CheckEmbed.Build());
        }
    }
}
