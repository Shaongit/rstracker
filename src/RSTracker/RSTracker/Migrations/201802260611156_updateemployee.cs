namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateemployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            AlterColumn("dbo.Employees", "DesignationId", c => c.Int());
            CreateIndex("dbo.Employees", "DesignationId");
            AddForeignKey("dbo.Employees", "DesignationId", "dbo.Designations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            AlterColumn("dbo.Employees", "DesignationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DesignationId");
            AddForeignKey("dbo.Employees", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
    }
}
