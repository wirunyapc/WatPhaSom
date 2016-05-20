namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "Province", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Province");
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "City");
        }
    }
}
