using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.Currency
{
    public class Fishing : ModuleBase<SocketCommandContext>
    {
        [Group("Fish"), Alias("fish", "Fishing", "fishing", "F", "f"), Summary("This group should interact with different fishing jobs")]
        public class PlayerFishing : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder FishingEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("carp", "Carp"), Summary("Command to catch a carp")]
            public async Task IncomingPlayerCarpFishingRequest()
            {
                if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                {
                    //In future update add a fishing rod durability check

                    //Execution of command
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a carp!```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                    //Save data
                    await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                    if (CharactersData.GetCharacterFishingSkill(Context.User.Id) <= 2)
                    {
                        await CharactersData.SaveCharacterCarp(Context.User.Id, 1, 0.3f);
                    }
                    else
                    {
                        await CharactersData.SaveCharacterCarp(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                }
                else
                {
                    //Send message about cooldown
                    FishingEmbed.WithColor(Color.Blue);
                    if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                    {
                        FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                        $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                    }
                    else
                    {
                        FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                        $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                    }
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("ruff", "Ruff"), Summary("Command to catch a ruff fish")]
            public async Task IncomingPlayerRuffFishingRequest()
            {
                if(CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 5)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a ruff fish!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterCarp(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("roach", "Roach"), Summary("Command to catch a roach")]
            public async Task IncomingPlayerRoachFishingRequest()
            {
                if (CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 10)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a roach!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterRoach(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("bream", "Bream"), Summary("Command to catch a bream")]
            public async Task IncomingPlayerBreamFishingRequest()
            {
                if (CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 15)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a bream!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterBream(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("rudd", "Rudd"), Summary("Command to catch a rudd fish")]
            public async Task IncomingPlayerRuddFishingRequest()
            {
                if (CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 20)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a rudd fish!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterRuddFish(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("grayling", "Grayling"), Summary("Command to catch a grayling")]
            public async Task IncomingPlayerGraylingFishingRequest()
            {
                if (CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 25)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a grayling!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterGrayling(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("wels", "Wels"), Summary("Command to catch a wels catfish")]
            public async Task IncomingPlayerWelsCatfishFishingRequest()
            {
                if (CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 30)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a wels catfish!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterWelsCatfish(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("trout", "Trout"), Summary("Command to catch a trout")]
            public async Task IncomingPlayerTroutFishingRequest()
            {
                if (CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 35)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a trout!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterTrout(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("sterlet", "Sterlet"), Summary("Command to catch a sterlet")]
            public async Task IncomingPlayerSterletFishingRequest()
            {
                if (CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 40)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a sterlet!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterSterlet(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [40]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("salmon", "Salmon"), Summary("Command to catch a salmon")]
            public async Task IncomingPlayerSalmonFishingRequest()
            {
                if (CharactersData.GetCharacterFishingSkill(Context.User.Id) >= 45)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a fishing rod durability check

                        //Execution of command
                        FishingEmbed.WithColor(Color.Blue);
                        FishingEmbed.AddField("<:FishingRod:603598075239596042>```Success!```", $"```You caught a salmon!```");
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFishingCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown
                        await CharactersData.SaveCharacterSalmon(Context.User.Id, 1, 0.3f / CharactersData.GetCharacterFishingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        FishingEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            FishingEmbed.AddField($"<:FishingRod:603598075239596042>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to go fishing```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFishingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                        return;
                    }
                }
                else
                {
                    FishingEmbed.WithColor(Color.Blue);
                    FishingEmbed.AddField($"<:FishingRod:603598075239596042>```Fishing skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [45]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFishingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, FishingEmbed.Build());
                    return;
                }
            }
        }
    }
}
