namespace Moviegram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie_DetailsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Details");
        }
    }
}
