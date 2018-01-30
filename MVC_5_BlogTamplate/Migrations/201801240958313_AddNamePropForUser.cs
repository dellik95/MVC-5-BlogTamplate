using System.Data.Entity.Migrations;

namespace MVC_5_BlogTamplate.Migrations
{
    public partial class AddNamePropForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}