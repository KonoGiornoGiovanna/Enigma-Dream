using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EnigmaBot.Recourses.Database
{
    public class SqLitePlayersData : DbContext
    {
        public DbSet<PlayersParams> PlayersParametrs { get; set; }
        public DbSet<PlayersMaterialsInventory> PlayersInv { get; set; }
        public DbSet<PlayersActionsCooldown> PlayersCooldowns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Options)
        {
            string DbLocation = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.1", @"Data\");
            Options.UseSqlite($"Data Source={DbLocation}Database.sqlite");
        }
        //Here i can add another tables in the same file
    }

}
