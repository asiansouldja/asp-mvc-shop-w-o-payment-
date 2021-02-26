namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryModels", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CategoryModels", "Description");
        }
    }
}
