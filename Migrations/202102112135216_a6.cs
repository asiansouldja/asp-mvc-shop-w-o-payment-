namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "img", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "categoryId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "categoryId", c => c.String());
            AlterColumn("dbo.Products", "img", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
