using System;
using System.Linq;
using System.Threading.Tasks;
using EnigmaBot.Recourses.Database;

namespace EnigmaBot.Core.Data
{
    public static class CharactersData
    {
        //Key value
        public static string GetCharacterName(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if(PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1){return null;}
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.CharacterName).FirstOrDefault();
            }
        }

        //Money
        public static double GetCharacterMoney(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.Money).FirstOrDefault();
            }
        }

        //Skills
        public static float GetCharacterMiningSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.MiningSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterOreMeltingSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.OreMeltingSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterWoodChoppingSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.WoodChoppingSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterWoodworkingSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.WoodworkingSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterBlacksmithSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.BlacksmithSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterFurnitureMakerSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.FurnitureMakerSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterHuntingSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.HuntingSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterFishingSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.FishingSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterFarmingSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.FarmingSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterCookingSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.CookingSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterSnipperSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.SnipperSkill).FirstOrDefault();
            }
        }

        public static float GetCharacterTradeSkill(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Select(x => x.TradeSkill).FirstOrDefault();
            }
        }

        //Material's Inventory
        //Ore's
        public static int GetCharacterCopperOre(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.CopperOre).FirstOrDefault();
            }
        }

        public static int GetCharacterIronOre(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.IronOre).FirstOrDefault();
            }
        }

        public static int GetCharacterLeadOre(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.LeadOre).FirstOrDefault();
            }
        }

        public static int GetCharacterSilverOre(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.SilverOre).FirstOrDefault();
            }
        }

        public static int GetCharacterGoldenOre(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.GoldenOre).FirstOrDefault();
            }
        }

        public static int GetCharacterGlowingOre(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.GlowingOre).FirstOrDefault();
            }
        }

        public static int GetCharacterMeteoriteOre(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.MeteoriteOre).FirstOrDefault();
            }
        }

        public static int GetCharacterAdamantiteOre(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.AdamantiteOre).FirstOrDefault();
            }
        }

        //Bar's
        public static int GetCharacterCopperBar(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.CopperBar).FirstOrDefault();
            }
        }

        public static int GetCharacterIronBar(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.IronBar).FirstOrDefault();
            }
        }

        public static int GetCharacterLeadBar(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.LeadBar).FirstOrDefault();
            }
        }

        public static int GetCharacterSilverBar(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.SilverBar).FirstOrDefault();
            }
        }

        public static int GetCharacterGoldenBar(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.GoldenBar).FirstOrDefault();
            }
        }

        public static int GetCharacterGlowingBar(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.GlowingBar).FirstOrDefault();
            }
        }

        public static int GetCharacterMeteoriteBar(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.MeteoriteBar).FirstOrDefault();
            }
        }

        public static int GetCharacterAdamantiteBar(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.AdamantiteBar).FirstOrDefault();
            }
        }

        //Wood
        public static int GetCharacterAshWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.AshWood).FirstOrDefault();
            }
        }

        public static int GetCharacterBirchWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BirchWood).FirstOrDefault();
            }
        }

        public static int GetCharacterMapleWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.MapleWood).FirstOrDefault();
            }
        }

        public static int GetCharacterSpruceWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.SpruceWood).FirstOrDefault();
            }
        }

        public static int GetCharacterPineWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.PineWood).FirstOrDefault();
            }
        }

        public static int GetCharacterOakWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.OakWood).FirstOrDefault();
            }
        }

        public static int GetCharacterWalnutWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.WalnutWood).FirstOrDefault();
            }
        }

        public static int GetCharacterElvenWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ElvenWood).FirstOrDefault();
            }
        }

        //Threated Wood
        public static int GetCharacterTheratedAshWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.TheratedAshWood).FirstOrDefault();
            }
        }

        public static int GetCharacterThreatedBirchWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ThreatedBirchWood).FirstOrDefault();
            }
        }

        public static int GetCharacterThreatedMapleWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ThreatedMapleWood).FirstOrDefault();
            }
        }

        public static int GetCharacterThreatedSpruceWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ThreatedSpruceWood).FirstOrDefault();
            }
        }

        public static int GetCharacterThreatedPineWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ThreatedPineWood).FirstOrDefault();
            }
        }

        public static int GetCharacterThreatedOakWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ThreatedOakWood).FirstOrDefault();
            }
        }

        public static int GetCharacterThreatedWalnutWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ThreatedWalnutWood).FirstOrDefault();
            }
        }

        public static int GetCharacterThreatedElvenWood(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ThreatedElvenWood).FirstOrDefault();
            }
        }

        //Hunting loot
        public static int GetCharacterDuckCarcass(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.DuckCarcass).FirstOrDefault();
            }
        }

        public static int GetCharacterDuckFeathers(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.DuckFeathers).FirstOrDefault();
            }
        }

        public static int GetCharacterDuckMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.DuckMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterBunnyCarcass(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BunnyCarcass).FirstOrDefault();
            }
        }

        public static int GetCharacterBunnyLeather(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BunnyLeather).FirstOrDefault();
            }
        }

        public static int GetCharacterBunnyMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BunnyMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterFoxCarcass(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.FoxCarcass).FirstOrDefault();
            }
        }

        public static int GetCharacterFoxLeather(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.FoxLeather).FirstOrDefault();
            }
        }

        public static int GetCharacterFoxMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.FoxMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterWolfCarcass(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.WolfCarcass).FirstOrDefault();
            }
        }

        public static int GetCharacterWolfLeather(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.WolfLeather).FirstOrDefault();
            }
        }

        public static int GetCharacterWolfMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.WolfMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterBoarCarcass(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BoarCarcass).FirstOrDefault();
            }
        }

        public static int GetCharacterBoarLeather(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BoarLeather).FirstOrDefault();
            }
        }

        public static int GetCharacterBoarMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BoarMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterDeerCarcass(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.DeerCarcass).FirstOrDefault();
            }
        }

        public static int GetCharacterDeerLeather(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.DeerLeather).FirstOrDefault();
            }
        }

        public static int GetCharacterDeerMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.DeerMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterEagleCarcass(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.EagleCarcass).FirstOrDefault();
            }
        }

        public static int GetCharacterEarleFeathers(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.EagleFeathers).FirstOrDefault();
            }
        }

        public static int GetCharacterEagleMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.EagleMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterBuffaloCarcass(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BuffaloCarcass).FirstOrDefault();
            }
        }

        public static int GetCharacterBuffaloLeather(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BuffaloLeather).FirstOrDefault();
            }
        }

        public static int GetCharacterBuffaloMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.BuffaloMeat).FirstOrDefault();
            }
        }

        //Fish
        public static int GetCharacterCarp(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Carp).FirstOrDefault();
            }
        }

        public static int GetCharacterRuffFish(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.RuffFish).FirstOrDefault();
            }
        }

        public static int GetCharacterRoach(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Roach).FirstOrDefault();
            }
        }

        public static int GetCharacterBream(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Bream).FirstOrDefault();
            }
        }

        public static int GetCharacterRuddFish(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.RuddFish).FirstOrDefault();
            }
        }

        public static int GetCharacterGrayling(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Grayling).FirstOrDefault();
            }
        }

        public static int GetCharacterWelsCatfish(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.WelsCatfish).FirstOrDefault();
            }
        }

        public static int GetCharacterTrout(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Trout).FirstOrDefault();
            }
        }

        public static int GetCharacterSterlet(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Sterlet).FirstOrDefault();
            }
        }

        public static int GetCharacterSalmon(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Salmon).FirstOrDefault();
            }
        }

        //Plants
        public static int GetCharacterWheat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Wheat).FirstOrDefault();
            }
        }

        public static int GetCharacterPotato(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Potato).FirstOrDefault();
            }
        }

        public static int GetCharacterCorn(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Corn).FirstOrDefault();
            }
        }

        public static int GetCharacterTomato(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Tomato).FirstOrDefault();
            }
        }

        public static int GetCharacterCotton(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Cotton).FirstOrDefault();
            }
        }

        public static int GetCharacterStrawberry(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Strawberry).FirstOrDefault();
            }
        }

        public static int GetCharacterGrapes(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Grapes).FirstOrDefault();
            }
        }

        public static int GetCharacterSweetPepper(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.SweetPepper).FirstOrDefault();
            }
        }

        public static int GetCharacterRaspberry(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Raspberry).FirstOrDefault();
            }
        }

        //AnimalFarmLoot
        public static int GetCharacterEggs(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Eggs).FirstOrDefault();
            }
        }

        public static int GetCharacterChickenMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.ChickenMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterWool(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Wool).FirstOrDefault();
            }
        }

        public static int GetCharacterSheepMeat(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.SheepMeat).FirstOrDefault();
            }
        }

        public static int GetCharacterMilk(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Milk).FirstOrDefault();
            }
        }

        public static int GetCharacterBeef(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return 0; }
                return PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Select(x => x.Beef).FirstOrDefault();
            }
        }

        //System info
        public static DateTime GetCharacterMiningCooldown(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return new DateTime(0000,0,0,0,00,00); }
                return PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).Select(x => x.MiningCooldown).FirstOrDefault();
            }
        }

        public static DateTime GetCharacterWoodChoppingCooldown(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return new DateTime(0000, 0, 0, 0, 00, 00); }
                return PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).Select(x => x.WoodChoppingCooldown).FirstOrDefault();
            }
        }

        public static DateTime GetCharacterHuntingCooldown(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return new DateTime(0000, 0, 0, 0, 00, 00); }
                return PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).Select(x => x.HuntingCooldown).FirstOrDefault();
            }
        }

        public static DateTime GetCharacterFishingCooldown(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return new DateTime(0000, 0, 0, 0, 00, 00); }
                return PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).Select(x => x.FishingCooldown).FirstOrDefault();
            }
        }

        public static DateTime GetCharacterFarmingCooldown(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return new DateTime(0000, 0, 0, 0, 00, 00); }
                return PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).Select(x => x.FarmCooldown).FirstOrDefault();
            }
        }

        public static DateTime GetCharacterTravelCooldown(ulong PlayerId)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).Count() < 1) { return new DateTime(0000, 0, 0, 0, 00, 00); }
                return PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).Select(x => x.TravelCooldown).FirstOrDefault();
            }
        }

        //Savings in Data base
        //Ores
        public static async Task SaveCharacterName(ulong PlayerId, string CharacterName)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                if (PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).Count() < 1)
                {
                    //The user dont have a row yet, create one for him
                    PlayersDataDbContext.PlayersParametrs.Add(new PlayersParams
                    {
                        //Key Values
                        PlayerId = PlayerId,
                        CharacterName = CharacterName
                    });
                    //Also create row in inventory
                    PlayersDataDbContext.PlayersInv.Add(new PlayersMaterialsInventory
                    {
                        PlayerId = PlayerId
                    });
                    //Also create a row in Cooldowns table
                    PlayersDataDbContext.PlayersCooldowns.Add(new PlayersActionsCooldown
                    {
                        PlayerId = PlayerId
                    });
                }
                else
                {
                    //If the user already have a row
                    PlayersParams Current = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                    Current.CharacterName = CharacterName;
                    PlayersDataDbContext.PlayersParametrs.Update(Current);
                }
                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterCopperOre(ulong PlayerId, int OreToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.CopperOre += OreToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.MiningSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterIronOre(ulong PlayerId, int OreToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.IronOre += OreToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.MiningSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterLeadOre(ulong PlayerId, int OreToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.LeadOre += OreToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.MiningSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterSilverOre(ulong PlayerId, int OreToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.SilverOre += OreToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.MiningSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterGoldenOre(ulong PlayerId, int OreToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.GoldenOre += OreToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.MiningSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterGlowingOre(ulong PlayerId, int OreToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.GlowingOre += OreToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.MiningSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterMeteoriteOre(ulong PlayerId, int OreToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.MeteoriteOre += OreToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.MiningSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterAdamantiteOre(ulong PlayerId, int OreToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.AdamantiteOre += OreToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.MiningSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Wood
        public static async Task SaveCharacterAshWood(ulong PlayerId, int WoodToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.AshWood += WoodToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodChoppingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBirchWood(ulong PlayerId, int WoodToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BirchWood += WoodToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodChoppingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterMapleWood(ulong PlayerId, int WoodToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.MapleWood += WoodToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodChoppingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterSpruceWood(ulong PlayerId, int WoodToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.SpruceWood += WoodToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodChoppingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterPineWood(ulong PlayerId, int WoodToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.PineWood += WoodToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodChoppingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterOakWood(ulong PlayerId, int WoodToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.OakWood += WoodToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodChoppingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterWalnutWood(ulong PlayerId, int WoodToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.WalnutWood += WoodToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodChoppingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterElvenWood(ulong PlayerId, int WoodToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ElvenWood += WoodToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodChoppingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Hunt Carcasses
        public static async Task SaveCharacterDuckCarcass(ulong PlayerId, int CarcassToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.DuckCarcass += CarcassToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBunnyCarcass(ulong PlayerId, int CarcassToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BunnyCarcass += CarcassToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterFoxCarcass(ulong PlayerId, int CarcassToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.FoxCarcass += CarcassToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterWolfCarcass(ulong PlayerId, int CarcassToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.WolfCarcass += CarcassToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBoarCarcass(ulong PlayerId, int CarcassToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BoarCarcass += CarcassToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterDeerCarcass(ulong PlayerId, int CarcassToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.DeerCarcass += CarcassToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterEagleCarcass(ulong PlayerId, int CarcassToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.EagleCarcass += CarcassToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBuffaloCarcass(ulong PlayerId, int CarcassToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BuffaloCarcass += CarcassToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Fish
        public static async Task SaveCharacterCarp(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Carp += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRuffFish(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.RuffFish += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRoach(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Roach += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBream(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Bream += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRuddFish(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.RuddFish += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterGrayling(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Grayling += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterWelsCatfish(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.WelsCatfish += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterTrout(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Trout += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterSterlet(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Sterlet += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterSalmon(ulong PlayerId, int FishToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Salmon += FishToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FishingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Plants
        public static async Task SaveCharacterWheat(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Wheat += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterPotato(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Potato += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterCorn(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Corn += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterTomato(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Tomato += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterCotton(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Cotton += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterStrawberry(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Strawberry += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterGrapes(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Grapes += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterSweetPepper(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.SweetPepper += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRaspberry(ulong PlayerId, int PlantsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Raspberry += PlantsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Animals
        public static async Task SaveCharacterEggsAmount(ulong PlayerId, int AnimalProductsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Eggs += AnimalProductsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterChickenMeat(ulong PlayerId, int AnimalProductsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ChickenMeat += AnimalProductsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterWoolAmount(ulong PlayerId, int AnimalProductsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Wool += AnimalProductsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterSheepMeat(ulong PlayerId, int AnimalProductsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.SheepMeat += AnimalProductsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterMilkAmount(ulong PlayerId, int AnimalProductsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Milk += AnimalProductsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBeef(ulong PlayerId, int AnimalProductsToGiveAmount, float ExpToGiveAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.Beef += AnimalProductsToGiveAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.FarmingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Remelted Ores
        public static async Task SaveCharacterRemeltedCopper(ulong PlayerId, int RemeltedOresToGiveAmount, float ExpToGiveAmount,int RawOreToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.CopperBar += RemeltedOresToGiveAmount;
                CurrentInv.CopperOre -= RawOreToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.OreMeltingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRemeltedIron(ulong PlayerId, int RemeltedOresToGiveAmount, float ExpToGiveAmount, int RawOreToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.IronBar += RemeltedOresToGiveAmount;
                CurrentInv.IronOre -= RawOreToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.OreMeltingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRemeltedLead(ulong PlayerId, int RemeltedOresToGiveAmount, float ExpToGiveAmount, int RawOreToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.LeadBar += RemeltedOresToGiveAmount;
                CurrentInv.LeadOre -= RawOreToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.OreMeltingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRemeltedSilver(ulong PlayerId, int RemeltedOresToGiveAmount, float ExpToGiveAmount, int RawOreToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.SilverBar += RemeltedOresToGiveAmount;
                CurrentInv.SilverOre -= RawOreToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.OreMeltingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRemeltedGold(ulong PlayerId, int RemeltedOresToGiveAmount, float ExpToGiveAmount, int RawOreToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.GoldenBar += RemeltedOresToGiveAmount;
                CurrentInv.GoldenOre -= RawOreToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.OreMeltingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRemeltedGlowingOre(ulong PlayerId, int RemeltedOresToGiveAmount, float ExpToGiveAmount, int RawOreToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.GlowingBar += RemeltedOresToGiveAmount;
                CurrentInv.GlowingOre -= RawOreToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.OreMeltingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRemeltedMeteoriteOre(ulong PlayerId, int RemeltedOresToGiveAmount, float ExpToGiveAmount, int RawOreToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.MeteoriteBar += RemeltedOresToGiveAmount;
                CurrentInv.MeteoriteOre -= RawOreToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.OreMeltingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterRemeltedAdamantite(ulong PlayerId, int RemeltedOresToGiveAmount, float ExpToGiveAmount, int RawOreToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.AdamantiteBar += RemeltedOresToGiveAmount;
                CurrentInv.AdamantiteOre -= RawOreToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.OreMeltingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Threated Wood
        public static async Task SaveCharacterTheratedAshWood(ulong PlayerId, int TheratedWoodToGiveAmount, float ExpToGiveAmount, int WoodToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.TheratedAshWood += TheratedWoodToGiveAmount;
                CurrentInv.AshWood -= WoodToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodworkingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterThreatedBirchWood(ulong PlayerId, int TheratedWoodToGiveAmount, float ExpToGiveAmount, int WoodToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ThreatedBirchWood += TheratedWoodToGiveAmount;
                CurrentInv.BirchWood -= WoodToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodworkingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterThreatedMapleWood(ulong PlayerId, int TheratedWoodToGiveAmount, float ExpToGiveAmount, int WoodToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ThreatedMapleWood += TheratedWoodToGiveAmount;
                CurrentInv.MapleWood -= WoodToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodworkingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterThreatedSpruceWood(ulong PlayerId, int TheratedWoodToGiveAmount, float ExpToGiveAmount, int WoodToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ThreatedSpruceWood += TheratedWoodToGiveAmount;
                CurrentInv.SpruceWood -= WoodToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodworkingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterThreatedPineWood(ulong PlayerId, int TheratedWoodToGiveAmount, float ExpToGiveAmount, int WoodToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ThreatedPineWood += TheratedWoodToGiveAmount;
                CurrentInv.PineWood -= WoodToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodworkingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterThreatedOakWood(ulong PlayerId, int TheratedWoodToGiveAmount, float ExpToGiveAmount, int WoodToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ThreatedOakWood += TheratedWoodToGiveAmount;
                CurrentInv.OakWood -= WoodToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodworkingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterThreatedWalnutWood(ulong PlayerId, int TheratedWoodToGiveAmount, float ExpToGiveAmount, int WoodToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ThreatedWalnutWood += TheratedWoodToGiveAmount;
                CurrentInv.WalnutWood -= WoodToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodworkingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterThreatedElvenWood(ulong PlayerId, int TheratedWoodToGiveAmount, float ExpToGiveAmount, int WoodToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.ThreatedElvenWood += TheratedWoodToGiveAmount;
                CurrentInv.ElvenWood -= WoodToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.WoodworkingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Animals Leather
        public static async Task SaveCharacterDuckFeathers(ulong PlayerId, int LeatherToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.DuckFeathers += LeatherToGiveAmount;
                CurrentInv.DuckCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBunnyLeather(ulong PlayerId, int LeatherToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BunnyLeather += LeatherToGiveAmount;
                CurrentInv.BunnyCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterFoxLeather(ulong PlayerId, int LeatherToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.FoxLeather += LeatherToGiveAmount;
                CurrentInv.FoxCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterWolfLeather(ulong PlayerId, int LeatherToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.WolfLeather += LeatherToGiveAmount;
                CurrentInv.WolfCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBoarLeather(ulong PlayerId, int LeatherToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BoarLeather += LeatherToGiveAmount;
                CurrentInv.BoarCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterDeerLeather(ulong PlayerId, int LeatherToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.DeerLeather += LeatherToGiveAmount;
                CurrentInv.DeerCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterEagleFeathers(ulong PlayerId, int LeatherToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.EagleFeathers += LeatherToGiveAmount;
                CurrentInv.EagleCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBuffaloLeather(ulong PlayerId, int LeatherToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BuffaloLeather += LeatherToGiveAmount;
                CurrentInv.BuffaloCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        //Animals From Hunt Meat
        public static async Task SaveCharacterDuckMeat(ulong PlayerId, int MeatToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.DuckMeat += MeatToGiveAmount;
                CurrentInv.DuckCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBunnyMeat(ulong PlayerId, int MeatToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BunnyMeat += MeatToGiveAmount;
                CurrentInv.BunnyCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterFoxMeat(ulong PlayerId, int MeatToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.FoxMeat += MeatToGiveAmount;
                CurrentInv.FoxCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterWolfMeat(ulong PlayerId, int MeatToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.WolfMeat += MeatToGiveAmount;
                CurrentInv.WolfCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBoarMeat(ulong PlayerId, int MeatToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BoarMeat += MeatToGiveAmount;
                CurrentInv.BoarCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterDeerMeat(ulong PlayerId, int MeatToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.DeerMeat += MeatToGiveAmount;
                CurrentInv.DeerCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterEagleMeat(ulong PlayerId, int MeatToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.EagleMeat += MeatToGiveAmount;
                CurrentInv.EagleCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SaveCharacterBuffaloMeat(ulong PlayerId, int MeatToGiveAmount, float ExpToGiveAmount, int CarcassesToTookAmount)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersMaterialsInventory CurrentInv = PlayersDataDbContext.PlayersInv.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentInv.BuffaloMeat += MeatToGiveAmount;
                CurrentInv.BuffaloCarcass -= CarcassesToTookAmount;
                PlayersDataDbContext.PlayersInv.Update(CurrentInv);

                PlayersParams CurrentParams = PlayersDataDbContext.PlayersParametrs.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                CurrentParams.HuntingSkill += ExpToGiveAmount;
                PlayersDataDbContext.PlayersParametrs.Update(CurrentParams);

                await PlayersDataDbContext.SaveChangesAsync();
            }
        }
  
        //Cooldowns
        public static async Task SavePlayerMiningCooldown(ulong PlayerId,DateTime CooldownToSave)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersActionsCooldown Current = PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                Current.MiningCooldown = CooldownToSave;
                PlayersDataDbContext.PlayersCooldowns.Update(Current);
                await PlayersDataDbContext.SaveChangesAsync();
            }            
        }

        public static async Task SavePlayerWoodChoppingCooldown(ulong PlayerId, DateTime CooldownToSave)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersActionsCooldown Current = PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                Current.WoodChoppingCooldown = CooldownToSave;
                PlayersDataDbContext.PlayersCooldowns.Update(Current);
                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SavePlayerHuntingCooldown(ulong PlayerId, DateTime CooldownToSave)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersActionsCooldown Current = PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                Current.HuntingCooldown = CooldownToSave;
                PlayersDataDbContext.PlayersCooldowns.Update(Current);
                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SavePlayerFishingCooldown(ulong PlayerId, DateTime CooldownToSave)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersActionsCooldown Current = PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                Current.FishingCooldown = CooldownToSave;
                PlayersDataDbContext.PlayersCooldowns.Update(Current);
                await PlayersDataDbContext.SaveChangesAsync();
            }
        }

        public static async Task SavePlayerFarmCooldown(ulong PlayerId, DateTime CooldownToSave)
        {
            using (var PlayersDataDbContext = new SqLitePlayersData())
            {
                PlayersActionsCooldown Current = PlayersDataDbContext.PlayersCooldowns.Where(x => x.PlayerId == PlayerId).FirstOrDefault();
                Current.FarmCooldown = CooldownToSave;
                PlayersDataDbContext.PlayersCooldowns.Update(Current);
                await PlayersDataDbContext.SaveChangesAsync();
            }
        }
    }
}
