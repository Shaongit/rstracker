namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedegignation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Designations", "DeptId", "dbo.Depts");
            DropIndex("dbo.Designations", new[] { "DeptId" });
            AddColumn("dbo.Designations", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Designations", "DivisionId");
            AddForeignKey("dbo.Designations", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
            DropColumn("dbo.Designations", "DeptId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Designations", "DeptId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Designations", "DivisionId", "dbo.Divisions");
            DropIndex("dbo.Designations", new[] { "DivisionId" });
            DropColumn("dbo.Designations", "DivisionId");
            CreateIndex("dbo.Designations", "DeptId");
            AddForeignKey("dbo.Designations", "DeptId", "dbo.Depts", "Id", cascadeDelete: true);
        }
    }
}
