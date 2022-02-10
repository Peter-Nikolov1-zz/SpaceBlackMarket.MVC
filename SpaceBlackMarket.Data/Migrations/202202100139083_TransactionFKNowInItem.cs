namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionFKNowInItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "IsSold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Item", "TransactionId", c => c.Int());
            CreateIndex("dbo.Item", "TransactionId");
            AddForeignKey("dbo.Item", "TransactionId", "dbo.Transaction", "TransactionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "TransactionId", "dbo.Transaction");
            DropIndex("dbo.Item", new[] { "TransactionId" });
            DropColumn("dbo.Item", "TransactionId");
            DropColumn("dbo.Item", "IsSold");
        }
    }
}
