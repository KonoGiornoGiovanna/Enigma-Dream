using System;
using System.ComponentModel.DataAnnotations;

namespace EnigmaBot.Recourses.Database
{
    public class PlayersMaterialsInventory
    {
        [Key]
        public ulong PlayerId { get; set; }

        //Materials inventory

        //Ores
        public int CopperOre { get; set; }
        public int IronOre { get; set; }
        public int LeadOre { get; set; }
        public int SilverOre { get; set; }
        public int GoldenOre { get; set; }
        public int GlowingOre { get; set; }
        public int MeteoriteOre { get; set; }
        public int AdamantiteOre { get; set; }

        //Bar's
        public int CopperBar { get; set; }
        public int IronBar { get; set; }
        public int LeadBar { get; set; }
        public int SilverBar { get; set; }
        public int GoldenBar { get; set; }
        public int GlowingBar { get; set; }
        public int MeteoriteBar { get; set; }
        public int AdamantiteBar { get; set; }

        //Wood
        public int AshWood { get; set; }
        public int BirchWood { get; set; }
        public int MapleWood { get; set; }
        public int SpruceWood { get; set; }
        public int PineWood { get; set; }
        public int OakWood { get; set; }
        public int WalnutWood { get; set; }
        public int ElvenWood { get; set; }

        //Threated Wood
        public int TheratedAshWood { get; set; }
        public int ThreatedBirchWood { get; set; }
        public int ThreatedMapleWood { get; set; }
        public int ThreatedSpruceWood { get; set; }
        public int ThreatedPineWood { get; set; }
        public int ThreatedOakWood { get; set; }
        public int ThreatedWalnutWood { get; set; }
        public int ThreatedElvenWood { get; set; }

        //Hunting loot
        public int DuckCarcass { get; set; }
        public int DuckFeathers { get; set; }
        public int DuckMeat { get; set; }
        public int BunnyCarcass { get; set; }
        public int BunnyLeather { get; set; }
        public int BunnyMeat { get; set; }
        public int FoxCarcass { get; set; }
        public int FoxLeather{ get; set; }
        public int FoxMeat { get; set; }
        public int WolfCarcass { get; set; }
        public int WolfLeather { get; set; }
        public int WolfMeat { get; set; }
        public int BoarCarcass { get; set; }
        public int BoarLeather { get; set; }
        public int BoarMeat { get; set; }
        public int DeerCarcass { get; set; }
        public int DeerLeather { get; set; }
        public int DeerMeat { get; set; }
        public int EagleCarcass { get; set; }
        public int EagleFeathers { get; set; }
        public int EagleMeat { get; set; }
        public int BuffaloCarcass { get; set; }
        public int BuffaloLeather { get; set; }
        public int BuffaloMeat { get; set; }

        //Fish
        public int Carp { get; set; }
        public int RuffFish { get; set; }
        public int Roach { get; set; }
        public int Bream { get; set; }
        public int RuddFish { get; set; }
        public int Grayling { get; set; }
        public int WelsCatfish { get; set; }
        public int Trout { get; set; }
        public int Sterlet { get; set; }
        public int Salmon { get; set; }

        //Plants
        public int Wheat { get; set; }
        public int Potato { get; set; }
        public int Corn { get; set; }
        public int Tomato { get; set; }
        public int Cotton { get; set; }
        public int Strawberry { get; set; }
        public int Grapes { get; set; }
        public int SweetPepper { get; set; }
        public int Raspberry { get; set; }

        //AnimalFarmLoot
        public int Eggs { get; set; }
        public int ChickenMeat { get; set; }
        public int Wool { get; set; }
        public int SheepMeat { get; set; }
        public int Milk { get; set; }
        public int Beef { get; set; }

        //Threads
        public int CopperThread { get; set; }
        public int IronThread { get; set; }
        public int LeadThread { get; set; }
        public int SilverThread { get; set; }
        public int GoldenThread { get; set; }
        public int GlowingThread { get; set; }
        public int MeteoriteThread { get; set; }
        public int AdamantiteThread { get; set; }

        //Clothes
        public int CottonCloth { get; set; }
        public int WoolCloth { get; set; }

        public int CopperCloth { get; set; }
        public int IronCloth { get; set; }
        public int LeadCloth { get; set; }
        public int SilverCloth { get; set; }
        public int GoldenCloth { get; set; }
        public int GlowingCloth { get; set; }
        public int MeteoriteCloth { get; set; }
        public int AdamantiteCloth { get; set; }
    }
}
