using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.Currency
{
    public class Hunting : ModuleBase<SocketCommandContext>
    {
        [Group("Hunt"), Alias("hunt", "Hunting", "hunting","H","h"), Summary("This group should interact with different hunting jobs")]
        public class PlayerHunting : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder HuntingEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("duck", "Duck"), Summary("Command to hunt for a duck")]
            public async Task IncomingPlayerDuckHuntingRequest()
            {
                if ((DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                {
                    //In future update add a bow durability check

                    //Execution of command
                    HuntingEmbed.WithColor(Color.Blue);
                    HuntingEmbed.AddField("<:Bow:603635600247226368>```Success!```", $"```You have received 1 duck carcass!```");
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());

                    //Save data
                    await CharactersData.SavePlayerHuntingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                    if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) <= 2)
                    {
                        await CharactersData.SaveCharacterDuckCarcass(Context.User.Id, 1, 0.3f);
                    }
                    else
                    {
                        await CharactersData.SaveCharacterDuckCarcass(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id));
                    }
                }
                else
                {
                    //Send message about cooldown
                    HuntingEmbed.WithColor(Color.Blue);
                    if (120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds > 60)
                    {
                        HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                        $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                    }
                    else
                    {
                        HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                        $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds))}s```");
                    }
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("bunny", "Bunny"), Summary("Command to hunt for a bunny")]
            public async Task IncomingPlayerBunnyHuntingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 5)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a bow durability check

                        //Execution of command
                        HuntingEmbed.WithColor(Color.Blue);
                        HuntingEmbed.AddField("<:Bow:603635600247226368>```Success!```", $"```You have received 1 bunny carcass!```");
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerHuntingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterBunnyCarcass(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        HuntingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    HuntingEmbed.WithColor(Color.Blue);
                    HuntingEmbed.AddField($"<:Bow:603635600247226368>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("fox", "Fox"), Summary("Command to hunt for a fox")]
            public async Task IncomingPlayerFoxHuntingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 10)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a bow durability check

                        //Execution of command
                        HuntingEmbed.WithColor(Color.Blue);
                        HuntingEmbed.AddField("<:Bow:603635600247226368>```Success!```", $"```You have received 1 fox carcass!```");
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerHuntingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterFoxCarcass(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        HuntingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    HuntingEmbed.WithColor(Color.Blue);
                    HuntingEmbed.AddField($"<:Bow:603635600247226368>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("wolf", "Wolf"), Summary("Command to hunt for a wolf")]
            public async Task IncomingPlayerWolfHuntingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 15)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a bow durability check

                        //Execution of command
                        HuntingEmbed.WithColor(Color.Blue);
                        HuntingEmbed.AddField("<:Bow:603635600247226368>```Success!```", $"```You have received 1 wolf carcass!```");
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerHuntingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterWolfCarcass(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        HuntingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    HuntingEmbed.WithColor(Color.Blue);
                    HuntingEmbed.AddField($"<:Bow:603635600247226368>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("boar", "Boar"), Summary("Command to hunt for a boar")]
            public async Task IncomingPlayerBoarHuntingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 20)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a bow durability check

                        //Execution of command
                        HuntingEmbed.WithColor(Color.Blue);
                        HuntingEmbed.AddField("<:Bow:603635600247226368>```Success!```", $"```You have received 1 boar carcass!```");
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerHuntingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterBoarCarcass(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        HuntingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    HuntingEmbed.WithColor(Color.Blue);
                    HuntingEmbed.AddField($"<:Bow:603635600247226368>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("deer", "Deer"), Summary("Command to hunt for a deer")]
            public async Task IncomingPlayerDeerHuntingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 25)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a bow durability check

                        //Execution of command
                        HuntingEmbed.WithColor(Color.Blue);
                        HuntingEmbed.AddField("<:Bow:603635600247226368>```Success!```", $"```You have received 1 deer carcass!```");
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerHuntingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterDeerCarcass(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        HuntingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    HuntingEmbed.WithColor(Color.Blue);
                    HuntingEmbed.AddField($"<:Bow:603635600247226368>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("eagle", "Eagle"), Summary("Command to hunt for a eagle")]
            public async Task IncomingPlayerEagleHuntingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 30)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a bow durability check

                        //Execution of command
                        HuntingEmbed.WithColor(Color.Blue);
                        HuntingEmbed.AddField("<:Bow:603635600247226368>```Success!```", $"```You have received 1 eagle carcass!```");
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerHuntingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterEagleCarcass(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        HuntingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    HuntingEmbed.WithColor(Color.Blue);
                    HuntingEmbed.AddField($"<:Bow:603635600247226368>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("buffalo", "Buffalo"), Summary("Command to hunt for a buffalo")]
            public async Task IncomingPlayerBuffaloHuntingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 35)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a bow durability check

                        //Execution of command
                        HuntingEmbed.WithColor(Color.Blue);
                        HuntingEmbed.AddField("<:Bow:603635600247226368>```Success!```", $"```You have received 1 buffalo carcass!```");
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerHuntingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterBuffaloCarcass(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        HuntingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            HuntingEmbed.AddField($"<:Bow:603635600247226368>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to hunt```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterHuntingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    HuntingEmbed.WithColor(Color.Blue);
                    HuntingEmbed.AddField($"<:Bow:603635600247226368>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, HuntingEmbed.Build());
                    return;
                }
            }
        }
    }
}
