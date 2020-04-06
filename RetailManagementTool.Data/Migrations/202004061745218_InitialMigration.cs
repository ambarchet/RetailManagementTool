namespace RetailManagementTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PromotionType",
                c => new
                    {
                        PromotionTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PromotionTypeId);
            
            AddColumn("dbo.Promotion", "PromoTypeId", c => c.Int());
            CreateIndex("dbo.Promotion", "PromoTypeId");
            AddForeignKey("dbo.Promotion", "PromoTypeId", "dbo.PromotionType", "PromotionTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promotion", "PromoTypeId", "dbo.PromotionType");
            DropIndex("dbo.Promotion", new[] { "PromoTypeId" });
            DropColumn("dbo.Promotion", "PromoTypeId");
            DropTable("dbo.PromotionType");
        }
    }
}
