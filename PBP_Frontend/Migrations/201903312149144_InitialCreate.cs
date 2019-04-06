namespace PBP_Frontend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeLogs",
                c => new
                    {
                        ChangeLogId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ListId = c.Int(nullable: false),
                        ListStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeLogId)
                .ForeignKey("dbo.Lists", t => t.ListId, cascadeDelete: true)
                .ForeignKey("dbo.ListStatus", t => t.ListStatusId, cascadeDelete: true)
                .Index(t => t.ListId)
                .Index(t => t.ListStatusId);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Requester = c.String(),
                    })
                .PrimaryKey(t => t.ListId);
            
            CreateTable(
                "dbo.ProductLists",
                c => new
                    {
                        ProductListId = c.Int(nullable: false, identity: true),
                        QuantityCatched = c.Int(nullable: false),
                        RequiredQuantity = c.Int(nullable: false),
                        ListId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductListId)
                .ForeignKey("dbo.Lists", t => t.ListId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ListId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Structure = c.Int(nullable: false),
                        Street = c.Int(nullable: false),
                        Building = c.Int(nullable: false),
                        Flat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.ListStatus",
                c => new
                    {
                        ListStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ListStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangeLogs", "ListStatusId", "dbo.ListStatus");
            DropForeignKey("dbo.ProductLists", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ProductLists", "ListId", "dbo.Lists");
            DropForeignKey("dbo.ChangeLogs", "ListId", "dbo.Lists");
            DropIndex("dbo.Products", new[] { "LocationId" });
            DropIndex("dbo.ProductLists", new[] { "ProductId" });
            DropIndex("dbo.ProductLists", new[] { "ListId" });
            DropIndex("dbo.ChangeLogs", new[] { "ListStatusId" });
            DropIndex("dbo.ChangeLogs", new[] { "ListId" });
            DropTable("dbo.ListStatus");
            DropTable("dbo.Locations");
            DropTable("dbo.Products");
            DropTable("dbo.ProductLists");
            DropTable("dbo.Lists");
            DropTable("dbo.ChangeLogs");
        }
    }
}
