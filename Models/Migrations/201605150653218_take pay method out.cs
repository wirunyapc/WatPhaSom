namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class takepaymethodout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payment", "paymentMethod", c => c.String());
            DropColumn("dbo.Payment", "paymentMethodId");
            DropTable("dbo.PaymentMethod");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        paymentMethodId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.paymentMethodId);
            
            AddColumn("dbo.Payment", "paymentMethodId", c => c.Int(nullable: false));
            DropColumn("dbo.Payment", "paymentMethod");
        }
    }
}
