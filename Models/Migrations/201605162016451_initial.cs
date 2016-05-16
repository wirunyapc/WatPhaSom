namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Order",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        customerId = c.Int(nullable: false),
                        paymentId = c.Int(nullable: false),
                        lineProductId = c.Int(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                        isConfirm = c.Boolean(nullable: false),
                        deliverAddress = c.String(),
                        mountainCost = c.Double(nullable: false),
                        toHomeCost = c.Double(nullable: false),
                        totalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.orderId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        paymentId = c.Int(nullable: false),
                        isPay = c.Boolean(nullable: false),
                        paymentMethod = c.String(),
                        slipPath = c.String(),
                    })
                .PrimaryKey(t => t.paymentId)
                .ForeignKey("dbo.Order", t => t.paymentId)
                .Index(t => t.paymentId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Double(nullable: false),
                        description = c.String(),
                        photoPath = c.String(),
                    })
                .PrimaryKey(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineProduct", "productId", "dbo.Product");
            DropForeignKey("dbo.Payment", "paymentId", "dbo.Order");
            DropForeignKey("dbo.LineProduct", "orderId", "dbo.Order");
            DropIndex("dbo.Payment", new[] { "paymentId" });
            DropIndex("dbo.LineProduct", new[] { "productId" });
            DropIndex("dbo.LineProduct", new[] { "orderId" });
            DropTable("dbo.Product");
            DropTable("dbo.Payment");
            DropTable("dbo.Order");
            DropTable("dbo.LineProduct");
        }
    }
}
