namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OrderDetail", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderDetail", new[] { "Order_OrderId1" });
            DropIndex("dbo.OrderDetail", new[] { "Order_OrderId2" });
            CreateIndex("dbo.OrderDetail", "Order_orderId");
            CreateIndex("dbo.OrderDetail", "Order_orderId1");
            CreateIndex("dbo.OrderDetail", "Order_orderId2");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderDetail", new[] { "Order_orderId2" });
            DropIndex("dbo.OrderDetail", new[] { "Order_orderId1" });
            DropIndex("dbo.OrderDetail", new[] { "Order_orderId" });
            CreateIndex("dbo.OrderDetail", "Order_OrderId2");
            CreateIndex("dbo.OrderDetail", "Order_OrderId1");
            CreateIndex("dbo.OrderDetail", "Order_OrderId");
        }
    }
}
