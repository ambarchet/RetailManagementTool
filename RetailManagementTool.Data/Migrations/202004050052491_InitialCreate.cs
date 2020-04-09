namespace RetailManagementTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentNumber = c.String(nullable: false, maxLength: 50),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        DepartmentPromotionId = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Promotion", t => t.DepartmentPromotionId)
                .Index(t => t.DepartmentPromotionId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductDepartmentId = c.Int(),
                        Style = c.String(nullable: false, maxLength: 50),
                        SKU = c.String(nullable: false, maxLength: 50),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Color = c.String(nullable: false, maxLength: 10),
                        ProductSizeId = c.Int(nullable: false),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductPromotionId = c.Int(),
                        ProductZoneId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Department", t => t.ProductDepartmentId)
                .ForeignKey("dbo.Promotion", t => t.ProductPromotionId)
                .ForeignKey("dbo.Size", t => t.ProductSizeId, cascadeDelete: false)
                .ForeignKey("dbo.Zone", t => t.ProductZoneId)
                .Index(t => t.ProductDepartmentId)
                .Index(t => t.ProductSizeId)
                .Index(t => t.ProductPromotionId)
                .Index(t => t.ProductZoneId);
            
            CreateTable(
                "dbo.Promotion",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PromotionDescription = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        SizeId = c.Int(nullable: false, identity: true),
                        SizeName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.SizeId);
            
            CreateTable(
                "dbo.Zone",
                c => new
                    {
                        ZoneId = c.Int(nullable: false, identity: true),
                        ZoneName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ZoneId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Department", "DepartmentPromotionId", "dbo.Promotion");
            DropForeignKey("dbo.Product", "ProductZoneId", "dbo.Zone");
            DropForeignKey("dbo.Product", "ProductSizeId", "dbo.Size");
            DropForeignKey("dbo.Product", "ProductPromotionId", "dbo.Promotion");
            DropForeignKey("dbo.Product", "ProductDepartmentId", "dbo.Department");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Product", new[] { "ProductZoneId" });
            DropIndex("dbo.Product", new[] { "ProductPromotionId" });
            DropIndex("dbo.Product", new[] { "ProductSizeId" });
            DropIndex("dbo.Product", new[] { "ProductDepartmentId" });
            DropIndex("dbo.Department", new[] { "DepartmentPromotionId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Zone");
            DropTable("dbo.Size");
            DropTable("dbo.Promotion");
            DropTable("dbo.Product");
            DropTable("dbo.Department");
        }
    }
}
