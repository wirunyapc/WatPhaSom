namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetoordermodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LineProduct", "orderId", "dbo.Order");
            DropForeignKey("dbo.LineProduct", "productId", "dbo.Product");
            DropIndex("dbo.LineProduct", new[] { "orderId" });
            DropIndex("dbo.LineProduct", new[] { "productId" });
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_OrderId = c.Int(),
                        Order_OrderId1 = c.Int(),
                        Order_OrderId2 = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Product", t => t.productId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_OrderId)
                .ForeignKey("dbo.Order", t => t.Order_OrderId1)
                .ForeignKey("dbo.Order", t => t.Order_OrderId2)
                .Index(t => t.productId)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Order_OrderId1)
                .Index(t => t.Order_OrderId2);
            
            AddColumn("dbo.Order", "Username", c => c.String());
            AddColumn("dbo.Order", "FirstName", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.Order", "LastName", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.Order", "Address", c => c.String(nullable: false, maxLength: 70));
            AddColumn("dbo.Order", "State", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Order", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Order", "Country", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Order", "Phone", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.Order", "Email", c => c.String());
            AddColumn("dbo.Order", "SaveInfo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Order", "City", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.Order", "customerId");
            DropColumn("dbo.Order", "lineProductId");
            DropColumn("dbo.Order", "totalPrice");
            DropColumn("dbo.Order", "street");
            DropColumn("dbo.Order", "region");
            DropColumn("dbo.Order", "postcode");
            DropColumn("dbo.Order", "country_id");
            DropColumn("dbo.Order", "paymentMethod");
            DropTable("dbo.LineProduct");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LineProduct",
                c => new
                    {
                        lineProductId = c.Int(nullable: false, identity: true),
                        orderId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lineProductId);
            
            AddColumn("dbo.Order", "paymentMethod", c => c.String());
            AddColumn("dbo.Order", "country_id", c => c.String());
            AddColumn("dbo.Order", "postcode", c => c.String());
            AddColumn("dbo.Order", "region", c => c.String());
            AddColumn("dbo.Order", "street", c => c.String());
            AddColumn("dbo.Order", "totalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "lineProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "customerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetail", "Order_OrderId2", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "Order_OrderId1", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "productId", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "Order_OrderId2" });
            DropIndex("dbo.OrderDetail", new[] { "Order_OrderId1" });
            DropIndex("dbo.OrderDetail", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderDetail", new[] { "productId" });
            AlterColumn("dbo.Order", "City", c => c.String());
            DropColumn("dbo.Order", "Total");
            DropColumn("dbo.Order", "SaveInfo");
            DropColumn("dbo.Order", "Email");
            DropColumn("dbo.Order", "Phone");
            DropColumn("dbo.Order", "Country");
            DropColumn("dbo.Order", "PostalCode");
            DropColumn("dbo.Order", "State");
            DropColumn("dbo.Order", "Address");
            DropColumn("dbo.Order", "LastName");
            DropColumn("dbo.Order", "FirstName");
            DropColumn("dbo.Order", "Username");
            DropTable("dbo.OrderDetail");
            CreateIndex("dbo.LineProduct", "productId");
            CreateIndex("dbo.LineProduct", "orderId");
            AddForeignKey("dbo.LineProduct", "productId", "dbo.Product", "productId", cascadeDelete: true);
            AddForeignKey("dbo.LineProduct", "orderId", "dbo.Order", "orderId", cascadeDelete: true);
        }
    }
}
