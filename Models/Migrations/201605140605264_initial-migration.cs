namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Double(nullable: false),
                        description = c.String(),
                        duration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
        }
    }
}
