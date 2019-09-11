using System;
using System.ComponentModel.DataAnnotations;

namespace EnigmaBot.Recourses.Database
{
    public class PlayersCraftedItems
    {
        [Key]
        public ulong PlayerId { get; set; }

        /*Instruments
        Pickaxes*/
        public int CopperPickaxe { get; set; }
        public int IronPickaxe { get; set; }
        public int LeadPickaxe { get; set; }
        public int SilverPickaxe { get; set; }
        public int GoldenPickaxe { get; set; }
        public int GlowingPickaxe { get; set; }
        public int MeteoritePickaxe { get; set; }
        public int AdamantitePickaxe { get; set; }

        //Axes
        public int CopperAxe { get; set; }
        public int IronAxe { get; set; }
        public int LeadAxe { get; set; }
        public int SilverAxe { get; set; }
        public int GoldenAxe { get; set; }
        public int GlowingAxe { get; set; }
        public int MeteoriteAxe { get; set; }
        public int AdamantiteAxe { get; set; }

        //Bows
        public int AshWoodBow { get; set; }
        public int BirchWoodBow { get; set; }
        public int MapleWoodBow { get; set; }
        public int SpruceWoodBow { get; set; }
        public int PineWoodBow { get; set; }
        public int OakWoodBow { get; set; }
        public int WalnutWoodBow { get; set; }
        public int ElvenWoodBow { get; set; }

        //Fishing rods
        public int AshWoodFishingRod { get; set; }
        public int BirchWoodFishingRod { get; set; }
        public int MapleWoodFishingRod { get; set; }
        public int SpruceWoodFishingRod { get; set; }
        public int PineWoodFishingRod { get; set; }
        public int OakWoodFishingRod { get; set; }
        public int WalnutWoodFishingRod { get; set; }
        public int ElvenWoodFishingRod { get; set; }

        //Farming Instruments
        public int CopperFarmingInstruments { get; set; }
        public int IronFarmingInstruments { get; set; }
        public int LeadFarmingInstruments { get; set; }
        public int SilverFarmingInstruments { get; set; }
        public int GoldenFarmingInstruments { get; set; }
        public int GlowingFarmingInstruments { get; set; }
        public int MeteoriteFarmingInstruments { get; set; }
        public int AdamantiteFarmingInstruments { get; set; }

        /*Weapons
        Swords*/
        public int CopperSword { get; set; }
        public int IronSword { get; set; }
        public int LeadSword { get; set; }
        public int SilverSword { get; set; }
        public int GoldenSword { get; set; }
        public int GlowingSword { get; set; }
        public int MeteoriteSword { get; set; }
        public int AdamantiteSword { get; set; }

        //Staffs
        public int AshWoodStaff { get; set; }
        public int BirchWoodStaff { get; set; }
        public int MapleWoodStaff { get; set; }
        public int SpruceWoodStaff { get; set; }
        public int PineWoodStaff { get; set; }
        public int OakWoodStaff { get; set; }
        public int WalnutWoodStaff { get; set; }
        public int ElvenWoodStaff { get; set; }

        /*Armor Blacksmith
         Shields*/
        public int CopperShield { get; set; }
        public int IronShield { get; set; }
        public int LeadShield { get; set; }
        public int SilverShield { get; set; }
        public int GoldenShield { get; set; }
        public int GlowingShield { get; set; }
        public int MeteoriteShield { get; set; }
        public int AdamantiteShield { get; set; }

        //Helmets
        public int CopperHelmet { get; set; }
        public int IronHelmet { get; set; }
        public int LeadHelmet { get; set; }
        public int SilverHelmet { get; set; }
        public int GoldenHelmet { get; set; }
        public int GlowingHelmet { get; set; }
        public int MeteoriteHelmet { get; set; }
        public int AdamantiteHelmet { get; set; }

        //Armor
        public int CopperArmor { get; set; }
        public int IronArmor { get; set; }
        public int LeadArmor { get; set; }
        public int SilverArmor { get; set; }
        public int GoldenArmor { get; set; }
        public int GlowingArmor { get; set; }
        public int MeteoriteArmor { get; set; }
        public int AdamantiteArmor { get; set; }

        //Gloves
        public int CopperGloves { get; set; }
        public int IronGloves { get; set; }
        public int LeadGloves { get; set; }
        public int SilverGloves { get; set; }
        public int GoldenGloves { get; set; }
        public int GlowingGloves { get; set; }
        public int MeteoriteGloves { get; set; }
        public int AdamantiteGloves { get; set; }

        //Boots
        public int CopperBoots { get; set; }
        public int IronBoots { get; set; }
        public int LeadBoots { get; set; }
        public int SilverBoots { get; set; }
        public int GoldenBoots { get; set; }
        public int GlowingBoots { get; set; }
        public int MeteoriteBoots { get; set; }
        public int AdamantiteBoots { get; set; }

        /*Leather Armor
        Helmets*/
        public int BunnyLeatherHelmet { get; set; }
        public int FoxLeatherHelmet { get; set; }
        public int WolfLeatherHelmet { get; set; }
        public int BoarLeatherHelmet { get; set; }
        public int DeerLeatherHelmet { get; set; }
        public int BuffaloLeatherHelmet { get; set; }

        //Armor
        public int BunnyLeatherArmor { get; set; }
        public int FoxLeatherArmor { get; set; }
        public int WolfLeatherArmor { get; set; }
        public int BoarLeatherArmor { get; set; }
        public int DeerLeatherArmor { get; set; }
        public int BuffaloLeatherArmor { get; set; }

        //Gloves
        public int BunnyLeatherGloves { get; set; }
        public int FoxLeatherGloves { get; set; }
        public int WolfLeatherGloves { get; set; }
        public int BoarLeatherGloves { get; set; }
        public int DeerLeatherGloves { get; set; }
        public int BuffaloLeatherGloves { get; set; }

        //Boots
        public int BunnyLeatherBoots { get; set; }
        public int FoxLeatherBoots { get; set; }
        public int WolfLeatherBoots { get; set; }
        public int BoarLeatherBoots { get; set; }
        public int DeerLeatherBoots { get; set; }
        public int BuffaloLeatherBoots { get; set; }

        /*Magician's clothes
         Mantle*/
        public int CopperClothMantle { get; set; }
        public int IronClothMantle { get; set; }
        public int LeadClothMantle { get; set; }
        public int SilverClothMantle { get; set; }
        public int GoldenClothMantle { get; set; }
        public int GlowingClothMantle { get; set; }
        public int MeteoriteClothMantle { get; set; }
        public int AdamantiteClothMantle { get; set; }

        //Hat
        public int CopperClothHat { get; set; }
        public int IronClothHat { get; set; }
        public int LeadClothHat { get; set; }
        public int SilverClothHat { get; set; }
        public int GoldenClothHat { get; set; }
        public int GlowingClothHat { get; set; }
        public int MeteoriteClothHat { get; set; }
        public int AdamantiteClothHat { get; set; }

        //Gloves
        public int CopperClothGloves { get; set; }
        public int IronClothGloves { get; set; }
        public int LeadClothGloves { get; set; }
        public int SilverClothGloves { get; set; }
        public int GoldenClothGloves { get; set; }
        public int GlowingClothGloves { get; set; }
        public int MeteoriteClothGloves { get; set; }
        public int AdamantiteClothGloves { get; set; }

        //Boots
        public int CopperClothBoots { get; set; }
        public int IronClothBoots { get; set; }
        public int LeadClothBoots { get; set; }
        public int SilverClothBoots { get; set; }
        public int GoldenClothBoots { get; set; }
        public int GlowingClothBoots { get; set; }
        public int MeteoriteClothBoots { get; set; }
        public int AdamantiteClothBoots { get; set; }
    }
}
