namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Sales", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "StoreId" });
            DropIndex("dbo.Sales", new[] { "ProductId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
        }
    }
}
