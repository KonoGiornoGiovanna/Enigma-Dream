using System.ComponentModel.DataAnnotations;
using System;

namespace EnigmaBot.Recourses.Database
{
    public class PlayersParams
    {
        [Key]
        public ulong PlayerId { get; set; }
        public string CharacterName { get; set; }

        //Money
        public double Money { get; set; }

        //Skills
        public float MiningSkill { get; set; }
        public float OreMeltingSkill { get; set; }
        public float WoodChoppingSkill { get; set; }
        public float WoodworkingSkill { get; set; }
        public float BlacksmithSkill { get; set; }
        public float FurnitureMakerSkill { get; set; }
        public float HuntingSkill { get; set; }
        public float FishingSkill { get; set; }
        public float FarmingSkill { get; set; }
        public float CookingSkill { get; set; }
        public float SnipperSkill { get; set; }
        public float TradeSkill { get; set; }

        //System
        public int PickaxeDurability { get; set; }
        public int AxeDurability { get; set; }
        public int BowDurability { get; set; }
        public int ArrowsAmount { get; set; }
        public int FishingRodDurability { get; set; }
        public int FarmingInstrumentsDurability { get; set; }
        public int HeroIsHiredIndex { get; set; }
    }
}
