using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.ItemsCreation
{
    public class Cooking : ModuleBase<SocketCommandContext>
    {
        [Group("Cooking"), Alias("cooking", "c", "C"), Summary("This group should interact with different cooking recipes")]
        public class PlayerCooking : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder CookingEmbed = new EmbedBuilder();
            Random random = new Random();

            [Command(""), Alias("duck", "Duck"), Summary("Command for collecting a meat from duck")]
            public async Task IncomingPlayerDuckMeatCollectRequest()
            {
                //Checking commands
                if (CharactersData.GetCharacterDuckCarcass(Context.User.Id) < 1)
                {
                    CookingEmbed.WithColor(Color.Blue);
                    CookingEmbed.AddField("<:Meat:607579880569307146>```You don't have enough duck carcasses to collect meat from them!```", "```At least 1 duck carcass required!```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                    return;
                }
                //Execution of command
                CookingEmbed.WithColor(Color.Blue);
                int TotalMeatToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusMeat, MeatToGive;
                for (int i = CharactersData.GetCharacterDuckCarcass(Context.User.Id); i >= 1; i -= 1)
                {
                    ChanceToGetBonusMeat = random.Next(0, 10);
                    if (ChanceToGetBonusMeat > (7 - CharactersData.GetCharacterCookingSkill(Context.User.Id) / 10))
                    { MeatToGive = random.Next(3, 6); }
                    else
                    { MeatToGive = random.Next(2, 4); }
                    TotalMeatToGive += MeatToGive;
                    TotalCarcassesToTook += 1;
                }
                CookingEmbed.AddField("<:Meat:607579880569307146>```Success!```", $"```You have received {TotalMeatToGive} duck meat!```");
                await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());

                //Save data
                if (CharactersData.GetCharacterHuntingSkill(Context.User.Id) <= 2)
                {
                    await CharactersData.SaveCharacterDuckMeat(Context.User.Id, TotalMeatToGive, 0.3f, TotalCarcassesToTook);
                }
                else
                {
                    await CharactersData.SaveCharacterDuckMeat(Context.User.Id, TotalMeatToGive, 0.3f / CharactersData.GetCharacterCookingSkill(Context.User.Id), TotalCarcassesToTook); ;
                }
                return;
            }

            [Command(""), Alias("bunny", "Bunny"), Summary("Command for collecting a meat from bunny")]
            public async Task IncomingPlayerBunnyMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterCookingSkill(Context.User.Id) >= 5)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterBunnyCarcass(Context.User.Id) < 1)
                    {
                        CookingEmbed.WithColor(Color.Blue);
                        CookingEmbed.AddField("<:Meat:607579880569307146>```You don't have enough bunny carcasses to collect meat from them!```", "```At least 1 bunny carcass required```");
                        await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    CookingEmbed.WithColor(Color.Blue);
                    int TotalMeatToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusMeat, MeatToGive;
                    for (int i = CharactersData.GetCharacterBunnyCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusMeat = random.Next(0, 10);
                        if (ChanceToGetBonusMeat > (7 - CharactersData.GetCharacterCookingSkill(Context.User.Id) / 12))
                        { MeatToGive = random.Next(3, 6); }
                        else
                        { MeatToGive = random.Next(2, 4); }
                        TotalMeatToGive += MeatToGive;
                        TotalCarcassesToTook += 1;
                    }
                    CookingEmbed.AddField("<:Meat:607579880569307146>```Success!```", $"```You have received {TotalMeatToGive} units of bunny meat!```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterBunnyMeat(Context.User.Id, TotalMeatToGive, 0.3f / CharactersData.GetCharacterCookingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    CookingEmbed.WithColor(Color.Blue);
                    CookingEmbed.AddField($"<:Meat:607579880569307146>```Cooking skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [5]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterCookingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("fox", "Fox"), Summary("Command for collecting a meat from fox")]
            public async Task IncomingPlayerFoxMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterCookingSkill(Context.User.Id) >= 10)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterFoxCarcass(Context.User.Id) < 1)
                    {
                        CookingEmbed.WithColor(Color.Blue);
                        CookingEmbed.AddField("<:Meat:607579880569307146>```You don't have enough fox carcasses to collect meat from them!```", "```At least 1 fox carcass required```");
                        await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    CookingEmbed.WithColor(Color.Blue);
                    int TotalMeatToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusMeat, MeatToGive;
                    for (int i = CharactersData.GetCharacterFoxCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusMeat = random.Next(0, 10);
                        if (ChanceToGetBonusMeat > (7 - CharactersData.GetCharacterCookingSkill(Context.User.Id) / 14))
                        { MeatToGive = random.Next(3, 6); }
                        else
                        { MeatToGive = random.Next(2, 4); }
                        TotalMeatToGive += MeatToGive;
                        TotalCarcassesToTook += 1;
                    }
                    CookingEmbed.AddField("<:Meat:607579880569307146>```Success!```", $"```You have received {TotalMeatToGive} units of fox meat!```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterFoxMeat(Context.User.Id, TotalMeatToGive, 0.3f / CharactersData.GetCharacterCookingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    CookingEmbed.WithColor(Color.Blue);
                    CookingEmbed.AddField($"<:Meat:607579880569307146>```Cooking skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [10]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterCookingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("wolf", "Wolf"), Summary("Command for collecting a meat from wolf")]
            public async Task IncomingPlayerWolfMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterCookingSkill(Context.User.Id) >= 15)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterWolfCarcass(Context.User.Id) < 1)
                    {
                        CookingEmbed.WithColor(Color.Blue);
                        CookingEmbed.AddField("<:Meat:607579880569307146>```You don't have enough wolf carcasses to collect meat from them!```", "```At least 1 wolf carcass required```");
                        await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    CookingEmbed.WithColor(Color.Blue);
                    int TotalMeatToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusMeat, MeatToGive;
                    for (int i = CharactersData.GetCharacterWolfCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusMeat = random.Next(0, 10);
                        if (ChanceToGetBonusMeat > (7 - CharactersData.GetCharacterCookingSkill(Context.User.Id) / 16))
                        { MeatToGive = random.Next(3, 6); }
                        else
                        { MeatToGive = random.Next(2, 4); }
                        TotalMeatToGive += MeatToGive;
                        TotalCarcassesToTook += 1;
                    }
                    CookingEmbed.AddField("<:Meat:607579880569307146>```Success!```", $"```You have received {TotalMeatToGive} units of wolf meat!```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterWolfMeat(Context.User.Id, TotalMeatToGive, 0.3f / CharactersData.GetCharacterCookingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    CookingEmbed.WithColor(Color.Blue);
                    CookingEmbed.AddField($"<:Meat:607579880569307146>```Cooking skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [15]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterCookingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("boar", "Boar"), Summary("Command for collecting a meat from boar")]
            public async Task IncomingPlayerBoarMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterCookingSkill(Context.User.Id) >= 20)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterBoarCarcass(Context.User.Id) < 1)
                    {
                        CookingEmbed.WithColor(Color.Blue);
                        CookingEmbed.AddField("<:Meat:607579880569307146>```You don't have enough boar carcasses to collect meat from them!```", "```At least 1 boar carcass required```");
                        await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    CookingEmbed.WithColor(Color.Blue);
                    int TotalMeatToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusMeat, MeatToGive;
                    for (int i = CharactersData.GetCharacterBoarCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusMeat = random.Next(0, 10);
                        if (ChanceToGetBonusMeat > (7 - CharactersData.GetCharacterCookingSkill(Context.User.Id) / 18))
                        { MeatToGive = random.Next(3, 6); }
                        else
                        { MeatToGive = random.Next(2, 4); }
                        TotalMeatToGive += MeatToGive;
                        TotalCarcassesToTook += 1;
                    }
                    CookingEmbed.AddField("<:Meat:607579880569307146>```Success!```", $"```You have received {TotalMeatToGive} units of boar meat!```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterBoarMeat(Context.User.Id, TotalMeatToGive, 0.3f / CharactersData.GetCharacterCookingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    CookingEmbed.WithColor(Color.Blue);
                    CookingEmbed.AddField($"<:Meat:607579880569307146>```Hunting skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [20]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterCookingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("deer", "Deer"), Summary("Command for collecting a meat from deer")]
            public async Task IncomingPlayerDeerMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterCookingSkill(Context.User.Id) >= 25)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterDeerCarcass(Context.User.Id) < 1)
                    {
                        CookingEmbed.WithColor(Color.Blue);
                        CookingEmbed.AddField("<:Meat:607579880569307146>```You don't have enough deer carcasses to collect meat from them!```", "```At least 1 deer carcass required```");
                        await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    CookingEmbed.WithColor(Color.Blue);
                    int TotalMeatToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusMeat, MeatToGive;
                    for (int i = CharactersData.GetCharacterDeerCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusMeat = random.Next(0, 10);
                        if (ChanceToGetBonusMeat > (7 - CharactersData.GetCharacterCookingSkill(Context.User.Id) / 20))
                        { MeatToGive = random.Next(3, 6); }
                        else
                        { MeatToGive = random.Next(2, 4); }
                        TotalMeatToGive += MeatToGive;
                        TotalCarcassesToTook += 1;
                    }
                    CookingEmbed.AddField("<:Meat:607579880569307146>```Success!```", $"```You have received {TotalMeatToGive} units of deer leather!```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterDeerMeat(Context.User.Id, TotalMeatToGive, 0.3f / CharactersData.GetCharacterCookingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    CookingEmbed.WithColor(Color.Blue);
                    CookingEmbed.AddField($"<:Meat:607579880569307146>```Cooking skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [25]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterCookingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("eagle", "Eagle"), Summary("Command for collecting a meat from eagle")]
            public async Task IncomingPlayerEagleMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterCookingSkill(Context.User.Id) >= 30)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterEagleCarcass(Context.User.Id) < 1)
                    {
                        CookingEmbed.WithColor(Color.Blue);
                        CookingEmbed.AddField("<:Meat:607579880569307146>```You don't have enough eagle carcasses to collect meat from them!```", "```At least 1 eagle carcass required```");
                        await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    CookingEmbed.WithColor(Color.Blue);
                    int TotalMeatToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusMeat, MeatToGive;
                    for (int i = CharactersData.GetCharacterEagleCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusMeat = random.Next(0, 10);
                        if (ChanceToGetBonusMeat > (7 - CharactersData.GetCharacterCookingSkill(Context.User.Id) / 22))
                        { MeatToGive = random.Next(3, 6); }
                        else
                        { MeatToGive = random.Next(2, 4); }
                        TotalMeatToGive += MeatToGive;
                        TotalCarcassesToTook += 1;
                    }
                    CookingEmbed.AddField("<:Meat:607579880569307146>```Success!```", $"```You have received {TotalMeatToGive} eagle meat!```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterEagleMeat(Context.User.Id, TotalMeatToGive, 0.3f / CharactersData.GetCharacterCookingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    CookingEmbed.WithColor(Color.Blue);
                    CookingEmbed.AddField($"<:Meat:607579880569307146>```Cooking skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [30]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterCookingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                    return;
                }
            }

            [Command(""), Alias("buffalo", "Buffalo"), Summary("Command for collecting a meat from buffalo")]
            public async Task IncomingPlayerBuffaloMeatCollectingRequest()
            {
                if (CharactersData.GetCharacterCookingSkill(Context.User.Id) >= 35)
                {
                    //Checking commands
                    if (CharactersData.GetCharacterBuffaloCarcass(Context.User.Id) < 1)
                    {
                        CookingEmbed.WithColor(Color.Blue);
                        CookingEmbed.AddField("<:Meat:607579880569307146>```You don't have enough buffalo carcasses to collect meat from them!```", "```At least 1 buffalo carcass required```");
                        await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                        return;
                    }
                    //Execution of command
                    CookingEmbed.WithColor(Color.Blue);
                    int TotalMeatToGive = 0, TotalCarcassesToTook = 0, ChanceToGetBonusMeat, MeatToGive;
                    for (int i = CharactersData.GetCharacterBuffaloCarcass(Context.User.Id); i >= 1; i -= 1)
                    {
                        ChanceToGetBonusMeat = random.Next(0, 10);
                        if (ChanceToGetBonusMeat > (7 - CharactersData.GetCharacterCookingSkill(Context.User.Id) / 24))
                        { MeatToGive = random.Next(3, 6); }
                        else
                        { MeatToGive = random.Next(2, 4); }
                        TotalMeatToGive += MeatToGive;
                        TotalCarcassesToTook += 1;
                    }
                    CookingEmbed.AddField("<:Meat:607579880569307146>```Success!```", $"```You have received {TotalMeatToGive} units of buffalo meat!```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());

                    //Save data
                    await CharactersData.SaveCharacterBuffaloMeat(Context.User.Id, TotalMeatToGive, 0.3f / CharactersData.GetCharacterCookingSkill(Context.User.Id), TotalCarcassesToTook); ;
                    return;
                }
                else
                {
                    CookingEmbed.WithColor(Color.Blue);
                    CookingEmbed.AddField($"<:Meat:607579880569307146>```Cooking skill comes with time, {CharactersData.GetCharacterName(Context.User.Id)}```",
                    "```Required level of skill is: [35]\n" +
                    $"Your current skill level is: [{CharactersData.GetCharacterCookingSkill(Context.User.Id)}]```");
                    await Context.Channel.SendMessageAsync("", false, CookingEmbed.Build());
                    return;
                }
            }
        }
    }
}
