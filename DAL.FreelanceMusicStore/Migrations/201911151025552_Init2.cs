namespace DAL.FreelanceMusicStore1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "MusicInstrument_Id", "dbo.MusicInstruments");
            DropIndex("dbo.Orders", new[] { "MusicInstrument_Id" });
            DropColumn("dbo.Orders", "MusicInstrumentId");
            RenameColumn(table: "dbo.Orders", name: "MusicInstrument_Id", newName: "MusicInstrumentId");
            AlterColumn("dbo.Orders", "MusicInstrumentId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "MusicInstrumentId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Orders", "MusicInstrumentId");
            AddForeignKey("dbo.Orders", "MusicInstrumentId", "dbo.MusicInstruments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "MusicInstrumentId", "dbo.MusicInstruments");
            DropIndex("dbo.Orders", new[] { "MusicInstrumentId" });
            AlterColumn("dbo.Orders", "MusicInstrumentId", c => c.Guid());
            AlterColumn("dbo.Orders", "MusicInstrumentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "MusicInstrumentId", newName: "MusicInstrument_Id");
            AddColumn("dbo.Orders", "MusicInstrumentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "MusicInstrument_Id");
            AddForeignKey("dbo.Orders", "MusicInstrument_Id", "dbo.MusicInstruments", "Id");
        }
    }
}
