using System;
using System.ComponentModel.DataAnnotations;

namespace EnigmaBot.Recourses.Database
{
    public class PlayersActionsCooldown
    {
        [Key]
        public ulong PlayerId { get; set; }

        //Cooldowns
        public DateTime MiningCooldown { get; set; }
        public DateTime WoodChoppingCooldown { get; set; }
        public DateTime HuntingCooldown { get; set; }
        public DateTime FishingCooldown { get; set; }
        public DateTime FarmCooldown { get; set; }
        public DateTime TravelCooldown { get; set; }
    }
}
