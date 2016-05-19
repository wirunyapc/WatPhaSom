namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payment", "paymentId", "dbo.Order");
            DropForeignKey("dbo.Shipping", "shippingId", "dbo.Order");
            DropIndex("dbo.Payment", new[] { "paymentId" });
            DropIndex("dbo.Shipping", new[] { "shippingId" });
            AddColumn("dbo.Order", "toHomeCost", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "street", c => c.String());
            AddColumn("dbo.Order", "city", c => c.String());
            AddColumn("dbo.Order", "region", c => c.String());
            AddColumn("dbo.Order", "postcode", c => c.String());
            AddColumn("dbo.Order", "country_id", c => c.String());
            AddColumn("dbo.Order", "isPay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "paymentMethod", c => c.String());
            AddColumn("dbo.Order", "slipPath", c => c.String());
            DropColumn("dbo.Order", "paymentId");
            DropColumn("dbo.Order", "shippingId");
            DropTable("dbo.Payment");
            DropTable("dbo.Shipping");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Shipping",
                c => new
                    {
                        shippingId = c.Int(nullable: false),
                        toHomeCost = c.Double(nullable: false),
                        street = c.String(),
                        city = c.String(),
                        region = c.String(),
                        postcode = c.String(),
                        country_id = c.String(),
                    })
                .PrimaryKey(t => t.shippingId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        paymentId = c.Int(nullable: false),
                        isPay = c.Boolean(nullable: false),
                        paymentMethod = c.String(),
                        slipPath = c.String(),
                    })
                .PrimaryKey(t => t.paymentId);
            
            AddColumn("dbo.Order", "shippingId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "paymentId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "slipPath");
            DropColumn("dbo.Order", "paymentMethod");
            DropColumn("dbo.Order", "isPay");
            DropColumn("dbo.Order", "country_id");
            DropColumn("dbo.Order", "postcode");
            DropColumn("dbo.Order", "region");
            DropColumn("dbo.Order", "city");
            DropColumn("dbo.Order", "street");
            DropColumn("dbo.Order", "toHomeCost");
            CreateIndex("dbo.Shipping", "shippingId");
            CreateIndex("dbo.Payment", "paymentId");
            AddForeignKey("dbo.Shipping", "shippingId", "dbo.Order", "orderId");
            AddForeignKey("dbo.Payment", "paymentId", "dbo.Order", "orderId");
        }
    }
}
