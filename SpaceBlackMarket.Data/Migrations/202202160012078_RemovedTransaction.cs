namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTransaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpaceTravelerProfile", "TransactionId", "dbo.Transaction");
            DropForeignKey("dbo.Item", "TransactionId", "dbo.Transaction");
            DropIndex("dbo.Item", new[] { "TransactionId" });
            DropIndex("dbo.SpaceTravelerProfile", new[] { "TransactionId" });
            DropColumn("dbo.Item", "TransactionId");
            DropColumn("dbo.SpaceTravelerProfile", "TransactionId");
            DropTable("dbo.Transaction");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        DateOfPurchase = c.DateTime(nullable: false),
                        CreditsAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
            
            AddColumn("dbo.SpaceTravelerProfile", "TransactionId", c => c.Int());
            AddColumn("dbo.Item", "TransactionId", c => c.Int());
            CreateIndex("dbo.SpaceTravelerProfile", "TransactionId");
            CreateIndex("dbo.Item", "TransactionId");
            AddForeignKey("dbo.Item", "TransactionId", "dbo.Transaction", "TransactionId");
            AddForeignKey("dbo.SpaceTravelerProfile", "TransactionId", "dbo.Transaction", "TransactionId");
        }
    }
}
