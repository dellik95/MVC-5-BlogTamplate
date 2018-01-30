using System.Data.Entity.Migrations;

namespace MVC_5_BlogTamplate.Migrations
{
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres (id,Name) values (1,'Rock')");
            Sql("insert into genres (id,Name) values (2,'DeathCore')");
            Sql("insert into genres (id,Name) values (3,'PostHardCore')");
            Sql("insert into genres (id,Name) values (4,'MetalCore')");
            Sql("insert into genres (id,Name) values (5,'Jazz')");
            Sql("insert into genres (id,Name) values (6,'HipHop')");
            Sql("insert into genres (id,Name) values (7,'Nu-Metal')");
        }

        public override void Down()
        {
            Sql("REMOVE FROM GENRES WHERE Id in(1,2,3,4,5,6,7)");
        }
    }
}