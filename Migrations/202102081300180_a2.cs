namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        img = c.String(),
                        Description = c.String(),
                        CategoryModels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryModels", t => t.CategoryModels_Id)
                .Index(t => t.CategoryModels_Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryModels_Id", "dbo.CategoryModels");
            DropIndex("dbo.Products", new[] { "CategoryModels_Id" });
            DropColumn("dbo.AspNetUsers", "SecondName");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.CategoryModels");
        }
    }
}
