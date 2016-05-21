namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateshippingandorder : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "deliverAddress");
            DropColumn("dbo.Order", "toHomeCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "toHomeCost", c => c.Double(nullable: false));
            AddColumn("dbo.Order", "deliverAddress", c => c.String());
        }
    }
}
