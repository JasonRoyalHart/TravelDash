namespace TravelDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModels", "Provider", c => c.String());
            AddColumn("dbo.CarModels", "ImageUrl", c => c.String());
            AddColumn("dbo.CarModels", "Info", c => c.String());
            AddColumn("dbo.CarModels", "Price", c => c.String());
            AddColumn("dbo.PlaneModels", "InboundAirline", c => c.String());
            AddColumn("dbo.PlaneModels", "InboundDeparture", c => c.String());
            AddColumn("dbo.PlaneModels", "OutboundAirline", c => c.String());
            AddColumn("dbo.PlaneModels", "OutboundDeparture", c => c.String());
            AddColumn("dbo.TempCars", "Provider", c => c.String());
            AddColumn("dbo.TempCars", "ImageUrl", c => c.String());
            AddColumn("dbo.TempCars", "Info", c => c.String());
            AddColumn("dbo.TempCars", "Price", c => c.String());
            AddColumn("dbo.TempPlanes", "InboundAirline", c => c.String());
            AddColumn("dbo.TempPlanes", "InboundDeparture", c => c.String());
            AddColumn("dbo.TempPlanes", "OutboundAirline", c => c.String());
            AddColumn("dbo.TempPlanes", "OutboundDeparture", c => c.String());
            AlterColumn("dbo.CarModels", "UserId", c => c.String());
            DropColumn("dbo.CarModels", "CarId");
            DropColumn("dbo.PlaneModels", "PlaneId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlaneModels", "PlaneId", c => c.Int(nullable: false));
            AddColumn("dbo.CarModels", "CarId", c => c.Int(nullable: false));
            AlterColumn("dbo.CarModels", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.TempPlanes", "OutboundDeparture");
            DropColumn("dbo.TempPlanes", "OutboundAirline");
            DropColumn("dbo.TempPlanes", "InboundDeparture");
            DropColumn("dbo.TempPlanes", "InboundAirline");
            DropColumn("dbo.TempCars", "Price");
            DropColumn("dbo.TempCars", "Info");
            DropColumn("dbo.TempCars", "ImageUrl");
            DropColumn("dbo.TempCars", "Provider");
            DropColumn("dbo.PlaneModels", "OutboundDeparture");
            DropColumn("dbo.PlaneModels", "OutboundAirline");
            DropColumn("dbo.PlaneModels", "InboundDeparture");
            DropColumn("dbo.PlaneModels", "InboundAirline");
            DropColumn("dbo.CarModels", "Price");
            DropColumn("dbo.CarModels", "Info");
            DropColumn("dbo.CarModels", "ImageUrl");
            DropColumn("dbo.CarModels", "Provider");
        }
    }
}
