using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnigmaBot.Migrations
{
    public partial class FarmAndFishingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "PlayersInv",
            columns: table => new
            {
                PlayerId = table.Column<ulong>(nullable: false)
            .Annotation("Sqlite:Autoincrement", true),
                /*Ores*/
                CopperOre = table.Column<int>(nullable: false),
                IronOre = table.Column<int>(nullable: false),
                LeadOre = table.Column<int>(nullable: false),
                SilverOre = table.Column<int>(nullable: false),
                GoldenOre = table.Column<int>(nullable: false),
                GlowingOre = table.Column<int>(nullable: false),
                MeteoriteOre = table.Column<int>(nullable: false),
                AdamantiteOre = table.Column<int>(nullable: false),
                /*Bar's*/
                CopperBar = table.Column<int>(nullable: false),
                IronBar = table.Column<int>(nullable: false),
                LeadBar = table.Column<int>(nullable: false),
                SilverBar = table.Column<int>(nullable: false),
                GoldenBar = table.Column<int>(nullable: false),
                GlowingBar = table.Column<int>(nullable: false),
                MeteoriteBar = table.Column<int>(nullable: false),
                AdamantiteBar = table.Column<int>(nullable: false),
                /*Wood*/
                AshWood = table.Column<int>(nullable: false),
                BirchWood = table.Column<int>(nullable: false),
                MapleWood = table.Column<int>(nullable: false),
                SpruceWood = table.Column<int>(nullable: false),
                PineWood = table.Column<int>(nullable: false),
                OakWood = table.Column<int>(nullable: false),
                WalnutWood = table.Column<int>(nullable: false),
                ElvenWood = table.Column<int>(nullable: false),
                /*Threated Wood*/
                TheratedAshWood = table.Column<int>(nullable: false),
                ThreatedBirchWood = table.Column<int>(nullable: false),
                ThreatedMapleWood = table.Column<int>(nullable: false),
                ThreatedSpruceWood = table.Column<int>(nullable: false),
                ThreatedPineWood = table.Column<int>(nullable: false),
                ThreatedOakWood = table.Column<int>(nullable: false),
                ThreatedWalnutWood = table.Column<int>(nullable: false),
                ThreatedElvenWood = table.Column<int>(nullable: false),
                /*Hunting loot*/
                DuckCarcass = table.Column<int>(nullable: false),
                DuckFeathers = table.Column<int>(nullable: false),
                DuckMeat = table.Column<int>(nullable: false),
                BunnyCarcass = table.Column<int>(nullable: false),
                BunnyLeather = table.Column<int>(nullable: false),
                BunnyMeat = table.Column<int>(nullable: false),
                FoxCarcass = table.Column<int>(nullable: false),
                FoxLeather = table.Column<int>(nullable: false),
                FoxMeat = table.Column<int>(nullable: false),
                WolfCarcass = table.Column<int>(nullable: false),
                WolfLeather = table.Column<int>(nullable: false),
                WolfMeat = table.Column<int>(nullable: false),
                BoarCarcass = table.Column<int>(nullable: false),
                BoarLeather = table.Column<int>(nullable: false),
                BoarMeat = table.Column<int>(nullable: false),
                DeerCarcass = table.Column<int>(nullable: false),
                DeerLeather = table.Column<int>(nullable: false),
                DearMeat = table.Column<int>(nullable: false),
                EagleCarcass = table.Column<int>(nullable: false),
                EarleFeathers = table.Column<int>(nullable: false),
                EagleMeat = table.Column<int>(nullable: false),
                BuffaloCarcass = table.Column<int>(nullable: false),
                BuffaloLeather = table.Column<int>(nullable: false),
                BuffaloMeat = table.Column<int>(nullable: false),
                /*Fish*/
                Carp = table.Column<int>(nullable: false),
                RuffFish = table.Column<int>(nullable: false),
                Roach = table.Column<int>(nullable: false),
                Bream = table.Column<int>(nullable: false),
                RuddFish = table.Column<int>(nullable: false),
                Grayling = table.Column<int>(nullable: false),
                WelsCatfish = table.Column<int>(nullable: false),
                Trout = table.Column<int>(nullable: false),
                Sterlet = table.Column<int>(nullable: false),
                Salmon = table.Column<int>(nullable: false),
                /*Plants*/
                Wheat = table.Column<int>(nullable: false),
                Potato = table.Column<int>(nullable: false),
                Corn = table.Column<int>(nullable: false),
                Tomato = table.Column<int>(nullable: false),
                Cotton = table.Column<int>(nullable: false),
                Strawberry = table.Column<int>(nullable: false),
                Grapes = table.Column<int>(nullable: false),
                SweetPepper = table.Column<int>(nullable: false),
                Raspberry = table.Column<int>(nullable: false),
                /*AnimalFarmLoot*/
                Eggs = table.Column<int>(nullable: false),
                ChickenMeat = table.Column<int>(nullable: false),
                Wool = table.Column<int>(nullable: false),
                SheepMeat = table.Column<int>(nullable: false),
                Milk = table.Column<int>(nullable: false),
                Beef = table.Column<int>(nullable: false)
            },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_PlayersInv", x => x.PlayerId);
                 });
            migrationBuilder.CreateTable(
             name: "PlayersParametrs",
             columns: table => new
             {
                 /*Key values*/
                 PlayerId = table.Column<ulong>(nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                 CharacterName = table.Column<string>(nullable: false),
                 Money = table.Column<int>(nullable: false),
                 /*Skills*/
                 MiningSkill = table.Column<float>(nullable: false),
                 OreMeltingSkill = table.Column<float>(nullable: false),
                 WoodChoppingSkill = table.Column<float>(nullable: false),
                 WoodworkingSkill = table.Column<float>(nullable: false),
                 BlacksmithSkill = table.Column<float>(nullable: false),
                 FurnitureMakerSkill = table.Column<float>(nullable: false),
                 HuntingSkill = table.Column<float>(nullable: false),
                 FishingSkill = table.Column<float>(nullable: false),
                 FarmingSkill = table.Column<float>(nullable: false),
                 CookingSkill = table.Column<float>(nullable: false),
                 SnipperSkill = table.Column<float>(nullable: false),
                 TradeSkill = table.Column<float>(nullable: false),
                 CurrentSity = table.Column<byte>(nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_PlayersParametrs", x => x.PlayerId);
             });
            migrationBuilder.CreateTable(
                name: "PlayersCooldowns",
                columns: table => new
                {
                    PlayerId = table.Column<ulong>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MiningCooldown = table.Column<DateTime>(nullable: false),
                    WoodChoppingCooldown = table.Column<DateTime>(nullable: false),
                    HuntingCooldown = table.Column<DateTime>(nullable: false),
                    FishingCooldown = table.Column<DateTime>(nullable: false),
                    TravelCooldown = table.Column<DateTime>(nullable: false),
                    FarmCooldown = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersCooldowns", x => x.PlayerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "PlayersInv");
            migrationBuilder.DropTable(name: "PlayersParametrs");
            migrationBuilder.DropTable(name: "PlayersCooldowns");
        }
    }
}
