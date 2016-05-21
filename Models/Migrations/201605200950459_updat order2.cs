namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatorder2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "isPay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "isPay", c => c.Boolean(nullable: false));
        }
    }
}
