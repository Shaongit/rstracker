namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstatusfk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requisitions", "Status", c => c.Int(nullable: false));
            CreateIndex("dbo.Requisitions", "Status");
            AddForeignKey("dbo.Requisitions", "Status", "dbo.Status", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requisitions", "Status", "dbo.Status");
            DropIndex("dbo.Requisitions", new[] { "Status" });
            AlterColumn("dbo.Requisitions", "Status", c => c.String());
        }
    }
}
