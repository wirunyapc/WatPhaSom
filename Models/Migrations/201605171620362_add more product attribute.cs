namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmoreproductattribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "priceRetail", c => c.Double(nullable: false));
            AddColumn("dbo.Product", "priceWholesale", c => c.Double(nullable: false));
            DropColumn("dbo.Product", "price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "price", c => c.Double(nullable: false));
            DropColumn("dbo.Product", "priceWholesale");
            DropColumn("dbo.Product", "priceRetail");
        }
    }
}
