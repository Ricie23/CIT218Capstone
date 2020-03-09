using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCapstone.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCCapstone.DAL
{
    public class GameContext : DbContext
    {
        public GameContext() : base("GameContext")
        {
        }
        public DbSet<MyGames> Games { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<CoverArt> CoverArts { get; set; }
        public DbSet<Trophies> Trophies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}