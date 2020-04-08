namespace RetailManagementTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "SalesPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "SalesPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
