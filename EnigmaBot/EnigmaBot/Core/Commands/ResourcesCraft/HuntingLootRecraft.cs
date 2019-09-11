using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.ResourcesCraft
{
    public class HuntingLootRecraft : ModuleBase<SocketCommandContext>
    {
        [Group("Leather"), Alias("leather", "l", "L"), Summary("This group should interact with different hunting loot reworking jobs")]
        public class PlayerLeatherCollect : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder LeatherEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("duck", "Duck"), Summary("Command for collecting a feathers from duck")]
            public async Task IncomingPlayerDuckFeathersCollectRequest()
            {
                //Checking commands
                if (CharactersData.GetCharacterDuckCarcass(Context.User.Id) < 1)
                {
                    LeatherEmbed.WithColor(Color.Blue);
                    LeatherEmbed.AddField("<:Knife:607575664987734026>```You don't have enough duck carcasses to collect feathers from them!```", "```At least 1 duck carcass required!```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                    return;
                }
                //Execution of command
                LeatherEmbed.WithColor(Color.Blue);
                int TotalFeathersToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusFeathers, FeathersToGive;
                for (int i = CharactersData.GetCharacterDuckCarcass(Context.User.Id); i >= 1; i -= 1)
                {
                    ChanceToGetBonusFeathers = random.Next(0, 10);
                    if (ChanceToGetBonusFeathers > (7 - CharactersData.GetCharacterHuntingSkill(Context.User.Id) / 10))
                    { FeathersToGive = random.Next(3, 6); }
                    else
                    { FeathersToGive = random.Next(2, 4); }
                    TotalFeathersToGive += FeathersToGive;
                    TotalCarcassesToTook += 1;
                }
                LeatherEmbed.AddField("<:Knife:607575664987734026>```Success!```", $"```You have received {TotalFeathersToGive} duck feathers!```");
                await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());

                //Save data
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) <= 2)
                {
                    await CharactersData.SaveCharacterDuckFeathers(Context.User.Id, TotalFeathersToGive, 0.3f, TotalCarcassesToTook);
                }
                else
                {
                    await CharactersData.SaveCharacterDuckFeathers(Context.User.Id, TotalFeathersToGive, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id), TotalCarcassesToTook); ;
                }
                return;
            }

            [Command(""), Alias("bunny", "Bunny"), Summary("Command for collecting a leather from bunny")]
            public async Task IncomingPlayerBunnyLeatherCollectingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 5)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterBunnyCarcass(Context.User.Id) < 1)
                    {
                        LeatherEmbed.WithColor(Color.Blue);
                        LeatherEmbed.AddField("<:Knife:607575664987734026>```You don't have enough bunny carcasses to collect leather from them!```", "```At least 1 bunny carcass required```");
                        await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                        return;
                    }
                    //Execution of command
                    LeatherEmbed.WithColor(Color.Blue);
                    int TotalLeatherToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusLeather, LeatherToGive;
                    for (int i = CharactersData.GetCharacterBunnyCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusLeather = random.Next(0, 10);
                        if (ChanceToGetBonusLeather > (7 - CharactersData.GetCharacterHuntingSkill(Context.User.Id) / 12))
                        { LeatherToGive = random.Next(3, 4); }
                        else
                        { LeatherToGive = random.Next(1, 2); }
                        TotalLeatherToGive += LeatherToGive;
                        TotalCarcassesToTook += 1;
                    }
                    LeatherEmbed.AddField("<:Knife:607575664987734026>```Success!```", $"```You have received {TotalLeatherToGive} units of bunny leather!```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterBunnyLeather(Context.User.Id, TotalLeatherToGive, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    LeatherEmbed.WithColor(Color.Blue);
                    LeatherEmbed.AddField($"<:Knife:607575664987734026>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("fox", "Fox"), Summary("Command for collecting a leather from fox")]
            public async Task IncomingPlayerFoxLeatherCollectingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 10)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterFoxCarcass(Context.User.Id) < 1)
                    {
                        LeatherEmbed.WithColor(Color.Blue);
                        LeatherEmbed.AddField("<:Knife:607575664987734026>```You don't have enough fox carcasses to collect leather from them!```", "```At least 1 fox carcass required```");
                        await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                        return;
                    }
                    //Execution of command
                    LeatherEmbed.WithColor(Color.Blue);
                    int TotalLeatherToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusLeather, LeatherToGive;
                    for (int i = CharactersData.GetCharacterFoxCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusLeather = random.Next(0, 10);
                        if (ChanceToGetBonusLeather > (7 - CharactersData.GetCharacterHuntingSkill(Context.User.Id) / 14))
                        { LeatherToGive = random.Next(3, 4); }
                        else
                        { LeatherToGive = random.Next(1, 2); }
                        TotalLeatherToGive += LeatherToGive;
                        TotalCarcassesToTook += 1;
                    }
                    LeatherEmbed.AddField("<:Knife:607575664987734026>```Success!```", $"```You have received {TotalLeatherToGive} units of fox leather!```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterFoxLeather(Context.User.Id, TotalLeatherToGive, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    LeatherEmbed.WithColor(Color.Blue);
                    LeatherEmbed.AddField($"<:Knife:607575664987734026>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("wolf", "Wolf"), Summary("Command for collecting a leather from wolf")]
            public async Task IncomingPlayerWolfLeatherCollectingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 15)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterWolfCarcass(Context.User.Id) < 1)
                    {
                        LeatherEmbed.WithColor(Color.Blue);
                        LeatherEmbed.AddField("<:Knife:607575664987734026>```You don't have enough wolf carcasses to collect leather from them!```", "```At least 1 wolf carcass required```");
                        await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                        return;
                    }
                    //Execution of command
                    LeatherEmbed.WithColor(Color.Blue);
                    int TotalLeatherToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusLeather, LeatherToGive;
                    for (int i = CharactersData.GetCharacterWolfCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusLeather = random.Next(0, 10);
                        if (ChanceToGetBonusLeather > (7 - CharactersData.GetCharacterHuntingSkill(Context.User.Id) / 16))
                        { LeatherToGive = random.Next(3, 4); }
                        else
                        { LeatherToGive = random.Next(1, 2); }
                        TotalLeatherToGive += LeatherToGive;
                        TotalCarcassesToTook += 1;
                    }
                    LeatherEmbed.AddField("<:Knife:607575664987734026>```Success!```", $"```You have received {TotalLeatherToGive} units of wolf leather!```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterWolfLeather(Context.User.Id, TotalLeatherToGive, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    LeatherEmbed.WithColor(Color.Blue);
                    LeatherEmbed.AddField($"<:Knife:607575664987734026>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("boar", "Boar"), Summary("Command for collecting a leather from boar")]
            public async Task IncomingPlayerBoarLeatherCollectingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 20)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterBoarCarcass(Context.User.Id) < 1)
                    {
                        LeatherEmbed.WithColor(Color.Blue);
                        LeatherEmbed.AddField("<:Knife:607575664987734026>```You don't have enough boar carcasses to collect leather from them!```", "```At least 1 boar carcass required```");
                        await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                        return;
                    }
                    //Execution of command
                    LeatherEmbed.WithColor(Color.Blue);
                    int TotalLeatherToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusLeather, LeatherToGive;
                    for (int i = CharactersData.GetCharacterBoarCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusLeather = random.Next(0, 10);
                        if (ChanceToGetBonusLeather > (7 - CharactersData.GetCharacterHuntingSkill(Context.User.Id) / 18))
                        { LeatherToGive = random.Next(3, 4); }
                        else
                        { LeatherToGive = random.Next(1, 2); }
                        TotalLeatherToGive += LeatherToGive;
                        TotalCarcassesToTook += 1;
                    }
                    LeatherEmbed.AddField("<:Knife:607575664987734026>```Success!```", $"```You have received {TotalLeatherToGive} units of boar leather!```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterBoarLeather(Context.User.Id, TotalLeatherToGive, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    LeatherEmbed.WithColor(Color.Blue);
                    LeatherEmbed.AddField($"<:Knife:607575664987734026>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("deer", "Deer"), Summary("Command for collecting a leather from deer")]
            public async Task IncomingPlayerDeerLeatherCollectingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 25)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterDeerCarcass(Context.User.Id) < 1)
                    {
                        LeatherEmbed.WithColor(Color.Blue);
                        LeatherEmbed.AddField("<:Knife:607575664987734026>```You don't have enough deer carcasses to collect leather from them!```", "```At least 1 deer carcass required```");
                        await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                        return;
                    }
                    //Execution of command
                    LeatherEmbed.WithColor(Color.Blue);
                    int TotalLeatherToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusLeather, LeatherToGive;
                    for (int i = CharactersData.GetCharacterDeerCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusLeather = random.Next(0, 10);
                        if (ChanceToGetBonusLeather > (7 - CharactersData.GetCharacterHuntingSkill(Context.User.Id) / 20))
                        { LeatherToGive = random.Next(3, 4); }
                        else
                        { LeatherToGive = random.Next(1, 2); }
                        TotalLeatherToGive += LeatherToGive;
                        TotalCarcassesToTook += 1;
                    }
                    LeatherEmbed.AddField("<:Knife:607575664987734026>```Success!```", $"```You have received {TotalLeatherToGive} units of deer leather!```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterDeerLeather(Context.User.Id, TotalLeatherToGive, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    LeatherEmbed.WithColor(Color.Blue);
                    LeatherEmbed.AddField($"<:Knife:607575664987734026>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("eagle", "Eagle"), Summary("Command for collecting a feathers from eagle")]
            public async Task IncomingPlayerEagleFeathersCollectingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 30)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterEagleCarcass(Context.User.Id) < 1)
                    {
                        LeatherEmbed.WithColor(Color.Blue);
                        LeatherEmbed.AddField("<:Knife:607575664987734026>```You don't have enough eagle carcasses to collect feathers from them!```", "```At least 1 eagle carcass required```");
                        await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                        return;
                    }
                    //Execution of command
                    LeatherEmbed.WithColor(Color.Blue);
                    int TotalLeatherToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusLeather, LeatherToGive;
                    for (int i = CharactersData.GetCharacterEagleCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusLeather = random.Next(0, 10);
                        if (ChanceToGetBonusLeather > (7 - CharactersData.GetCharacterHuntingSkill(Context.User.Id) / 22))
                        { LeatherToGive = random.Next(3, 4); }
                        else
                        { LeatherToGive = random.Next(1, 2); }
                        TotalLeatherToGive += LeatherToGive;
                        TotalCarcassesToTook += 1;
                    }
                    LeatherEmbed.AddField("<:Knife:607575664987734026>```Success!```", $"```You have received {TotalLeatherToGive} eagle feathers!```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterEagleFeathers(Context.User.Id, TotalLeatherToGive, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    LeatherEmbed.WithColor(Color.Blue);
                    LeatherEmbed.AddField($"<:Knife:607575664987734026>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("buffalo", "Buffalo"), Summary("Command for collecting a leather from buffalo")]
            public async Task IncomingPlayerBuffaloLeatherCollectingRequest()
            {
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) >= 35)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterBuffaloCarcass(Context.User.Id) < 1)
                    {
                        LeatherEmbed.WithColor(Color.Blue);
                        LeatherEmbed.AddField("<:Knife:607575664987734026>```You don't have enough buffalo carcasses to collect leather from them!```", "```At least 1 buffalo carcass required```");
                        await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                        return;
                    }
                    //Execution of command
                    LeatherEmbed.WithColor(Color.Blue);
                    int TotalLeatherToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusLeather, LeatherToGive;
                    for (int i = CharactersData.GetCharacterBuffaloCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusLeather = random.Next(0, 10);
                        if (ChanceToGetBonusLeather > (7 - CharactersData.GetCharacterHuntingSkill(Context.User.Id) / 24))
                        { LeatherToGive = random.Next(3, 4); }
                        else
                        { LeatherToGive = random.Next(1, 2); }
                        TotalLeatherToGive += LeatherToGive;
                        TotalCarcassesToTook += 1;
                    }
                    LeatherEmbed.AddField("<:Knife:607575664987734026>```Success!```", $"```You have received {TotalLeatherToGive} units of buffalo leather!```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterBuffaloLeather(Context.User.Id, TotalLeatherToGive, 0.3f / CharactersData.GetCharacterHuntingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    LeatherEmbed.WithColor(Color.Blue);
                    LeatherEmbed.AddField($"<:Knife:607575664987734026>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterHuntingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, LeatherEmbed.Build());
                    return;
                }
            }
        }
    }
}
