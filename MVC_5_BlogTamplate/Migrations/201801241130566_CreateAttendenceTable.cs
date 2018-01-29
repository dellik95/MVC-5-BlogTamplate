using System.Data.Entity.Migrations;

namespace MVC_5_BlogTamplate.Migrations
{
    public partial class CreateAttendenceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Attendances",
                    c => new
                    {
                        GigId = c.Int(false),
                        AttendeeId = c.String(false, 128)
                    })
                .PrimaryKey(t => new {t.GigId, t.AttendeeId})
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, true)
                .ForeignKey("dbo.Gigs", t => t.GigId)
                .Index(t => t.GigId)
                .Index(t => t.AttendeeId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "GigId", "dbo.Gigs");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] {"AttendeeId"});
            DropIndex("dbo.Attendances", new[] {"GigId"});
            DropTable("dbo.Attendances");
        }
    }
}