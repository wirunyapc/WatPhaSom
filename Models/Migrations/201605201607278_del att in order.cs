namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delattinorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "paymentId", "dbo.Payment");
            DropIndex("dbo.Order", new[] { "paymentId" });
            AlterColumn("dbo.Order", "paymentId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "paymentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Order", "paymentId");
            AddForeignKey("dbo.Order", "paymentId", "dbo.Payment", "paymentId");
        }
    }
}
