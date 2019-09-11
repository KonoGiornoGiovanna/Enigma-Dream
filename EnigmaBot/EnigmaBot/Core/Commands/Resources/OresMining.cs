using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;
using EnigmaBot.Core.Commands.Currency;

namespace EnigmaBot.Core.Commands.Currency
{
    public class OresMining : ModuleBase<SocketCommandContext>
    {
        [Group("Mining"), Alias("mining", "m", "M"), Summary("This group should interact with different mining ores jobs")]
        public class PlayerMining : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder MiningEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("copper","Copper"), Summary("Command to mine a copper ore")]
            public async Task IncomingPlayerCopperMiningRequest()
            {
                if ((DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                {
                    //In future update add a pickaxe durability check

                    //Execution of command
                    int OreToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    MiningEmbed.WithColor(Color.Blue);
                    MiningEmbed.AddField("<:Pickaxe:603957608641986560>```Success!```", $"```You have received {OreToGiveAmount} units of copper ore!```");
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());

                    //Save data
                    await CharactersData.SavePlayerMiningCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                    if(CharactersData.GetCharacterMiningSkill(Context.User.Id) <= 2)
                    {
                        await CharactersData.SaveCharacterCopperOre(Context.User.Id, OreToGiveAmount,0.3f);
                    }
                    else
                    {
                        await CharactersData.SaveCharacterCopperOre(Context.User.Id, OreToGiveAmount, 0.3f/CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    }
                }
                else
                {
                    //Send message about cooldown
                    MiningEmbed.WithColor(Color.Blue);
                    if (120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds > 60)
                    {
                        MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                        $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                    }
                    else
                    {
                        MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                        $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds))}s```");
                    }
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("iron", "Iron"), Summary("Command to mine a iron ore")]
            public async Task IncomingPlayerIronMiningRequest()
            {
                if(CharactersData.GetCharacterMiningSkill(Context.User.Id) >= 5)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a pickaxe durability check

                        //Execution of command
                        int OreToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterMiningSkill(Context.User.Id));
                        MiningEmbed.WithColor(Color.Blue);
                        MiningEmbed.AddField("<:Pickaxe:603957608641986560>```Success!```", $"```You have received {OreToGiveAmount} units of iron ore!```");
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerMiningCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterIronOre(Context.User.Id, OreToGiveAmount, 0.3f / CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        MiningEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                        return;
                    }
                }
                else
                {
                    MiningEmbed.WithColor(Color.Blue);
                    MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```Mining skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterMiningSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("lead", "Lead"), Summary("Command to mine a lead ore")]
            public async Task IncomingPlayerLeadMiningRequest()
            {
                if (CharactersData.GetCharacterMiningSkill(Context.User.Id) >= 10)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a pickaxe durability check

                        //Execution of command
                        int OreToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterMiningSkill(Context.User.Id)/2);
                        MiningEmbed.WithColor(Color.Blue);
                        MiningEmbed.AddField("<:Pickaxe:603957608641986560>```Success!```", $"```You have received {OreToGiveAmount} units of lead ore!```");
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerMiningCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterLeadOre(Context.User.Id, OreToGiveAmount, 0.3f / CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        MiningEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                        return;
                    }
                }
                else
                {
                    MiningEmbed.WithColor(Color.Blue);
                    MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```Mining skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterMiningSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("silver", "Silver"), Summary("Command to mine a silver ore")]
            public async Task IncomingPlayerSilverMiningRequest()
            {
                if (CharactersData.GetCharacterMiningSkill(Context.User.Id) >= 15)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a pickaxe durability check

                        //Execution of command
                        int OreToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterMiningSkill(Context.User.Id) / 2);
                        MiningEmbed.WithColor(Color.Blue);
                        MiningEmbed.AddField("<:Pickaxe:603957608641986560>```Success!```", $"```You have received {OreToGiveAmount} units of silver ore!```");
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerMiningCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterSilverOre(Context.User.Id, OreToGiveAmount, 0.3f / CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        MiningEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                        return;
                    }
                }
                else
                {
                    MiningEmbed.WithColor(Color.Blue);
                    MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```Mining skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterMiningSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("gold", "Gold"), Summary("Command to mine a golden ore")]
            public async Task IncomingPlayerGoldMiningRequest()
            {
                if (CharactersData.GetCharacterMiningSkill(Context.User.Id) >= 20)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a pickaxe durability check

                        //Execution of command
                        int OreToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterMiningSkill(Context.User.Id) / 2);
                        MiningEmbed.WithColor(Color.Blue);
                        MiningEmbed.AddField("<:Pickaxe:603957608641986560>```Success!```", $"```You have received {OreToGiveAmount} units of golden ore!```");
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerMiningCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterGoldenOre(Context.User.Id, OreToGiveAmount, 0.3f / CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        MiningEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                        return;
                    }
                }
                else
                {
                    MiningEmbed.WithColor(Color.Blue);
                    MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```Mining skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterMiningSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("glow", "Glow","Glowing","glowing"), Summary("Command to mine a glowing ore")]
            public async Task IncomingPlayerGlowingOreMiningRequest()
            {
                if (CharactersData.GetCharacterMiningSkill(Context.User.Id) >= 25)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a pickaxe durability check

                        //Execution of command
                        int OreToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterMiningSkill(Context.User.Id) / 2);
                        MiningEmbed.WithColor(Color.Blue);
                        MiningEmbed.AddField("<:Pickaxe:603957608641986560>```Success!```", $"```You have received {OreToGiveAmount} units of glowing ore!```");
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerMiningCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterGlowingOre(Context.User.Id, OreToGiveAmount, 0.3f / CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        MiningEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                        return;
                    }
                }
                else
                {
                    MiningEmbed.WithColor(Color.Blue);
                    MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```Mining skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterMiningSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("meteor", "Meteor","meteorite","Meteorite"), Summary("Command to mine a meteorite ore")]
            public async Task IncomingPlayerMeteoriteMiningRequest()
            {
                if (CharactersData.GetCharacterMiningSkill(Context.User.Id) >= 30)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a pickaxe durability check

                        //Execution of command
                        int OreToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterMiningSkill(Context.User.Id) / 2);
                        MiningEmbed.WithColor(Color.Blue);
                        MiningEmbed.AddField("<:Pickaxe:603957608641986560>```Success!```", $"```You have received {OreToGiveAmount} units of meteorite ore!```");
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerMiningCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterMeteoriteOre(Context.User.Id, OreToGiveAmount, 0.3f / CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        MiningEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                        return;
                    }
                }
                else
                {
                    MiningEmbed.WithColor(Color.Blue);
                    MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```Mining skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterMiningSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("adamant", "Adamant", "adamantite", "Adamantite"), Summary("Command to mine a adamantite ore")]
            public async Task IncomingPlayerAdamantiteMiningRequest()
            {
                if (CharactersData.GetCharacterMiningSkill(Context.User.Id) >= 35)
                {
                    if ((DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds >= 120) // checks if more than 120 seconds have passed between the last requests send by the player
                    {
                        //In future update add a pickaxe durability check

                        //Execution of command
                        int OreToGiveAmount = random.Next(1, 5) + Convert.ToInt32(CharactersData.GetCharacterMiningSkill(Context.User.Id) / 2);
                        MiningEmbed.WithColor(Color.Blue);
                        MiningEmbed.AddField("<:Pickaxe:603957608641986560>```Success!```", $"```You have received {OreToGiveAmount} units of adamantite ore!```");
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());

                        //Save data
                        await CharactersData.SavePlayerMiningCooldown(Context.User.Id, DateTime.Now); //Refresh cooldown for mining
                        await CharactersData.SaveCharacterAdamantiteOre(Context.User.Id, OreToGiveAmount, 0.3f / CharactersData.GetCharacterMiningSkill(Context.User.Id));
                    }
                    else
                    {
                        //Send message about cooldown
                        MiningEmbed.WithColor(Color.Blue);
                        if (120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds > 60)
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in 1m {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds - 60))}s```");
                        }
                        else
                        {
                            MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```{CharactersData.GetCharacterName(Context.User.Id)}, you're too exhausted to mine ores```",
                            $"```Try again in {Math.Round(Convert.ToDecimal(120 - (DateTime.Now - CharactersData.GetCharacterMiningCooldown(Context.User.Id)).TotalSeconds))}s```");
                        }
                        await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                        return;
                    }
                }
                else
                {
                    MiningEmbed.WithColor(Color.Blue);
                    MiningEmbed.AddField($"<:Pickaxe:603957608641986560>```Mining skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterMiningSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, MiningEmbed.Build());
                    return;
                }
            }
        }
    }
}
