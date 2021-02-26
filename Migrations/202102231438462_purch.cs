namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchases");
        }
    }
}
