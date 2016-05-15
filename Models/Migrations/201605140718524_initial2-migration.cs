namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2migration : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        orderDate = c.DateTime(nullable: false),
                        totalPrice = c.Double(nullable: false),
                        orderConfirmationStatus = c.Boolean(nullable: false),
                        paymentConfirmationStatus = c.Boolean(nullable: false),
                        deliveryCostMountain = c.Double(nullable: false),
                        deliveryCostService = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.orderId);
            
            AddColumn("dbo.Product", "Order_orderId", c => c.Int());
            CreateIndex("dbo.Product", "Order_orderId");
            AddForeignKey("dbo.Product", "Order_orderId", "dbo.Order", "orderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Order_orderId", "dbo.Order");
            DropIndex("dbo.Product", new[] { "Order_orderId" });
            DropColumn("dbo.Product", "Order_orderId");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
