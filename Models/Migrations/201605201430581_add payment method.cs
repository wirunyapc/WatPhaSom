namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpaymentmethod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "paymentMethod", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "paymentMethod");
        }
    }
}
