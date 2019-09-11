using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.Currency
{
    public class Animals : ModuleBase<SocketCommandContext>
    {
        [Group("Animal"), Alias("animal", "A", "a"), Summary("This group should interact with different farm animal jobs")]
        public class PlayerAnimalsFarm : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder AnimalsFarmEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("egg", "Egg","e","E"), Summary("Command to collect chicken eggs")]
            public async Task IncomingPlayerEggsCollectingRequest()
            {
                if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                {
                    //In future update add a axe durability check

                    //Execution of command
                    int AnimalLootToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    AnimalsFarmEmbed.WithColor(Color.Blue);
                    AnimalsFarmEmbed.AddField("<:milkBar:604047741189881857>```Success!```", $"```You have received {AnimalLootToGiveAmount} eggs!```");
                    await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());

                    //Save data
                    await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                    if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) <= 2)
                    {
                        await CharactersData.SaveCharacterEggsAmount(Context.User.Id, AnimalLootToGiveAmount, 0.3f);
                    }
                    else
                    {
                        await CharactersData.SaveCharacterEggsAmount(Context.User.Id, AnimalLootToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                }
                else
                {
                    //Send message about cooldown
                    AnimalsFarmEmbed.WithColor(Color.Blue);
                    if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                    {
                        AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect farm loot```",
                        $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                    }
                    else
                    {
                        AnimalsFarmEmbed.AddField($"<:Wheat:603957637947588608>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect farm loot```",
                        $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                    }
                    await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("chicken", "Chicken","c","C"), Summary("Command to collect chicken meat")]
            public async Task IncomingPlayerChickenMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 5)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int AnimalLootToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        AnimalsFarmEmbed.AddField("<:milkBar:604047741189881857>```Success!```", $"```You have received {AnimalLootToGiveAmount} units of chicken meat!```");
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterChickenMeat(Context.User.Id, AnimalLootToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    AnimalsFarmEmbed.WithColor(Color.Blue);
                    AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("wool", "Wool", "w", "W"), Summary("Command to collect wool")]
            public async Task IncomingPlayerWoolCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 10)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int AnimalLootToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        AnimalsFarmEmbed.AddField("<:milkBar:604047741189881857>```Success!```", $"```You have received {AnimalLootToGiveAmount} units of wool!```");
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterWoolAmount(Context.User.Id, AnimalLootToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    AnimalsFarmEmbed.WithColor(Color.Blue);
                    AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("sheep", "Sheep", "s", "S"), Summary("Command to collect sheep meat")]
            public async Task IncomingPlayerSheepMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 15)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int AnimalLootToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        AnimalsFarmEmbed.AddField("<:milkBar:604047741189881857>```Success!```", $"```You have received {AnimalLootToGiveAmount} units of sheep meat!```");
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterSheepMeat(Context.User.Id, AnimalLootToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    AnimalsFarmEmbed.WithColor(Color.Blue);
                    AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("milk", "Milk", "m", "M"), Summary("Command to collect milk")]
            public async Task IncomingPlayerMilkCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 25)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int AnimalLootToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        AnimalsFarmEmbed.AddField("<:milkBar:604047741189881857>```Success!```", $"```You have received {AnimalLootToGiveAmount} units of milk!```");
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterMilkAmount(Context.User.Id, AnimalLootToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    AnimalsFarmEmbed.WithColor(Color.Blue);
                    AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("beef", "Beef", "b", "B"), Summary("Command to collect beef")]
            public async Task IncomingPlayerBeefCollectingRequest()
            {
                if (CharactersData.GetCharacterFarmingSkill(Context.User.Id) >= 35)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a axe durability check

                        //Execution of command
                        int AnimalLootToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        AnimalsFarmEmbed.AddField("<:milkBar:604047741189881857>```Success!```", $"```You have received {AnimalLootToGiveAmount} units of beef!```");
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerFarmCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterBeef(Context.User.Id, AnimalLootToGiveAmount, 0.3f / CharactersData.GetCharacterFarmingSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        AnimalsFarmEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to collect animal loot```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterFarmingCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                        return;
                    }
                }
                else
                {
                    AnimalsFarmEmbed.WithColor(Color.Blue);
                    AnimalsFarmEmbed.AddField($"<:milkBar:604047741189881857>```Farming skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterFarmingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, AnimalsFarmEmbed.Build());
                    return;
                }
            }
        }
    }
}
