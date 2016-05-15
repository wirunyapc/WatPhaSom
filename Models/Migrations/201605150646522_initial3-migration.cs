namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Order_orderId", "dbo.Order");
            DropIndex("dbo.Product", new[] { "Order_orderId" });
            CreateTable(
                "dbo.LineProduct",
                c => new
                    {
                        lineProductId = c.Int(nullable: false, identity: true),
                        orderId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lineProductId)
                .ForeignKey("dbo.Order", t => t.orderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.productId, cascadeDelete: true)
                .Index(t => t.orderId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        paymentId = c.Int(nullable: false),
                        isPay = c.Boolean(nullable: false),
                        paymentMethodId = c.Int(nullable: false),
                        slipPath = c.String(),
                    })
                .PrimaryKey(t => t.paymentId)
                .ForeignKey("dbo.Order", t => t.paymentId)
                .Index(t => t.paymentId);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        paymentMethodId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.paymentMethodId);
            
            AddColumn("dbo.Order", "customerId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "paymentId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "lineProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "isConfirm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "deliverAddress", c => c.String());
            AddColumn("dbo.Order", "mountainCost", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "toHomeCost", c => c.Double(nullable: false));
            CreateIndex("dbo.Order", "customerId");
            AddForeignKey("dbo.Order", "customerId", "dbo.Customer", "customerId", cascadeDelete: true);
            DropColumn("dbo.Order", "orderConfirmationStatus");
            DropColumn("dbo.Order", "paymentConfirmationStatus");
            DropColumn("dbo.Order", "deliveryCostMountain");
            DropColumn("dbo.Order", "deliveryCostService");
            DropColumn("dbo.Product", "Order_orderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Order_orderId", c => c.Int());
            AddColumn("dbo.Order", "deliveryCostService", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "deliveryCostMountain", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "paymentConfirmationStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "orderConfirmationStatus", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Payment", "paymentId", "dbo.Order");
            DropForeignKey("dbo.LineProduct", "productId", "dbo.Product");
            DropForeignKey("dbo.LineProduct", "orderId", "dbo.Order");
            DropForeignKey("dbo.Order", "customerId", "dbo.Customer");
            DropIndex("dbo.Payment", new[] { "paymentId" });
            DropIndex("dbo.LineProduct", new[] { "productId" });
            DropIndex("dbo.LineProduct", new[] { "orderId" });
            DropIndex("dbo.Order", new[] { "customerId" });
            DropColumn("dbo.Order", "toHomeCost");
            DropColumn("dbo.Order", "mountainCost");
            DropColumn("dbo.Order", "deliverAddress");
            DropColumn("dbo.Order", "isConfirm");
            DropColumn("dbo.Order", "lineProductId");
            DropColumn("dbo.Order", "paymentId");
            DropColumn("dbo.Order", "customerId");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.Payment");
            DropTable("dbo.LineProduct");
            CreateIndex("dbo.Product", "Order_orderId");
            AddForeignKey("dbo.Product", "Order_orderId", "dbo.Order", "orderId");
        }
    }
}
