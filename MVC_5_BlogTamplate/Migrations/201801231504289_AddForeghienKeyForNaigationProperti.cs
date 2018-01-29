using System.Data.Entity.Migrations;

namespace MVC_5_BlogTamplate.Migrations
{
    public partial class AddForeghienKeyForNaigationProperti : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Gigs", "Artist_Id", "ArtistId");
            RenameColumn("dbo.Gigs", "Genre_Id", "GenreId");
            RenameIndex("dbo.Gigs", "IX_Artist_Id", "IX_ArtistId");
            RenameIndex("dbo.Gigs", "IX_Genre_Id", "IX_GenreId");
        }

        public override void Down()
        {
            RenameIndex("dbo.Gigs", "IX_GenreId", "IX_Genre_Id");
            RenameIndex("dbo.Gigs", "IX_ArtistId", "IX_Artist_Id");
            RenameColumn("dbo.Gigs", "GenreId", "Genre_Id");
            RenameColumn("dbo.Gigs", "ArtistId", "Artist_Id");
        }
    }
}