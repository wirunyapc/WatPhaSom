namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphotopathattribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "photoPath", c => c.String());
            DropColumn("dbo.Product", "duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "duration", c => c.DateTime(nullable: false));
            DropColumn("dbo.Product", "photoPath");
        }
    }
}
