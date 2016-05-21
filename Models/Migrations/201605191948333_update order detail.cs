namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderdetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
