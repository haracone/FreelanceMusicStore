namespace DAL.FreelanceMusicStore1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fapi : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MusicInstrumentMusicians");
            AddPrimaryKey("dbo.MusicInstrumentMusicians", new[] { "Musician_Id", "MusicInstrument_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MusicInstrumentMusicians");
            AddPrimaryKey("dbo.MusicInstrumentMusicians", new[] { "MusicInstrument_Id", "Musician_Id" });
        }
    }
}
