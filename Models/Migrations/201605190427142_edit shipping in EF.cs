namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editshippinginEF : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.shippingId)
                .ForeignKey("dbo.Order", t => t.shippingId)
                .Index(t => t.shippingId);
            
            AddColumn("dbo.Order", "shippingId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipping", "shippingId", "dbo.Order");
            DropIndex("dbo.Shipping", new[] { "shippingId" });
            DropColumn("dbo.Order", "shippingId");
            DropTable("dbo.Shipping");
        }
    }
}
