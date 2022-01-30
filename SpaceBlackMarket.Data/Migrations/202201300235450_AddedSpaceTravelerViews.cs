namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpaceTravelerViews : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SpaceTravelerProfile", "WantedLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpaceTravelerProfile", "WantedLevel", c => c.String(nullable: false));
        }
    }
}
