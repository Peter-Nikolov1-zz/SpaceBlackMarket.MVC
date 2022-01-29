namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "SpacePirateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "SpacePirateId");
            AddForeignKey("dbo.Item", "SpacePirateId", "dbo.SpacePirateProfile", "SpacePirateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "SpacePirateId", "dbo.SpacePirateProfile");
            DropIndex("dbo.Item", new[] { "SpacePirateId" });
            DropColumn("dbo.Item", "SpacePirateId");
        }
    }
}
