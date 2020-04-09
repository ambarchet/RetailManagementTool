namespace RetailManagementTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromoValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotion", "PromotionValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotion", "PromotionValue");
        }
    }
}
