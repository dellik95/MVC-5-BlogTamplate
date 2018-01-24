namespace MVC_5_BlogTamplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamePropForUser1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
    }
}
