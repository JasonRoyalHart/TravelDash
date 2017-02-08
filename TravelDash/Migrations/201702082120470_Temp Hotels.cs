namespace TravelDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempHotels : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TempHotels");
            AddColumn("dbo.TempHotels", "property_code", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.TempHotels", "property_name", c => c.String());
            AddColumn("dbo.TempHotels", "address", c => c.String());
            AddColumn("dbo.TempHotels", "total_price", c => c.String());
            AddPrimaryKey("dbo.TempHotels", "property_code");
            DropColumn("dbo.TempHotels", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TempHotels", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.TempHotels");
            DropColumn("dbo.TempHotels", "total_price");
            DropColumn("dbo.TempHotels", "address");
            DropColumn("dbo.TempHotels", "property_name");
            DropColumn("dbo.TempHotels", "property_code");
            AddPrimaryKey("dbo.TempHotels", "ID");
        }
    }
}
