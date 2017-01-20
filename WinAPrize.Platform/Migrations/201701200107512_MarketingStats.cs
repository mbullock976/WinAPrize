namespace WinAPrize.Platform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarketingStats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarketingStats",
                c => new
                    {
                        MarketingStatsId = c.Int(nullable: false, identity: true),
                        TotalWinningLimitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MarketingStatsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MarketingStats");
        }
    }
}
