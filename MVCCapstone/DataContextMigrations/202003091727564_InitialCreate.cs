namespace MVCCapstone.DataContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoverArt",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MyGamesID = c.Int(nullable: false),
                        PhotoPath = c.String(),
                        AltText = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MyGames", t => t.MyGamesID, cascadeDelete: true)
                .Index(t => t.MyGamesID);
            
            CreateTable(
                "dbo.MyGames",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Genre = c.String(nullable: false, maxLength: 40),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MyGamesID = c.Int(nullable: false),
                        HoursPlayed = c.Int(nullable: false),
                        IsBeaten = c.Boolean(nullable: false),
                        TrophiesEarned = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MyGames", t => t.MyGamesID, cascadeDelete: true)
                .Index(t => t.MyGamesID);
            
            CreateTable(
                "dbo.Trophies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MyGamesID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MyGames", t => t.MyGamesID, cascadeDelete: true)
                .Index(t => t.MyGamesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trophies", "MyGamesID", "dbo.MyGames");
            DropForeignKey("dbo.Stats", "MyGamesID", "dbo.MyGames");
            DropForeignKey("dbo.CoverArt", "MyGamesID", "dbo.MyGames");
            DropIndex("dbo.Trophies", new[] { "MyGamesID" });
            DropIndex("dbo.Stats", new[] { "MyGamesID" });
            DropIndex("dbo.CoverArt", new[] { "MyGamesID" });
            DropTable("dbo.Trophies");
            DropTable("dbo.Stats");
            DropTable("dbo.MyGames");
            DropTable("dbo.CoverArt");
        }
    }
}
