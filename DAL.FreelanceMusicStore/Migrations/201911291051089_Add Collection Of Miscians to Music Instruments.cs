namespace DAL.FreelanceMusicStore1.Migrations {
    using System.Data.Entity.Migrations;

    public partial class AddCollectionOfMiscianstoMusicInstruments : DbMigration {
        public override void Up() {
            DropForeignKey("dbo.MusicInstruments", "Musician_Id", "dbo.Musicians");
            DropIndex("dbo.MusicInstruments", new[] { "Musician_Id" });
            CreateTable(
                "dbo.MusicInstrumentMusicians",
                c => new {
                    MusicInstrument_Id = c.Guid(nullable: false),
                    Musician_Id = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.MusicInstrument_Id, t.Musician_Id })
                .ForeignKey("dbo.MusicInstruments", t => t.MusicInstrument_Id, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.Musician_Id, cascadeDelete: true)
                .Index(t => t.MusicInstrument_Id)
                .Index(t => t.Musician_Id);

            DropColumn("dbo.MusicInstruments", "Musician_Id");
        }

        public override void Down() {
            AddColumn("dbo.MusicInstruments", "Musician_Id", c => c.Guid());
            DropForeignKey("dbo.MusicInstrumentMusicians", "Musician_Id", "dbo.Musicians");
            DropForeignKey("dbo.MusicInstrumentMusicians", "MusicInstrument_Id", "dbo.MusicInstruments");
            DropIndex("dbo.MusicInstrumentMusicians", new[] { "Musician_Id" });
            DropIndex("dbo.MusicInstrumentMusicians", new[] { "MusicInstrument_Id" });
            DropTable("dbo.MusicInstrumentMusicians");
            CreateIndex("dbo.MusicInstruments", "Musician_Id");
            AddForeignKey("dbo.MusicInstruments", "Musician_Id", "dbo.Musicians", "Id");
        }
    }
}
