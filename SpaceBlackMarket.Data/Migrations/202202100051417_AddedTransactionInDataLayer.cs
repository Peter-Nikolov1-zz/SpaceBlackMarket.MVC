namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTransactionInDataLayer : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.SpaceTravelerProfile", "TransactionId");
            AddForeignKey("dbo.SpaceTravelerProfile", "TransactionId", "dbo.Transaction", "TransactionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpaceTravelerProfile", "TransactionId", "dbo.Transaction");
            DropIndex("dbo.SpaceTravelerProfile", new[] { "TransactionId" });
            DropColumn("dbo.SpaceTravelerProfile", "TransactionId");
            DropTable("dbo.Transaction");
        }
    }
}
