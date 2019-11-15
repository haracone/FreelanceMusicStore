namespace DAL.FreelanceMusicStore1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "MusicInstrument_Id", "dbo.MusicInstruments");
            DropIndex("dbo.Orders", new[] { "MusicInstrument_Id" });
            RenameColumn(table: "dbo.Orders", name: "MusicInstrument_Id", newName: "MusicInstrumentId");
            AlterColumn("dbo.Orders", "MusicInstrumentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "MusicInstrumentId");
            AddForeignKey("dbo.Orders", "MusicInstrumentId", "dbo.MusicInstruments", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "MusicInstumentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "MusicInstumentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "MusicInstrumentId", "dbo.MusicInstruments");
            DropIndex("dbo.Orders", new[] { "MusicInstrumentId" });
            AlterColumn("dbo.Orders", "MusicInstrumentId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "MusicInstrumentId", newName: "MusicInstrument_Id");
            CreateIndex("dbo.Orders", "MusicInstrument_Id");
            AddForeignKey("dbo.Orders", "MusicInstrument_Id", "dbo.MusicInstruments", "Id");
        }
    }
}
