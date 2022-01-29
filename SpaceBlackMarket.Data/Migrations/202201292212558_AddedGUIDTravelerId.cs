namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGUIDTravelerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpaceTravelerProfile", "TravelerId", c => c.Guid(nullable: false));
            AddColumn("dbo.SpaceTravelerProfile", "TravelerAlias", c => c.String(nullable: false));
            DropColumn("dbo.SpaceTravelerProfile", "PirateAlias");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpaceTravelerProfile", "PirateAlias", c => c.String(nullable: false));
            DropColumn("dbo.SpaceTravelerProfile", "TravelerAlias");
            DropColumn("dbo.SpaceTravelerProfile", "TravelerId");
        }
    }
}
