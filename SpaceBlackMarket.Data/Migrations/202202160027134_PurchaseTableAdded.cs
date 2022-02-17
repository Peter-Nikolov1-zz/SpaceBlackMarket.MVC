namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseTotal = c.Double(nullable: false),
                        CreateUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
            AddColumn("dbo.Item", "PurchaseId", c => c.Int());
            AddColumn("dbo.SpaceTravelerProfile", "PurchaseId", c => c.Int());
            CreateIndex("dbo.Item", "PurchaseId");
            CreateIndex("dbo.SpaceTravelerProfile", "PurchaseId");
            AddForeignKey("dbo.Item", "PurchaseId", "dbo.Purchase", "PurchaseId");
            AddForeignKey("dbo.SpaceTravelerProfile", "PurchaseId", "dbo.Purchase", "PurchaseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpaceTravelerProfile", "PurchaseId", "dbo.Purchase");
            DropForeignKey("dbo.Item", "PurchaseId", "dbo.Purchase");
            DropIndex("dbo.SpaceTravelerProfile", new[] { "PurchaseId" });
            DropIndex("dbo.Item", new[] { "PurchaseId" });
            DropColumn("dbo.SpaceTravelerProfile", "PurchaseId");
            DropColumn("dbo.Item", "PurchaseId");
            DropTable("dbo.Purchase");
        }
    }
}
