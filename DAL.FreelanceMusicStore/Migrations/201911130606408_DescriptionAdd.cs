namespace DAL.FreelanceMusicStore1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "MusicDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "MusicDescription");
        }
    }
}
