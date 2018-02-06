namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforeign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Depts", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Depts", "DivisionId");
            AddForeignKey("dbo.Depts", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Depts", "DivisionId", "dbo.Divisions");
            DropIndex("dbo.Depts", new[] { "DivisionId" });
            DropColumn("dbo.Depts", "DivisionId");
        }
    }
}
