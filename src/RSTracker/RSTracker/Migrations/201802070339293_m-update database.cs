namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mupdatedatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Designation_Id", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "Designation_Id" });
            RenameColumn(table: "dbo.Employees", name: "Designation_Id", newName: "DesignationId");
            AlterColumn("dbo.Employees", "DesignationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DesignationId");
            AddForeignKey("dbo.Employees", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            AlterColumn("dbo.Employees", "DesignationId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "DesignationId", newName: "Designation_Id");
            CreateIndex("dbo.Employees", "Designation_Id");
            AddForeignKey("dbo.Employees", "Designation_Id", "dbo.Designations", "Id");
        }
    }
}
