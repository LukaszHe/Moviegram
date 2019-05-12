namespace Moviegram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie_AdditionalColumns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieTimes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        CinemaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            AddColumn("dbo.Cinemas", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Picture", c => c.Binary());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieTimes", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieTimes", new[] { "MovieId" });
            DropColumn("dbo.Movies", "Picture");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Title");
            DropColumn("dbo.Cinemas", "Name");
            DropTable("dbo.MovieTimes");
        }
    }
}
