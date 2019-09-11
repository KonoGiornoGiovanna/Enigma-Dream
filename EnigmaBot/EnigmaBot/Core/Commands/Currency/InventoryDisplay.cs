using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.Currency
{
    public class InventoryDisplay : ModuleBase<SocketCommandContext>
    {
        [Group("Inventory"), Alias("inv", "Inv", "inventory", "Backpack", "backpack", "i", "I"), Summary("Command to display character inventory")]
        public class CharacterInventoryDisplay : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder CharacterinventoryEmbed = new EmbedBuilder();

            [Command(""), Alias("Ore","ore","Mineral","mineral"), Summary("Command to display minerals/ores")]
            public async Task DisplayCharacterInventoryOres(IUser User = null)
            {
                if (User == null || User.Id == Context.User.Id)
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField($"<:crystal:605685921056292874>```{Context.User}, amount of your ores and ingots:```", $"```\n―――――――――――――Ores―――――――――――――――――\nCopper ore:          |" +
                    $"{Data.CharactersData.GetCharacterCopperOre(Context.User.Id)}\nIron ore:            |{Data.CharactersData.GetCharacterIronOre(Context.User.Id)}" +
                    $"\nLead ore:            |{Data.CharactersData.GetCharacterLeadOre(Context.User.Id)}\nSilver ore:          |" +
                    $"{Data.CharactersData.GetCharacterSilverOre(Context.User.Id)}\nGolden ore:          |{Data.CharactersData.GetCharacterGoldenOre(Context.User.Id)}" +
                    $"\nGlowing ore:         |{Data.CharactersData.GetCharacterGlowingOre(Context.User.Id)}\nMeteorite ore:       |" +
                    $"{Data.CharactersData.GetCharacterMeteoriteOre(Context.User.Id)}\nAdamantite ore:      |{Data.CharactersData.GetCharacterAdamantiteOre(Context.User.Id)}" +
                    $"\n―――――――――――――Ingots―――――――――――――――\nCopper ingot:        |{Data.CharactersData.GetCharacterCopperBar(Context.User.Id)}" +
                    $"\nIron ingot:          |{Data.CharactersData.GetCharacterIronBar(Context.User.Id)}\nLead ingot:          |" +
                    $"{Data.CharactersData.GetCharacterLeadBar(Context.User.Id)}\nSilver ingot:        |{Data.CharactersData.GetCharacterSilverBar(Context.User.Id)}" +
                    $"\nGolden ingot:        |{Data.CharactersData.GetCharacterGoldenBar(Context.User.Id)}\nGlowing ingot:       |" +
                    $"{Data.CharactersData.GetCharacterGlowingBar(Context.User.Id)}\nMeteorite ingot:     |{Data.CharactersData.GetCharacterMeteoriteBar(Context.User.Id)}" +
                    $"\nAdamantite ingot:    |{Data.CharactersData.GetCharacterAdamantiteBar(Context.User.Id)}```");
                }
                else
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField(":x:```Eror```", "```You can not watch the contents of other character's bags!```");
                    await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
                    return;
                }
                await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
            }

            [Command(""), Alias("wood", "Wood"), Summary("Command to display wood")]
            public async Task DisplayCharacterInventoryWood(IUser User = null)
            {
                if (User == null || User.Id == Context.User.Id)
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField($"<:Wood:603982836919435316>```{Context.User}, amount of your wood and treated wood:```", $"```\n―――――――――――――Wood――――――――――――――――――――――\nAsh wood:                 |" +
                    $"{Data.CharactersData.GetCharacterAshWood(Context.User.Id)}\nBirch wood:               |{Data.CharactersData.GetCharacterBirchWood(Context.User.Id)}" +
                    $"\nMaple wood:               |{Data.CharactersData.GetCharacterMapleWood(Context.User.Id)}\nSpruce wood:              |" +
                    $"{Data.CharactersData.GetCharacterSpruceWood(Context.User.Id)}\nPine wood:                |{Data.CharactersData.GetCharacterPineWood(Context.User.Id)}" +
                    $"\nOak wood:                 |{Data.CharactersData.GetCharacterOakWood(Context.User.Id)}\nWalnut wood:              |" +
                    $"{Data.CharactersData.GetCharacterWalnutWood(Context.User.Id)}\nElven wood:               |{Data.CharactersData.GetCharacterElvenWood(Context.User.Id)}" +
                    $"\n―――――――――――――ThreatedWood――――――――――――――\nTherated Ash wood:        |{Data.CharactersData.GetCharacterTheratedAshWood(Context.User.Id)}" +
                    $"\nTherated Birch wood:      |{Data.CharactersData.GetCharacterThreatedBirchWood(Context.User.Id)}\nTherated Maple wood:      |" +
                    $"{Data.CharactersData.GetCharacterThreatedMapleWood(Context.User.Id)}\nTherated Spruce wood:     |{Data.CharactersData.GetCharacterThreatedSpruceWood(Context.User.Id)}" +
                    $"\nTherated Pine wood:       |{Data.CharactersData.GetCharacterThreatedPineWood(Context.User.Id)}\nTherated Oak wood:        |" +
                    $"{Data.CharactersData.GetCharacterThreatedOakWood(Context.User.Id)}\nTherated Walnut wood:     |{Data.CharactersData.GetCharacterThreatedWalnutWood(Context.User.Id)}" +
                    $"\nTherated Elven wood:      |{Data.CharactersData.GetCharacterThreatedElvenWood(Context.User.Id)}```");
                }
                else
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField(":x:```Eror```", "```You can not watch the contents of other character's bags!```");
                    await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
                    return;
                }
                await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
            }

            [Command(""), Alias("hunt", "Hunt","Hunting","hunting"), Summary("Command to display hunting loot")]
            public async Task DisplayCharacterInventoryHunt(IUser User = null)
            {
                if (User == null || User.Id == Context.User.Id)
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField($"<:Bow2:603986219218632794>```{Context.User}, amount of your hunting loot:```", $"```\n――――――――――――Carcasses――――――――――――\nDuck carcass:    |" +
                    $"{Data.CharactersData.GetCharacterDuckCarcass(Context.User.Id)}\nBunny carcass:   |{Data.CharactersData.GetCharacterBunnyCarcass(Context.User.Id)}" +
                    $"\nFox carcass:     |{Data.CharactersData.GetCharacterFoxCarcass(Context.User.Id)}\nWolf carcass:    |" +
                    $"{Data.CharactersData.GetCharacterWolfCarcass(Context.User.Id)}\nBoar carcass:    |{Data.CharactersData.GetCharacterBoarCarcass(Context.User.Id)}" +
                    $"\nDeer carcass:    |{Data.CharactersData.GetCharacterDeerCarcass(Context.User.Id)}\nEagle carcass:   |" +
                    $"{Data.CharactersData.GetCharacterEagleCarcass(Context.User.Id)}\nBuffalo carcass: |{Data.CharactersData.GetCharacterBuffaloCarcass(Context.User.Id)}" +
                    $"\n――――――――――――Meat―――――――――――――――――\nDuck meat:       |{Data.CharactersData.GetCharacterDuckMeat(Context.User.Id)}" +
                    $"\nBunny meat:      |{Data.CharactersData.GetCharacterBunnyMeat(Context.User.Id)}\nFox meat:        |" +
                    $"{Data.CharactersData.GetCharacterFoxMeat(Context.User.Id)}\nWolf meat:       |{Data.CharactersData.GetCharacterWolfMeat(Context.User.Id)}" +
                    $"\nBoar meat:       |{Data.CharactersData.GetCharacterBoarMeat(Context.User.Id)}\nDeer meat:       |" +
                    $"{Data.CharactersData.GetCharacterDeerMeat(Context.User.Id)}\nEagle meat:      |{Data.CharactersData.GetCharacterEagleMeat(Context.User.Id)}" +
                    $"\nBuffalo meat:    |{Data.CharactersData.GetCharacterBuffaloMeat(Context.User.Id)}\n――――――――――――Feathers―――――――――――――\n" +
                    $"Duck feathers:   |{Data.CharactersData.GetCharacterDuckFeathers(Context.User.Id)}\nEagle feathers:  |{Data.CharactersData.GetCharacterEarleFeathers(Context.User.Id)}" +
                    $"\n――――――――――――Leather――――――――――――――\nBunny leather:   |{Data.CharactersData.GetCharacterBunnyLeather(Context.User.Id)}\n" +
                    $"Fox leather:     |{Data.CharactersData.GetCharacterFoxLeather(Context.User.Id)}\nWolf leather:    |{Data.CharactersData.GetCharacterWolfLeather(Context.User.Id)}" +
                    $"\nBoar leather:    |{Data.CharactersData.GetCharacterBoarLeather(Context.User.Id)}\nDeer leather:    |{Data.CharactersData.GetCharacterDeerLeather(Context.User.Id)}" +
                    $"\nBuffalo leather: |{Data.CharactersData.GetCharacterBuffaloLeather(Context.User.Id)}```");
                }
                else
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField(":x:```Eror```", "```You can not watch the contents of other character's bags!```");
                    await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
                    return;
                }
                await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
            }

            [Command(""), Alias("fish", "Fish","Fishing","fishing"), Summary("Command to display fish")]
            public async Task DisplayCharacterInventoryFish(IUser User = null)
            {
                if (User == null || User.Id == Context.User.Id)
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField($"<:Fish:603973371348123649>```{Context.User}, amount of your fish:```", $"```\n――――――――――――Fish――――――――――\nCarp:           |" +
                    $"{Data.CharactersData.GetCharacterCarp(Context.User.Id)}\nRuffFish:       |{Data.CharactersData.GetCharacterRuffFish(Context.User.Id)}" +
                    $"\nRoach:          |{Data.CharactersData.GetCharacterRoach(Context.User.Id)}\nBream:          |" +
                    $"{Data.CharactersData.GetCharacterBream(Context.User.Id)}\nRudd fish:      |{Data.CharactersData.GetCharacterRuddFish(Context.User.Id)}" +
                    $"\nGrayling:       |{Data.CharactersData.GetCharacterGrayling(Context.User.Id)}\nWels Catfish:   |" +
                    $"{Data.CharactersData.GetCharacterWelsCatfish(Context.User.Id)}\nTrout:          |{Data.CharactersData.GetCharacterTrout(Context.User.Id)}" +
                    $"\nSterlet:        |{Data.CharactersData.GetCharacterSterlet(Context.User.Id)}" +
                    $"\nSalmon:         |{Data.CharactersData.GetCharacterSalmon(Context.User.Id)}```");
                }
                else
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField(":x:```Eror```", "```You can not watch the contents of other character's bags!```");
                    await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
                    return;
                }
                await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
            }

            [Command(""), Alias("farm", "Farm"), Summary("Command to display fish")]
            public async Task DisplayCharacterInventoryFarm(IUser User = null)
            {
                if (User == null || User.Id == Context.User.Id)
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField($"<:pepers:603642034351243274>```{Context.User}, amount of your farm loot:```", $"```\n――――――――――――Plants――――――――――\nWheat:            |" +
                    $"{Data.CharactersData.GetCharacterWheat(Context.User.Id)}\nPotato:           |{Data.CharactersData.GetCharacterPotato(Context.User.Id)}" +
                    $"\nCorn:             |{Data.CharactersData.GetCharacterCorn(Context.User.Id)}\nTomato:           |" +
                    $"{Data.CharactersData.GetCharacterTomato(Context.User.Id)}\nCotton:           |{Data.CharactersData.GetCharacterCotton(Context.User.Id)}" +
                    $"\nStrawberry:       |{Data.CharactersData.GetCharacterStrawberry(Context.User.Id)}\nGrapes:           |" +
                    $"{Data.CharactersData.GetCharacterGrapes(Context.User.Id)}\nSweet pepper:     |{Data.CharactersData.GetCharacterSweetPepper(Context.User.Id)}" +
                    $"\nRaspberry:        |{Data.CharactersData.GetCharacterRaspberry(Context.User.Id)}\n――――――――――――Animals――――――――――\n" +
                    $"Eggs:             |{Data.CharactersData.GetCharacterEggs(Context.User.Id)}\nChicken meat:     |{Data.CharactersData.GetCharacterChickenMeat(Context.User.Id)}\n" +
                    $"Wool:             |{Data.CharactersData.GetCharacterWool(Context.User.Id)}\nSheep meat:       |{Data.CharactersData.GetCharacterSheepMeat(Context.User.Id)}\n" +
                    $"Milk:             |{Data.CharactersData.GetCharacterMilk(Context.User.Id)}\nBeef:             |{Data.CharactersData.GetCharacterBeef(Context.User.Id)}```");
                }
                else
                {
                    CharacterinventoryEmbed.WithColor(Color.Blue);
                    CharacterinventoryEmbed.AddField(":x:```Eror```", "```You can not watch the contents of other character's bags!```");
                    await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
                    return;
                }
                await Context.Channel.SendMessageAsync("", false, CharacterinventoryEmbed.Build());
            }
        }
    }
}
