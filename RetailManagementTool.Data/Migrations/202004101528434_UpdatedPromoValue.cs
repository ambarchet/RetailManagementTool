namespace RetailManagementTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPromoValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotion", "PromoValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Promotion", "PromotionValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotion", "PromotionValue", c => c.Int(nullable: false));
            DropColumn("dbo.Promotion", "PromoValue");
        }
    }
}
