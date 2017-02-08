namespace TravelDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdedChangesToRestaurants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TempRestaurants", "Name", c => c.String());
            AddColumn("dbo.TempRestaurants", "Phone", c => c.String());
            AddColumn("dbo.TempRestaurants", "Category", c => c.String());
            AddColumn("dbo.TempRestaurants", "ImageUrl", c => c.String());
            AddColumn("dbo.TempRestaurants", "RatingUrl", c => c.String());
            AddColumn("dbo.TempRestaurants", "Review", c => c.String());
            AddColumn("dbo.TempRestaurants", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TempRestaurants", "Link");
            DropColumn("dbo.TempRestaurants", "Review");
            DropColumn("dbo.TempRestaurants", "RatingUrl");
            DropColumn("dbo.TempRestaurants", "ImageUrl");
            DropColumn("dbo.TempRestaurants", "Category");
            DropColumn("dbo.TempRestaurants", "Phone");
            DropColumn("dbo.TempRestaurants", "Name");
        }
    }
}
