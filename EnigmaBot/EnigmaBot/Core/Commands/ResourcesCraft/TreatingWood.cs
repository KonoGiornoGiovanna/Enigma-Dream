using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.ResourcesCraft
{
    public class TreatingWood : ModuleBase<SocketCommandContext>
    {
        [Group("Treating"), Alias("treating", "t", "T"), Summary("This group should interact with different treating wood jobs")]
        public class PlayerTreating : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder TreatingEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("ash", "Ash"), Summary("Command for treating a ash wood")]
            public async Task IncomingPlayerAshTreatingRequest()
            {
                //Checking commands
                if (CharactersData.GetCharacterAshWood(Context.User.Id) < 5)
                {
                    TreatingEmbed.WithColor(Color.Blue);
                    TreatingEmbed.AddField("<:Plank:607523563410554880>```You don't have enought ash wood to treat it!```", $"```You need {5 - CharactersData.GetCharacterAshWood(Context.User.Id)} more units of ash wood```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                    return;
                }
                //Execution of command
                TreatingEmbed.WithColor(Color.Blue);
                int TotalPlanksToGive = 0, TotalWoodToTook = 0, ChanceToGetBonusPlanks, TreatedPlanksToGive;
                for (int i = CharactersData.GetCharacterAshWood(Context.User.Id); i >= 5; i -= 5)
                {
                    ChanceToGetBonusPlanks = random.Next(0, 10);
                    if (ChanceToGetBonusPlanks > (7 - CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) / 10))
                    { TreatedPlanksToGive = random.Next(2, 3); }
                    else
                    { TreatedPlanksToGive = 1; }
                    TotalPlanksToGive += TreatedPlanksToGive;
                    TotalWoodToTook += 5;
                }
                TreatingEmbed.AddField("<:Plank:607523563410554880>```Success!```", $"```You have received {TotalPlanksToGive} units of treated ash wood!```");
                await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());

                //Save data
                if (CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) <= 2)
                {
                    await CharactersData.SaveCharacterTheratedAshWood(Context.User.Id, TotalPlanksToGive, 0.3f, TotalWoodToTook);
                }
                else
                {
                    await CharactersData.SaveCharacterTheratedAshWood(Context.User.Id, TotalPlanksToGive, 0.3f / CharactersData.GetCharacterWoodworkingSkill(Context.User.Id), TotalWoodToTook); ;
                }
                return;
            }

            [Command(""), Alias("birch", "Birch"), Summary("Command for treating a birch wood")]
            public async Task IncomingPlayerBirchTreatingRequest()
            {
                if (CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) >= 5)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterBirchWood(Context.User.Id) < 5)
                    {
                        TreatingEmbed.WithColor(Color.Blue);
                        TreatingEmbed.AddField("<:Plank:607523563410554880>```You don't have enought birch wood to treat it!```", $"```You need {5 - CharactersData.GetCharacterBirchWood(Context.User.Id)} more units of birch wood```");
                        await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    TreatingEmbed.WithColor(Color.Blue);
                    int TotalPlanksToGive = 0, TotalWoodToTook = 0, ChanceToGetBonusPlanks, TreatedPlanksToGive;
                    for (int i = CharactersData.GetCharacterBirchWood(Context.User.Id); i >= 5; i -= 5)
                    {
                        ChanceToGetBonusPlanks = random.Next(0, 10);
                        if (ChanceToGetBonusPlanks > (7 - CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) / 12))
                        { TreatedPlanksToGive = random.Next(2, 3); }
                        else
                        { TreatedPlanksToGive = 1; }
                        TotalPlanksToGive += TreatedPlanksToGive;
                        TotalWoodToTook += 5;
                    }
                    TreatingEmbed.AddField("<:Plank:607523563410554880>```Success!```", $"```You have received {TotalPlanksToGive} units of treated birch wood!```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterThreatedBirchWood(Context.User.Id, TotalPlanksToGive, 0.3f / CharactersData.GetCharacterWoodworkingSkill(Context.User.Id), TotalWoodToTook); ;
                    return;
                }
                else
                {
                    TreatingEmbed.WithColor(Color.Blue);
                    TreatingEmbed.AddField($"<:Plank:607523563410554880>```Treating skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodworkingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("maple", "Maple"), Summary("Command for treating a maple wood")]
            public async Task IncomingPlayerMapleTreatingRequest()
            {
                if (CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) >= 10)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterMapleWood(Context.User.Id) < 5)
                    {
                        TreatingEmbed.WithColor(Color.Blue);
                        TreatingEmbed.AddField("<:Plank:607523563410554880>```You don't have enought maple wood to treat it!```", $"```You need {5 - CharactersData.GetCharacterMapleWood(Context.User.Id)} more units of maple wood```");
                        await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    TreatingEmbed.WithColor(Color.Blue);
                    int TotalPlanksToGive = 0, TotalWoodToTook = 0, ChanceToGetBonusPlanks, TreatedPlanksToGive;
                    for (int i = CharactersData.GetCharacterMapleWood(Context.User.Id); i >= 5; i -= 5)
                    {
                        ChanceToGetBonusPlanks = random.Next(0, 10);
                        if (ChanceToGetBonusPlanks > (7 - CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) / 14))
                        { TreatedPlanksToGive = random.Next(2, 3); }
                        else
                        { TreatedPlanksToGive = 1; }
                        TotalPlanksToGive += TreatedPlanksToGive;
                        TotalWoodToTook += 5;
                    }
                    TreatingEmbed.AddField("<:Plank:607523563410554880>```Success!```", $"```You have received {TotalPlanksToGive} units of treated maple wood!```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterThreatedMapleWood(Context.User.Id, TotalPlanksToGive, 0.3f / CharactersData.GetCharacterWoodworkingSkill(Context.User.Id), TotalWoodToTook); ;
                    return;
                }
                else
                {
                    TreatingEmbed.WithColor(Color.Blue);
                    TreatingEmbed.AddField($"<:Plank:607523563410554880>```Treating skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodworkingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("spruce", "Spruce"), Summary("Command for treating a spruce wood")]
            public async Task IncomingPlayerSpruceTreatingRequest()
            {
                if (CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) >= 15)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterSpruceWood(Context.User.Id) < 5)
                    {
                        TreatingEmbed.WithColor(Color.Blue);
                        TreatingEmbed.AddField("<:Plank:607523563410554880>```You don't have enought spruce wood to treat it!```", $"```You need {5 - CharactersData.GetCharacterSpruceWood(Context.User.Id)} more units of spruce wood```");
                        await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    TreatingEmbed.WithColor(Color.Blue);
                    int TotalPlanksToGive = 0, TotalWoodToTook = 0, ChanceToGetBonusPlanks, TreatedPlanksToGive;
                    for (int i = CharactersData.GetCharacterSpruceWood(Context.User.Id); i >= 5; i -= 5)
                    {
                        ChanceToGetBonusPlanks = random.Next(0, 10);
                        if (ChanceToGetBonusPlanks > (7 - CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) / 16))
                        { TreatedPlanksToGive = random.Next(2, 3); }
                        else
                        { TreatedPlanksToGive = 1; }
                        TotalPlanksToGive += TreatedPlanksToGive;
                        TotalWoodToTook += 5;
                    }
                    TreatingEmbed.AddField("<:Plank:607523563410554880>```Success!```", $"```You have received {TotalPlanksToGive} units of treated spruce wood!```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterThreatedSpruceWood(Context.User.Id, TotalPlanksToGive, 0.3f / CharactersData.GetCharacterWoodworkingSkill(Context.User.Id), TotalWoodToTook); ;
                    return;
                }
                else
                {
                    TreatingEmbed.WithColor(Color.Blue);
                    TreatingEmbed.AddField($"<:Plank:607523563410554880>```Treating skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodworkingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("pine", "Pine"), Summary("Command for treating a pine wood")]
            public async Task IncomingPlayerPineTreatingRequest()
            {
                if (CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) >= 20)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterPineWood(Context.User.Id) < 5)
                    {
                        TreatingEmbed.WithColor(Color.Blue);
                        TreatingEmbed.AddField("<:Plank:607523563410554880>```You don't have enought pine wood to treat it!```", $"```You need {5 - CharactersData.GetCharacterPineWood(Context.User.Id)} more units of pine wood```");
                        await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    TreatingEmbed.WithColor(Color.Blue);
                    int TotalPlanksToGive = 0, TotalWoodToTook = 0, ChanceToGetBonusPlanks, TreatedPlanksToGive;
                    for (int i = CharactersData.GetCharacterPineWood(Context.User.Id); i >= 5; i -= 5)
                    {
                        ChanceToGetBonusPlanks = random.Next(0, 10);
                        if (ChanceToGetBonusPlanks > (7 - CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) / 18))
                        { TreatedPlanksToGive = random.Next(2, 3); }
                        else
                        { TreatedPlanksToGive = 1; }
                        TotalPlanksToGive += TreatedPlanksToGive;
                        TotalWoodToTook += 5;
                    }
                    TreatingEmbed.AddField("<:Plank:607523563410554880>```Success!```", $"```You have received {TotalPlanksToGive} units of treated pine wood!```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterThreatedPineWood(Context.User.Id, TotalPlanksToGive, 0.3f / CharactersData.GetCharacterWoodworkingSkill(Context.User.Id), TotalWoodToTook); ;
                    return;
                }
                else
                {
                    TreatingEmbed.WithColor(Color.Blue);
                    TreatingEmbed.AddField($"<:Plank:607523563410554880>```Treating skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodworkingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("oak", "Oak"), Summary("Command for treating a oak wood")]
            public async Task IncomingPlayerOakTreatingRequest()
            {
                if (CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) >= 25)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterOakWood(Context.User.Id) < 5)
                    {
                        TreatingEmbed.WithColor(Color.Blue);
                        TreatingEmbed.AddField("<:Plank:607523563410554880>```You don't have enought oak wood to treat it!```", $"```You need {5 - CharactersData.GetCharacterOakWood(Context.User.Id)} more units of oak wood```");
                        await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    TreatingEmbed.WithColor(Color.Blue);
                    int TotalPlanksToGive = 0, TotalWoodToTook = 0, ChanceToGetBonusPlanks, TreatedPlanksToGive;
                    for (int i = CharactersData.GetCharacterOakWood(Context.User.Id); i >= 5; i -= 5)
                    {
                        ChanceToGetBonusPlanks = random.Next(0, 10);
                        if (ChanceToGetBonusPlanks > (7 - CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) / 20))
                        { TreatedPlanksToGive = random.Next(2, 3); }
                        else
                        { TreatedPlanksToGive = 1; }
                        TotalPlanksToGive += TreatedPlanksToGive;
                        TotalWoodToTook += 5;
                    }
                    TreatingEmbed.AddField("<:Plank:607523563410554880>```Success!```", $"```You have received {TotalPlanksToGive} units of treated oak wood!```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterThreatedOakWood(Context.User.Id, TotalPlanksToGive, 0.3f / CharactersData.GetCharacterWoodworkingSkill(Context.User.Id), TotalWoodToTook); ;
                    return;
                }
                else
                {
                    TreatingEmbed.WithColor(Color.Blue);
                    TreatingEmbed.AddField($"<:Plank:607523563410554880>```Treating skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodworkingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("walnut", "Walnut"), Summary("Command for treating a walnut wood")]
            public async Task IncomingPlayerWalnutTreatingRequest()
            {
                if (CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) >= 30)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterWalnutWood(Context.User.Id) < 5)
                    {
                        TreatingEmbed.WithColor(Color.Blue);
                        TreatingEmbed.AddField("<:Plank:607523563410554880>```You don't have enought walnut wood to treat it!```", $"```You need {5 - CharactersData.GetCharacterWalnutWood(Context.User.Id)} more units of walnut wood```");
                        await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    TreatingEmbed.WithColor(Color.Blue);
                    int TotalPlanksToGive = 0, TotalWoodToTook = 0, ChanceToGetBonusPlanks, TreatedPlanksToGive;
                    for (int i = CharactersData.GetCharacterWalnutWood(Context.User.Id); i >= 5; i -= 5)
                    {
                        ChanceToGetBonusPlanks = random.Next(0, 10);
                        if (ChanceToGetBonusPlanks > (7 - CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) / 22))
                        { TreatedPlanksToGive = random.Next(2, 3); }
                        else
                        { TreatedPlanksToGive = 1; }
                        TotalPlanksToGive += TreatedPlanksToGive;
                        TotalWoodToTook += 5;
                    }
                    TreatingEmbed.AddField("<:Plank:607523563410554880>```Success!```", $"```You have received {TotalPlanksToGive} units of treated walnut wood!```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterThreatedWalnutWood(Context.User.Id, TotalPlanksToGive, 0.3f / CharactersData.GetCharacterWoodworkingSkill(Context.User.Id), TotalWoodToTook); ;
                    return;
                }
                else
                {
                    TreatingEmbed.WithColor(Color.Blue);
                    TreatingEmbed.AddField($"<:Plank:607523563410554880>```Treating skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodworkingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("elven", "Elven"), Summary("Command for treating a elven wood")]
            public async Task IncomingPlayerElvenTreatingRequest()
            {
                if (CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) >= 35)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterElvenWood(Context.User.Id) < 5)
                    {
                        TreatingEmbed.WithColor(Color.Blue);
                        TreatingEmbed.AddField("<:Plank:607523563410554880>```You don't have enought elven wood to treat it!```", $"```You need {5 - CharactersData.GetCharacterElvenWood(Context.User.Id)} more units of elven wood```");
                        await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    TreatingEmbed.WithColor(Color.Blue);
                    int TotalPlanksToGive = 0, TotalWoodToTook = 0, ChanceToGetBonusPlanks, TreatedPlanksToGive;
                    for (int i = CharactersData.GetCharacterElvenWood(Context.User.Id); i >= 5; i -= 5)
                    {
                        ChanceToGetBonusPlanks = random.Next(0, 10);
                        if (ChanceToGetBonusPlanks > (7 - CharactersData.GetCharacterWoodworkingSkill(Context.User.Id) / 24))
                        { TreatedPlanksToGive = random.Next(2, 3); }
                        else
                        { TreatedPlanksToGive = 1; }
                        TotalPlanksToGive += TreatedPlanksToGive;
                        TotalWoodToTook += 5;
                    }
                    TreatingEmbed.AddField("<:Plank:607523563410554880>```Success!```", $"```You have received {TotalPlanksToGive} units of treated elven wood!```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterThreatedElvenWood(Context.User.Id, TotalPlanksToGive, 0.3f / CharactersData.GetCharacterWoodworkingSkill(Context.User.Id), TotalWoodToTook); ;
                    return;
                }
                else
                {
                    TreatingEmbed.WithColor(Color.Blue);
                    TreatingEmbed.AddField($"<:Plank:607523563410554880>```Treating skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterWoodworkingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, TreatingEmbed.Build());
                    return;
                }
            }
        }
    }
}
