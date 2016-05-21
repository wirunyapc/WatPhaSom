namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymmentdropdown : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        paymentId = c.String(nullable: false, maxLength: 128),
                        paymentMethod = c.String(),
                    })
                .PrimaryKey(t => t.paymentId);
            
            AddColumn("dbo.Order", "paymentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Order", "paymentId");
            AddForeignKey("dbo.Order", "paymentId", "dbo.Payment", "paymentId");
            DropColumn("dbo.Order", "paymentMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "paymentMethod", c => c.String());
            DropForeignKey("dbo.Order", "paymentId", "dbo.Payment");
            DropIndex("dbo.Order", new[] { "paymentId" });
            DropColumn("dbo.Order", "paymentId");
            DropTable("dbo.Payment");
        }
    }
}
