using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Discord;
using Discord.Commands;
using EnigmaBot.Core.Data;

namespace EnigmaBot.Core.Commands.Currency
{
    public class CharacterCreation : ModuleBase<SocketCommandContext>
    {
        [Group("Character"), Alias("character"), Summary("This group should interact with character")]
        public class CharacterCreationGroup : ModuleBase<SocketCommandContext>
        {
            EmbedBuilder CharacterCreationEmbed = new EmbedBuilder();

            [Command(""), Alias("create"), Summary("Command to create a new character")]
            public async Task CreateCharacter(IUser User = null, string CharacterName = null)
            {
                //Check commands for correctness
                if (User.Id != Context.User.Id)
                {
                    CharacterCreationEmbed.WithColor(Color.Blue);
                    CharacterCreationEmbed.AddField(":x:```Eror```", "```You are able to create character only for yourself!```");
                    await Context.Channel.SendMessageAsync("", false, CharacterCreationEmbed.Build());
                    return;
                }
                if (CharacterName == null)
                {
                    CharacterCreationEmbed.WithColor(Color.Blue);
                    CharacterCreationEmbed.AddField(":x:```Eror```", "```You should write character name!```");
                    await Context.Channel.SendMessageAsync("", false, CharacterCreationEmbed.Build());
                    return;
                }

                //Execution of  command              
                CharacterCreationEmbed.WithColor(Color.Blue);
                CharacterCreationEmbed.AddField(":gear:```You have successfully created a character!```", $"```Character name is {CharacterName}```");
                await Context.Channel.SendMessageAsync("", false, CharacterCreationEmbed.Build());

                //Save in data
                await CharactersData.SaveCharacterName(User.Id, CharacterName);
            }

            [Command(""), Alias("info", "Info"), Summary("Command to display info about character")]
            public async Task DisplayCharacterInfo(IUser User = null)
            {
                if (User == null)
                {
                    CharacterCreationEmbed.WithColor(Color.Blue);
                    CharacterCreationEmbed.AddField($"<:InfoBook:603974731535876106>```{Context.User}, your character info:```", $"```Name is: {CharactersData.GetCharacterName(Context.User.Id)}" +
                    $"\nGold: {CharactersData.GetCharacterMoney(Context.User.Id)}\n――――――――――Skills――――――――――\nMining:             |" +
                    $"{Math.Round(Convert.ToDouble(CharactersData.GetCharacterMiningSkill(Context.User.Id)),1)}\nWood chopping:      |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterWoodChoppingSkill(Context.User.Id)),1)}" +
                    $"\nHunting:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterHuntingSkill(Context.User.Id)),1)}\nFishing:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterFishingSkill(Context.User.Id)),1)}" +
                    $"\nFarming:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterFarmingSkill(Context.User.Id)),1)}\nTrade:              |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterTradeSkill(Context.User.Id)),1)}" +
                    $"\n――――――CraftingSkills―――――――\nOre melting:        |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterOreMeltingSkill(Context.User.Id)),1)}\nWoodworking:        |" +
                    $"{Math.Round(Convert.ToDouble(CharactersData.GetCharacterWoodworkingSkill(Context.User.Id)),1)}\nBlacksmith:         |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterBlacksmithSkill(Context.User.Id)),1)}" +
                    $"\nFurniture maker:    |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterFurnitureMakerSkill(Context.User.Id)),1)}\nCooking:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterCookingSkill(Context.User.Id)),1)}" +
                    $"\nSnipper:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterSnipperSkill(Context.User.Id)),1)}```");
                }
                else
                {
                    CharacterCreationEmbed.WithColor(Color.Blue);
                    CharacterCreationEmbed.AddField($"<:InfoBook:603974731535876106>```{User.Username}, your character info:```", $"```Name is: {CharactersData.GetCharacterName(User.Id)}" +
                    $"\nGold: {CharactersData.GetCharacterMoney(User.Id)}\n――――――――――Skills――――――――――\nMining:             |" +
                    $"{Math.Round(Convert.ToDouble(CharactersData.GetCharacterMiningSkill(User.Id)), 1)}\nWood chopping:      |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterWoodChoppingSkill(User.Id)), 1)}" +
                    $"\nHunting:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterHuntingSkill(User.Id)), 1)}\nFishing:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterFishingSkill(User.Id)), 1)}" +
                    $"\nFarming:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterFarmingSkill(User.Id)), 1)}\nTrade:              |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterTradeSkill(User.Id)), 1)}" +
                    $"\n――――――CraftingSkills―――――――\nOre melting:        |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterOreMeltingSkill(User.Id)), 1)}\nWoodworking:        |" +
                    $"{Math.Round(Convert.ToDouble(CharactersData.GetCharacterWoodworkingSkill(User.Id)), 1)}\nBlacksmith:         |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterBlacksmithSkill(User.Id)), 1)}" +
                    $"\nFurniture maker:    |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterFurnitureMakerSkill(User.Id)), 1)}\nCooking:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterCookingSkill(User.Id)), 1)}" +
                    $"\nSnipper:            |{Math.Round(Convert.ToDouble(CharactersData.GetCharacterSnipperSkill(User.Id)), 1)}```");
                }

                await Context.Channel.SendMessageAsync("", false, CharacterCreationEmbed.Build());
            }
        }
    }
}
