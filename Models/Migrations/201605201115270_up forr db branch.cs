namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upforrdbbranch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "Product_productId", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.OrderDetail", new[] { "Product_productId" });
            RenameColumn(table: "dbo.OrderDetail", name: "Product_productId", newName: "productId");
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        productId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
            AddColumn("dbo.OrderDetail", "Order_orderId", c => c.Int());
            AddColumn("dbo.OrderDetail", "Order_orderId1", c => c.Int());
            AddColumn("dbo.OrderDetail", "Order_orderId2", c => c.Int());
            AddColumn("dbo.Order", "SaveInfo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "toHomeCost", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "isConfirm", c => c.String());
            AddColumn("dbo.Order", "mountainCost", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "isPay", c => c.String());
            AddColumn("dbo.Order", "slipPath", c => c.String());
            AlterColumn("dbo.OrderDetail", "productId", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.OrderDetail", "productId");
            CreateIndex("dbo.OrderDetail", "Order_orderId");
            CreateIndex("dbo.OrderDetail", "Order_orderId1");
            CreateIndex("dbo.OrderDetail", "Order_orderId2");
            AddForeignKey("dbo.OrderDetail", "Order_orderId", "dbo.Order", "orderId");
            AddForeignKey("dbo.OrderDetail", "Order_orderId2", "dbo.Order", "orderId");
            AddForeignKey("dbo.OrderDetail", "productId", "dbo.Product", "productId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetail", "Order_orderId1", "dbo.Order", "orderId");
            DropColumn("dbo.OrderDetail", "ItemId");
            DropColumn("dbo.Order", "transferSlip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "transferSlip", c => c.String());
            AddColumn("dbo.OrderDetail", "ItemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetail", "Order_orderId1", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "productId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "Order_orderId2", "dbo.Order");
            DropForeignKey("dbo.Cart", "productId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "Order_orderId", "dbo.Order");
            DropIndex("dbo.OrderDetail", new[] { "Order_orderId2" });
            DropIndex("dbo.OrderDetail", new[] { "Order_orderId1" });
            DropIndex("dbo.OrderDetail", new[] { "Order_orderId" });
            DropIndex("dbo.OrderDetail", new[] { "productId" });
            DropIndex("dbo.Cart", new[] { "productId" });
            AlterColumn("dbo.Order", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetail", "productId", c => c.Int());
            DropColumn("dbo.Order", "slipPath");
            DropColumn("dbo.Order", "isPay");
            DropColumn("dbo.Order", "mountainCost");
            DropColumn("dbo.Order", "isConfirm");
            DropColumn("dbo.Order", "toHomeCost");
            DropColumn("dbo.Order", "SaveInfo");
            DropColumn("dbo.OrderDetail", "Order_orderId2");
            DropColumn("dbo.OrderDetail", "Order_orderId1");
            DropColumn("dbo.OrderDetail", "Order_orderId");
            DropTable("dbo.Cart");
            RenameColumn(table: "dbo.OrderDetail", name: "productId", newName: "Product_productId");
            CreateIndex("dbo.OrderDetail", "Product_productId");
            CreateIndex("dbo.OrderDetail", "OrderId");
            AddForeignKey("dbo.OrderDetail", "Product_productId", "dbo.Product", "productId");
            AddForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order", "orderId", cascadeDelete: true);
        }
    }
}
