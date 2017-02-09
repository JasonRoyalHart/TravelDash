namespace TravelDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class something : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HotelModels");
            AddColumn("dbo.HotelModels", "property_code", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.HotelModels", "property_name", c => c.String());
            AddColumn("dbo.HotelModels", "address", c => c.String());
            AddColumn("dbo.HotelModels", "total_price", c => c.String());
            AddColumn("dbo.TempHotels", "property_code", c => c.String());
            AddColumn("dbo.TempHotels", "property_name", c => c.String());
            AddColumn("dbo.TempHotels", "address", c => c.String());
            AddColumn("dbo.TempHotels", "total_price", c => c.String());
            AddPrimaryKey("dbo.HotelModels", "property_code");
            DropColumn("dbo.HotelModels", "Id");
            DropColumn("dbo.HotelModels", "HotelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HotelModels", "HotelId", c => c.Int(nullable: false));
            AddColumn("dbo.HotelModels", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.HotelModels");
            DropColumn("dbo.TempHotels", "total_price");
            DropColumn("dbo.TempHotels", "address");
            DropColumn("dbo.TempHotels", "property_name");
            DropColumn("dbo.TempHotels", "property_code");
            DropColumn("dbo.HotelModels", "total_price");
            DropColumn("dbo.HotelModels", "address");
            DropColumn("dbo.HotelModels", "property_name");
            DropColumn("dbo.HotelModels", "property_code");
            AddPrimaryKey("dbo.HotelModels", "Id");
        }
    }
}
