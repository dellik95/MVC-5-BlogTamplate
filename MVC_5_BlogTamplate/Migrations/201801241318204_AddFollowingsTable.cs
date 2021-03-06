using System.Data.Entity.Migrations;

namespace MVC_5_BlogTamplate.Migrations
{
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Followings",
                    c => new
                    {
                        FollowerId = c.String(false, 128),
                        FolloweeId = c.String(false, 128)
                    })
                .PrimaryKey(t => new {t.FollowerId, t.FolloweeId})
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] {"FolloweeId"});
            DropIndex("dbo.Followings", new[] {"FollowerId"});
            DropTable("dbo.Followings");
        }
    }
}