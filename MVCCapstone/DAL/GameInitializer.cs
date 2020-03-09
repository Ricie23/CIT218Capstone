using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCapstone.Models;

namespace MVCCapstone.DAL
{
    public class GameInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            var games = new List<MyGames>
            {
                new MyGames { Name="Red Dead Redemption 2", Genre="Action/Adventure", Price=59.99},
                new MyGames { Name="Far Cry 5", Genre="Action/Adventure", Price=39.99},
                new MyGames { Name="Rocket League", Genre="Sports", Price=20.00},
                new MyGames {Name="Overcooked", Genre="Puzzle", Price=14.99},
                new MyGames {Name="Kingdom Hearts 3", Genre="RPG", Price=49.99},
                new MyGames { Name="Spiderman", Genre="Action/Adventure", Price=29.99},
                new MyGames { Name="Lego: The Hobbit", Genre="Puzzle, Action/Adventure", Price=9.99},
                new MyGames {Name="Tony Hawk's Pro Skater 5", Genre="Sports", Price=9.99},
            };
            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();

            var gameStats = new List<Stats>
            {
                new Stats{ MyGamesID=1,  HoursPlayed=130, IsBeaten= true, TrophiesEarned = 12 },
                new Stats{ MyGamesID=2,  HoursPlayed=80, IsBeaten= true, TrophiesEarned = 22 },
                new Stats{ MyGamesID=3,  HoursPlayed=30, IsBeaten= false, TrophiesEarned = 19 },
                new Stats{ MyGamesID=4,  HoursPlayed=50, IsBeaten= false, TrophiesEarned = 10 },
                new Stats{ MyGamesID=5,  HoursPlayed=42, IsBeaten= true, TrophiesEarned = 7 },
                new Stats{ MyGamesID=6,  HoursPlayed=35, IsBeaten= true, TrophiesEarned = 30 },
                new Stats{ MyGamesID=7,  HoursPlayed=6, IsBeaten= false, TrophiesEarned = 1 },
                new Stats{ MyGamesID=8,  HoursPlayed=15, IsBeaten= false, TrophiesEarned = 4 }
            };
            gameStats.ForEach(s => context.Stats.Add(s));
            context.SaveChanges();

            var coverArt = new List<CoverArt>
            {
                new CoverArt{MyGamesID=1, PhotoPath="~/content/RedDeadCover.jpg", AltText="Red Dead Redemption 2 Cover Art"},
                new CoverArt{MyGamesID=2, PhotoPath="~/content/FarCryCover.jpg", AltText="Far Cry 5 Cover Art"},
                new CoverArt{MyGamesID=3, PhotoPath="~/content/RocketLeagueCover.jpg", AltText="Rocket League Cover Art"},
                new CoverArt{MyGamesID=4, PhotoPath="~/content/OvercookedCover.jpg", AltText="Overcooked Cover Art"},
                new CoverArt{MyGamesID=5, PhotoPath="~/content/KingdomCover.jpg", AltText="Kingdom Hearts 3 Cover Art"},
                new CoverArt{MyGamesID=6, PhotoPath="~/content/SpidermanCover.jpg", AltText="Spider-Man Cover Art"},
                new CoverArt{MyGamesID=7, PhotoPath="~/content/LegoHobbit.jpg", AltText="Lego: The Hobbit Cover Art"},
                new CoverArt{MyGamesID=8, PhotoPath="~/content/TonyHawkCover.jpg", AltText="Tony Hawk Pro Skater 5 Cover Art"},
            };
            coverArt.ForEach(c => context.CoverArts.Add(c));
            context.SaveChanges();

            var trophieList = new List<Trophies>
            {
                new Trophies{  MyGamesID=1, Name="Redemption", Description="Finish the Final Chapter", Type="Gold"},
                new Trophies{ MyGamesID=1, Name="Helping Hand", Description="Complete All Companion Missions", Type="Silver"},
                new Trophies{ MyGamesID=3, Name="Distance Driver", Description="Drive 5000 Kilometers", Type="Bronze"},
                new Trophies{  MyGamesID=3, Name="Hat Trick", Description="Score Three Goals in One Game", Type="Bronze"},
                new Trophies{ MyGamesID=4, Name="Bon Apetit", Description="Get Three Stars On every Level in the First Chapter", Type="Silver"},
                new Trophies{  MyGamesID=5, Name="You've Got a Friend", Description="Complete Toy Story World", Type="Bronze"},
                new Trophies{  MyGamesID=6, Name="Wonderful Spider-Man", Description="Complete The Storyline In New Game Plus", Type="Platinum"},
                new Trophies{  MyGamesID=6, Name="Spectacular Spider-Man", Description="Complete 100% Trophies", Type="Platinum"},
            };
            trophieList.ForEach(t => context.Trophies.Add(t));
            context.SaveChanges();
        }

    }

}