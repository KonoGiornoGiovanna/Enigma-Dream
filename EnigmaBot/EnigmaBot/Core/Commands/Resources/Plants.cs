using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.Currency
{
    public class Plants : ModuleBase<SocketCommandContext>
    {
        [Group("Plant"), Alias("plant", "P", "p"), Summary("This group should interact with different farm plant jobs")]
        public class PlayerPlantsFarm : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder PlantsFarmEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("wheat", "Wheat"), Summary("Command to collect wheat")]
            public async Task IncomingPlayerWheatCollectingRequest()
            {
                if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                {
                    //In future update add a axe durability check

                    //Execution of command
                    int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} units of wheat!```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                    //Save data
                    await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                    if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) <= 2)
                    {
                        await CharactersData.SaveCharacterWheat(Context.User.Id, PlantsToGiveAmount, 0.3f);
                    }
                    else
                    {
                        await CharactersData.SaveCharacterWheat(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                }
                else
                {
                    //Send message about cooldown
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                    {
                        PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                        $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                    }
                    else
                    {
                        PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                        $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                    }
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("potato", "Potato"), Summary("Command to collect potatoes")]
            public async Task IncomingPlayerPotatoCollectingRequest()
            {
                if(CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 5)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} potatoes!```");
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterPotato(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("corn", "Corn"), Summary("Command to collect corn")]
            public async Task IncomingPlayerCornCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 10)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} corn pots!```");
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterCorn(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("tomato", "Tomato"), Summary("Command to collect tomato")]
            public async Task IncomingPlayerTomatoCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 15)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} tomatoes!```");
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterTomato(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("cotton", "Cotton"), Summary("Command to collect cotton")]
            public async Task IncomingPlayerCottonCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 20)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} units of cotton!```");
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterCotton(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("strawberry", "Strawberry"), Summary("Command to collect strawberry")]
            public async Task IncomingPlayerStrawberryCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 25)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} strawberries!```");
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterStrawberry(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("grapes", "Grapes"), Summary("Command to collect grapes")]
            public async Task IncomingPlayerGrapesCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 30)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} bunches of grapes!```");
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterGrapes(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("pepper", "Pepper"), Summary("Command to collect sweet pepper")]
            public async Task IncomingPlayerPepperCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 35)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} sweet peppers!```");
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterSweetPepper(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("raspberry", "Raspberry"), Summary("Command to collect raspberry")]
            public async Task IncomingPlayerRaspberryCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 40)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int PlantsToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        PlantsFarmEmbed.AddField("<:Wheat:603957637947588608>```Success!```", $"```You have received {PlantsToGiveAmount} raspberries!```");
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterRaspberry(Context.User.Id, PlantsToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        PlantsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect plants```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    PlantsFarmEmbed.WithColor(Color.Blue);
                    PlantsFarmEmbed.AddField($"<:Wheat:603957637947588608>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [40]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, PlantsFarmEmbed.Build());
                    return;
                }
            }
        }
    }
}
