namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedSpacePirateToTraveler : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "SpacePirateId", "dbo.SpacePirateProfile");
            DropIndex("dbo.Item", new[] { "SpacePirateId" });
            CreateTable(
                "dbo.SpaceTravelerProfile",
                c => new
                    {
                        SpaceTravelerId = c.Int(nullable: false, identity: true),
                        PirateAlias = c.String(nullable: false),
                        Credits = c.Double(nullable: false),
                        WantedLevel = c.String(nullable: false),
                        WillingToCooperate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SpaceTravelerId);
            
            AddColumn("dbo.Item", "SpaceTravelerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "SpaceTravelerId");
            AddForeignKey("dbo.Item", "SpaceTravelerId", "dbo.SpaceTravelerProfile", "SpaceTravelerId", cascadeDelete: true);
            DropColumn("dbo.Item", "SpacePirateId");
            DropTable("dbo.SpacePirateProfile");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SpacePirateProfile",
                c => new
                    {
                        SpacePirateId = c.Int(nullable: false, identity: true),
                        PirateAlias = c.String(nullable: false),
                        Credits = c.Double(nullable: false),
                        WantedLevel = c.String(nullable: false),
                        WillingToCooperate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SpacePirateId);
            
            AddColumn("dbo.Item", "SpacePirateId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Item", "SpaceTravelerId", "dbo.SpaceTravelerProfile");
            DropIndex("dbo.Item", new[] { "SpaceTravelerId" });
            DropColumn("dbo.Item", "SpaceTravelerId");
            DropTable("dbo.SpaceTravelerProfile");
            CreateIndex("dbo.Item", "SpacePirateId");
            AddForeignKey("dbo.Item", "SpacePirateId", "dbo.SpacePirateProfile", "SpacePirateId", cascadeDelete: true);
        }
    }
}
