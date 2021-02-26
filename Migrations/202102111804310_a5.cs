namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "categoryId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "categoryId", c => c.Int(nullable: false));
        }
    }
}
