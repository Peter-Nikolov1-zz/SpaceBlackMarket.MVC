namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpaceTravelerIsNowNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "SpaceTravelerProfileId", "dbo.SpaceTravelerProfile");
            DropIndex("dbo.Item", new[] { "SpaceTravelerProfileId" });
            AlterColumn("dbo.Item", "SpaceTravelerProfileId", c => c.Int());
            CreateIndex("dbo.Item", "SpaceTravelerProfileId");
            AddForeignKey("dbo.Item", "SpaceTravelerProfileId", "dbo.SpaceTravelerProfile", "SpaceTravelerProfileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "SpaceTravelerProfileId", "dbo.SpaceTravelerProfile");
            DropIndex("dbo.Item", new[] { "SpaceTravelerProfileId" });
            AlterColumn("dbo.Item", "SpaceTravelerProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "SpaceTravelerProfileId");
            AddForeignKey("dbo.Item", "SpaceTravelerProfileId", "dbo.SpaceTravelerProfile", "SpaceTravelerProfileId", cascadeDelete: true);
        }
    }
}
