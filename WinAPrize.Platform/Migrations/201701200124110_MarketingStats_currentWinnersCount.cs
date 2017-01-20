namespace WinAPrize.Platform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarketingStats_currentWinnersCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarketingStats", "CurrentWinnersCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarketingStats", "CurrentWinnersCount");
        }
    }
}
