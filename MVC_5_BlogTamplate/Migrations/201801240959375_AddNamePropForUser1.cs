using System.Data.Entity.Migrations;

namespace MVC_5_BlogTamplate.Migrations
{
    public partial class AddNamePropForUser1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(false, 100));
        }

        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
    }
}