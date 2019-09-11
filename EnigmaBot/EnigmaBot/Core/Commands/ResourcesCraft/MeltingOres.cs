using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.Currency
{
    public class MeltingOres : ModuleBase<SocketCommandContext>
    {
        [Group("Remelting"), Alias("remelting", "r", "R"), Summary("This group should interact with different remelting ores jobs")]
        public class PlayerRemelting : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder RemeltingEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("copper", "Copper"), Summary("Command for remelting a copper ore")]
            public async Task IncomingPlayerCopperRemeltingRequest()
            {
                //Checking commands
                if(CharactersData.GetCharacterCopperOre(Context.User.Id) < 5)
                {
                    RemeltingEmbed.WithColor(Color.Blue);
                    RemeltingEmbed.AddField("<:Iron:603979800092344340>```You don't have enought copper to remelt it!```", $"```You need {5 - CharactersData.GetCharacterCopperOre(Context.User.Id)} more units of copper ore```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                    return;
                }
                //Execution of command
                RemeltingEmbed.WithColor(Color.Blue);
                int TotalBarsToGive = 0, TotalOreToTook = 0;
                for(int i = CharactersData.GetCharacterCopperOre(Context.User.Id); i >= 5; i -= 5)
                {
                    int ChanceToGetBonusBars = random.Next(0, 10);
                    int RemeltedBarsToGive;
                    if (ChanceToGetBonusBars > (7 - CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)/10))
                    { RemeltedBarsToGive = random.Next(2, 3); }
                    else
                    { RemeltedBarsToGive = 1; }
                    TotalBarsToGive += RemeltedBarsToGive;
                    TotalOreToTook += 5;
                }
                RemeltingEmbed.AddField("<:Iron:603979800092344340>```Success!```", $"```You have received {TotalBarsToGive} copper bars!```");               
                await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());

                //Save data
                if (CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) <= 2)
                {
                    await CharactersData.SaveCharacterRemeltedCopper(Context.User.Id, TotalBarsToGive, 0.3f, TotalOreToTook);
                }
                else
                {
                    await CharactersData.SaveCharacterRemeltedCopper(Context.User.Id, TotalBarsToGive, 0.3f / CharactersData.GetCharacterOreMeltingSkill(Context.User.Id), TotalOreToTook); ;
                }
                return;           
            }

            [Command(""), Alias("iron", "Iron"), Summary("Command for remelting a iron ore")]
            public async Task IncomingPlayerIronRemeltingRequest()
            {
                if (CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) >= 5)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterIronOre(Context.User.Id) < 5)
                    {
                        RemeltingEmbed.WithColor(Color.Blue);
                        RemeltingEmbed.AddField("<:Iron:603979800092344340>```You don't have enought iron to remelt it!```", $"```You need {5 - CharactersData.GetCharacterIronOre(Context.User.Id)} more units of iron ore```");
                        await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    RemeltingEmbed.WithColor(Color.Blue);
                    int TotalBarsToGive = 0, TotalOreToTook = 0;
                    for (int i = CharactersData.GetCharacterIronOre(Context.User.Id); i >= 5; i -= 5)
                    {
                        int ChanceToGetBonusBars = random.Next(0, 10);
                        int RemeltedBarsToGive;
                        if (ChanceToGetBonusBars > (7 - CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) / 12))
                        { RemeltedBarsToGive = random.Next(2, 3); }
                        else
                        { RemeltedBarsToGive = 1; }
                        TotalBarsToGive += RemeltedBarsToGive;
                        TotalOreToTook += 5;
                    }
                    RemeltingEmbed.AddField("<:Iron:603979800092344340>```Success!```", $"```You have received {TotalBarsToGive} iron bars!```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterRemeltedIron(Context.User.Id, TotalBarsToGive, 0.3f / CharactersData.GetCharacterOreMeltingSkill(Context.User.Id), TotalOreToTook); ;
                    return;
                }
                else
                {
                    RemeltingEmbed.WithColor(Color.Blue);
                    RemeltingEmbed.AddField($"<:Iron:603979800092344340>```Remelting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("lead", "Lead"), Summary("Command for remelting a lead ore")]
            public async Task IncomingPlayerLeadRemeltingRequest()
            {
                if (CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) >= 10)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterLeadOre(Context.User.Id) < 5)
                    {
                        RemeltingEmbed.WithColor(Color.Blue);
                        RemeltingEmbed.AddField("<:Iron:603979800092344340>```You don't have enought lead to remelt it!```", $"```You need {5 - CharactersData.GetCharacterLeadOre(Context.User.Id)} more units of lead ore```");
                        await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    RemeltingEmbed.WithColor(Color.Blue);
                    int TotalBarsToGive = 0, TotalOreToTook = 0;
                    for (int i = CharactersData.GetCharacterLeadOre(Context.User.Id); i >= 5; i -= 5)
                    {
                        int ChanceToGetBonusBars = random.Next(0, 10);
                        int RemeltedBarsToGive;
                        if (ChanceToGetBonusBars > (7 - CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) / 14))
                        { RemeltedBarsToGive = random.Next(2, 3); }
                        else
                        { RemeltedBarsToGive = 1; }
                        TotalBarsToGive += RemeltedBarsToGive;
                        TotalOreToTook += 5;
                    }
                    RemeltingEmbed.AddField("<:Iron:603979800092344340>```Success!```", $"```You have received {TotalBarsToGive} lead bars!```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterRemeltedLead(Context.User.Id, TotalBarsToGive, 0.3f / CharactersData.GetCharacterOreMeltingSkill(Context.User.Id), TotalOreToTook); ;
                    return;
                }
                else
                {
                    RemeltingEmbed.WithColor(Color.Blue);
                    RemeltingEmbed.AddField($"<:Iron:603979800092344340>```Remelting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("silver", "Silver"), Summary("Command for remelting a silver ore")]
            public async Task IncomingPlayerSilverRemeltingRequest()
            {
                if (CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) >= 15)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterSilverOre(Context.User.Id) < 5)
                    {
                        RemeltingEmbed.WithColor(Color.Blue);
                        RemeltingEmbed.AddField("<:Iron:603979800092344340>```You don't have enought silver to remelt it!```", $"```You need {5 - CharactersData.GetCharacterSilverOre(Context.User.Id)} more units of silver ore```");
                        await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    RemeltingEmbed.WithColor(Color.Blue);
                    int TotalBarsToGive = 0, TotalOreToTook = 0;
                    for (int i = CharactersData.GetCharacterSilverOre(Context.User.Id); i >= 5; i -= 5)
                    {
                        int ChanceToGetBonusBars = random.Next(0, 10);
                        int RemeltedBarsToGive;
                        if (ChanceToGetBonusBars > (7 - CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) / 16))
                        { RemeltedBarsToGive = random.Next(2, 3); }
                        else
                        { RemeltedBarsToGive = 1; }
                        TotalBarsToGive += RemeltedBarsToGive;
                        TotalOreToTook += 5;
                    }
                    RemeltingEmbed.AddField("<:Iron:603979800092344340>```Success!```", $"```You have received {TotalBarsToGive} silver bars!```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterRemeltedSilver(Context.User.Id, TotalBarsToGive, 0.3f / CharactersData.GetCharacterOreMeltingSkill(Context.User.Id), TotalOreToTook); ;
                    return;
                }
                else
                {
                    RemeltingEmbed.WithColor(Color.Blue);
                    RemeltingEmbed.AddField($"<:Iron:603979800092344340>```Remelting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("gold", "Gold"), Summary("Command for remelting a golden ore")]
            public async Task IncomingPlayerGoldRemeltingRequest()
            {
                if (CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) >= 20)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterGoldenOre(Context.User.Id) < 5)
                    {
                        RemeltingEmbed.WithColor(Color.Blue);
                        RemeltingEmbed.AddField("<:Iron:603979800092344340>```You don't have enought gold to remelt it!```", $"```You need {5 - CharactersData.GetCharacterGoldenOre(Context.User.Id)} more units of golden ore```");
                        await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    RemeltingEmbed.WithColor(Color.Blue);
                    int TotalBarsToGive = 0, TotalOreToTook = 0;
                    for (int i = CharactersData.GetCharacterGoldenOre(Context.User.Id); i >= 5; i -= 5)
                    {
                        int ChanceToGetBonusBars = random.Next(0, 10);
                        int RemeltedBarsToGive;
                        if (ChanceToGetBonusBars > (7 - CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) / 18))
                        { RemeltedBarsToGive = random.Next(2, 3); }
                        else
                        { RemeltedBarsToGive = 1; }
                        TotalBarsToGive += RemeltedBarsToGive;
                        TotalOreToTook += 5;
                    }
                    RemeltingEmbed.AddField("<:Iron:603979800092344340>```Success!```", $"```You have received {TotalBarsToGive} golden bars!```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterRemeltedGold(Context.User.Id, TotalBarsToGive, 0.3f / CharactersData.GetCharacterOreMeltingSkill(Context.User.Id), TotalOreToTook); ;
                    return;
                }
                else
                {
                    RemeltingEmbed.WithColor(Color.Blue);
                    RemeltingEmbed.AddField($"<:Iron:603979800092344340>```Remelting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("glow", "Glow"), Summary("Command for remelting a glowing ore")]
            public async Task IncomingPlayerGlowingOreRemeltingRequest()
            {
                if (CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) >= 25)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterGoldenOre(Context.User.Id) < 5)
                    {
                        RemeltingEmbed.WithColor(Color.Blue);
                        RemeltingEmbed.AddField("<:Iron:603979800092344340>```You don't have enought glowing ore to remelt it!```", $"```You need {5 - CharactersData.GetCharacterGlowingOre(Context.User.Id)} more units of glowing ore```");
                        await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    RemeltingEmbed.WithColor(Color.Blue);
                    int TotalBarsToGive = 0, TotalOreToTook = 0;
                    for (int i = CharactersData.GetCharacterGlowingOre(Context.User.Id); i >= 5; i -= 5)
                    {
                        int ChanceToGetBonusBars = random.Next(0, 10);
                        int RemeltedBarsToGive;
                        if (ChanceToGetBonusBars > (7 - CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) / 20))
                        { RemeltedBarsToGive = random.Next(2, 3); }
                        else
                        { RemeltedBarsToGive = 1; }
                        TotalBarsToGive += RemeltedBarsToGive;
                        TotalOreToTook += 5;
                    }
                    RemeltingEmbed.AddField("<:Iron:603979800092344340>```Success!```", $"```You have received {TotalBarsToGive} glowing bars!```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterRemeltedGlowingOre(Context.User.Id, TotalBarsToGive, 0.3f / CharactersData.GetCharacterOreMeltingSkill(Context.User.Id), TotalOreToTook); ;
                    return;
                }
                else
                {
                    RemeltingEmbed.WithColor(Color.Blue);
                    RemeltingEmbed.AddField($"<:Iron:603979800092344340>```Remelting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("meteor", "Meteor"), Summary("Command for remelting a meteorite ore")]
            public async Task IncomingPlayerMeteoriteOreRemeltingRequest()
            {
                if (CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) >= 30)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterGoldenOre(Context.User.Id) < 5)
                    {
                        RemeltingEmbed.WithColor(Color.Blue);
                        RemeltingEmbed.AddField("<:Iron:603979800092344340>```You don't have enought meteorite ore to remelt it!```", $"```You need {5 - CharactersData.GetCharacterMeteoriteOre(Context.User.Id)} more units of meteorite ore```");
                        await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    RemeltingEmbed.WithColor(Color.Blue);
                    int TotalBarsToGive = 0, TotalOreToTook = 0;
                    for (int i = CharactersData.GetCharacterMeteoriteOre(Context.User.Id); i >= 5; i -= 5)
                    {
                        int ChanceToGetBonusBars = random.Next(0, 10);
                        int RemeltedBarsToGive;
                        if (ChanceToGetBonusBars > (7 - CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) / 22))
                        { RemeltedBarsToGive = random.Next(2, 3); }
                        else
                        { RemeltedBarsToGive = 1; }
                        TotalBarsToGive += RemeltedBarsToGive;
                        TotalOreToTook += 5;
                    }
                    RemeltingEmbed.AddField("<:Iron:603979800092344340>```Success!```", $"```You have received {TotalBarsToGive} meteorite bars!```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterRemeltedMeteoriteOre(Context.User.Id, TotalBarsToGive, 0.3f / CharactersData.GetCharacterOreMeltingSkill(Context.User.Id), TotalOreToTook); ;
                    return;
                }
                else
                {
                    RemeltingEmbed.WithColor(Color.Blue);
                    RemeltingEmbed.AddField($"<:Iron:603979800092344340>```Remelting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("adamant", "Adamant"), Summary("Command for remelting a adamantite ore")]
            public async Task IncomingPlayerAdamantiteOreRemeltingRequest()
            {
                if (CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) >= 35)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterGoldenOre(Context.User.Id) < 5)
                    {
                        RemeltingEmbed.WithColor(Color.Blue);
                        RemeltingEmbed.AddField("<:Iron:603979800092344340>```You don't have enought adamantite ore to remelt it!```", $"```You need {5 - CharactersData.GetCharacterAdamantiteOre(Context.User.Id)} more units of adamantite ore```");
                        await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    RemeltingEmbed.WithColor(Color.Blue);
                    int TotalBarsToGive = 0, TotalOreToTook = 0;
                    for (int i = CharactersData.GetCharacterAdamantiteOre(Context.User.Id); i >= 5; i -= 5)
                    {
                        int ChanceToGetBonusBars = random.Next(0, 10);
                        int RemeltedBarsToGive;
                        if (ChanceToGetBonusBars > (7 - CharactersData.GetCharacterOreMeltingSkill(Context.User.Id) / 24))
                        { RemeltedBarsToGive = random.Next(2, 3); }
                        else
                        { RemeltedBarsToGive = 1; }
                        TotalBarsToGive += RemeltedBarsToGive;
                        TotalOreToTook += 5;
                    }
                    RemeltingEmbed.AddField("<:Iron:603979800092344340>```Success!```", $"```You have received {TotalBarsToGive} adamantite bars!```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterRemeltedAdamantite(Context.User.Id, TotalBarsToGive, 0.3f / CharactersData.GetCharacterOreMeltingSkill(Context.User.Id), TotalOreToTook); ;
                    return;
                }
                else
                {
                    RemeltingEmbed.WithColor(Color.Blue);
                    RemeltingEmbed.AddField($"<:Iron:603979800092344340>```Remelting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, RemeltingEmbed.Build());
                    return;
                }
            }
        }
    }
}
