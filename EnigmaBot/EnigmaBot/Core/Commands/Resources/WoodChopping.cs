using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.Currency
{
    public class WoodChopping : ModuleBase<SocketCommandContext>
    {
        [Group("Wood"), Alias("wood", "w", "W"), Summary("This group should interact with different wood chopping jobs")]
        public class PlayerWoodChopping : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder WoodChoppingEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("ash", "Ash"), Summary("Command to chop a ash wood")]
            public async Task IncomingPlayerAshWoodChoppingRequest()
            {
                if ((DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                {
                    //In future update add a axe durability check

                    //Execution of command
                    int WoodToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    WoodChoppingEmbed.AddField("<:Axe:603957682004688919>```Success!```", $"```You have received {WoodToGiveAmount} units of ash wood!```");
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());

                    //Save data
                    await CharactersData.SavePlayerWoodChoppingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                    if (CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) <= 2)
                    {
                        await CharactersData.SaveCharacterAshWood(Context.User.Id, WoodToGiveAmount, 0.3f);
                    }
                    else
                    {
                        await CharactersData.SaveCharacterAshWood(Context.User.Id, WoodToGiveAmount, 0.3f / CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                    }
                }
                else
                {
                    //Send message about cooldown
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    if (120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds > 60)
                    {
                        WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                        $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                    }
                    else
                    {
                        WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                        $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds))}s```");
                    }
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("birch", "Birch"), Summary("Command to chop a birch wood")]
            public async Task IncomingPlayerBirchWoodChoppingRequest()
            {
                if(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) >= 5)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int WoodToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        WoodChoppingEmbed.AddField("<:Axe:603957682004688919>```Success!```", $"```You have received {WoodToGiveAmount} units of birch wood!```");
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerWoodChoppingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterBirchWood(Context.User.Id, WoodToGiveAmount, 0.3f / CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));                       
                    }
                    else
                    {
                        //Send message about cooldown
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```Wood chopping skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("maple", "Maple"), Summary("Command to chop a maple wood")]
            public async Task IncomingPlayerMapleWoodChoppingRequest()
            {
                if (CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) >= 10)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int WoodToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)/2);
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        WoodChoppingEmbed.AddField("<:Axe:603957682004688919>```Success!```", $"```You have received {WoodToGiveAmount} units of maples wood!```");
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerWoodChoppingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterMapleWood(Context.User.Id, WoodToGiveAmount, 0.3f / CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```Wood chopping skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("spruce", "Spruce"), Summary("Command to chop a spruce wood")]
            public async Task IncomingPlayerSpruceWoodChoppingRequest()
            {
                if (CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) >= 15)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int WoodToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)/2);
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        WoodChoppingEmbed.AddField("<:Axe:603957682004688919>```Success!```", $"```You have received {WoodToGiveAmount} units of spruce wood!```");
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerWoodChoppingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterSpruceWood(Context.User.Id, WoodToGiveAmount, 0.3f / CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```Wood chopping skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("pine", "Pine"), Summary("Command to chop a pine wood")]
            public async Task IncomingPlayerPineWoodChoppingRequest()
            {
                if (CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) >= 20)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int WoodToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) / 2);
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        WoodChoppingEmbed.AddField("<:Axe:603957682004688919>```Success!```", $"```You have received {WoodToGiveAmount} units of pine wood!```");
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerWoodChoppingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterPineWood(Context.User.Id, WoodToGiveAmount, 0.3f / CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```Wood chopping skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("oak", "Oak"), Summary("Command to chop a oak wood")]
            public async Task IncomingPlayerOakWoodChoppingRequest()
            {
                if (CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) >= 25)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int WoodToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) / 2);
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        WoodChoppingEmbed.AddField("<:Axe:603957682004688919>```Success!```", $"```You have received {WoodToGiveAmount} units of oak wood!```");
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerWoodChoppingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterOakWood(Context.User.Id, WoodToGiveAmount, 0.3f / CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```Wood chopping skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("walnut", "Walnut"), Summary("Command to chop a walnut wood")]
            public async Task IncomingPlayerWalnutWoodChoppingRequest()
            {
                if (CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) >= 30)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int WoodToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) / 3);
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        WoodChoppingEmbed.AddField("<:Axe:603957682004688919>```Success!```", $"```You have received {WoodToGiveAmount} units of walnut wood!```");
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerWoodChoppingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterWalnutWood(Context.User.Id, WoodToGiveAmount, 0.3f / CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```Wood chopping skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("elven", "Elven"), Summary("Command to chop a elven wood")]
            public async Task IncomingPlayerElvenWoodChoppingRequest()
            {
                if (CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) >= 35)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int WoodToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id) / 4);
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        WoodChoppingEmbed.AddField("<:Axe:603957682004688919>```Success!```", $"```You have received {WoodToGiveAmount} units of elven wood!```");
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerWoodChoppingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterElvenWood(Context.User.Id, WoodToGiveAmount, 0.3f / CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        WoodChoppingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to chop wood```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterWoodChoppingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    WoodChoppingEmbed.WithColor(Color.Blue);
                    WoodChoppingEmbed.AddField($"<:Axe:603957682004688919>```Wood chopping skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, WoodChoppingEmbed.Build());
                    return;
                }
            }
        }
    }
}
