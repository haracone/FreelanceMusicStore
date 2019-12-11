namespace DAL.FreelanceMusicStore1.Migrations {
    using System.Data.Entity.Migrations;

    public partial class AddOrderIdPropToComment : DbMigration {
        public override void Up() {
            AddColumn("dbo.Comments", "OrderId", c => c.Guid());
            CreateIndex("dbo.Comments", "OrderId");
            AddForeignKey("dbo.Comments", "OrderId", "dbo.Orders", "Id");
        }

        public override void Down() {
            DropForeignKey("dbo.Comments", "OrderId", "dbo.Orders");
            DropIndex("dbo.Comments", new[] { "OrderId" });
            DropColumn("dbo.Comments", "OrderId");
        }
    }
}
