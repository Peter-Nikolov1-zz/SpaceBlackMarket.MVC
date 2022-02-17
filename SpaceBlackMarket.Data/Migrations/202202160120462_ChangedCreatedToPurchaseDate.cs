namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCreatedToPurchaseDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase", "PurchaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Purchase", "CreateUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchase", "CreateUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Purchase", "PurchaseDate");
        }
    }
}
