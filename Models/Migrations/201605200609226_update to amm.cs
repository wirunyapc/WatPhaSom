namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetoamm : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderDetail", name: "Order_OrderId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.OrderDetail", name: "Order_OrderId1", newName: "Order_OrderId");
            RenameColumn(table: "dbo.OrderDetail", name: "__mig_tmp__0", newName: "Order_OrderId1");
            RenameIndex(table: "dbo.OrderDetail", name: "IX_Order_OrderId1", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.OrderDetail", name: "IX_Order_OrderId", newName: "IX_Order_OrderId1");
            RenameIndex(table: "dbo.OrderDetail", name: "__mig_tmp__0", newName: "IX_Order_OrderId");
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
            
            AddColumn("dbo.OrderDetail", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Order", "isConfirm", c => c.String());
            AlterColumn("dbo.Order", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "productId", "dbo.Product");
            DropIndex("dbo.Cart", new[] { "productId" });
            AlterColumn("dbo.Order", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.Order", "isConfirm", c => c.Boolean(nullable: false));
            DropColumn("dbo.OrderDetail", "UnitPrice");
            DropTable("dbo.Cart");
            RenameIndex(table: "dbo.OrderDetail", name: "IX_Order_OrderId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.OrderDetail", name: "IX_Order_OrderId1", newName: "IX_Order_OrderId");
            RenameIndex(table: "dbo.OrderDetail", name: "__mig_tmp__0", newName: "IX_Order_OrderId1");
            RenameColumn(table: "dbo.OrderDetail", name: "Order_OrderId1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.OrderDetail", name: "Order_OrderId", newName: "Order_OrderId1");
            RenameColumn(table: "dbo.OrderDetail", name: "__mig_tmp__0", newName: "Order_OrderId");
        }
    }
}
