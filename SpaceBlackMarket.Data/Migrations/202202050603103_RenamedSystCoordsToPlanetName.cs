namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedSystCoordsToPlanetName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Outpost", "PlanetName", c => c.String(nullable: false));
            DropColumn("dbo.Outpost", "SystemCoordinates");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Outpost", "SystemCoordinates", c => c.String(nullable: false));
            DropColumn("dbo.Outpost", "PlanetName");
        }
    }
}
