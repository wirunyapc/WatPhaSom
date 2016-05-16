namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "customerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "customerId" });
            DropTable("dbo.Customer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        customerId = c.Int(nullable: false, identity: true),
                        customerName = c.String(),
                        customerSurname = c.String(),
                        telephoneNo = c.String(),
                        address = c.String(),
                        email = c.String(),
                        password = c.Int(nullable: false),
                        customerType = c.String(),
                    })
                .PrimaryKey(t => t.customerId);
            
            CreateIndex("dbo.Order", "customerId");
            AddForeignKey("dbo.Order", "customerId", "dbo.Customer", "customerId", cascadeDelete: true);
        }
    }
}
