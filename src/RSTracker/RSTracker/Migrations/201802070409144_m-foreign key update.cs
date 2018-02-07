namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mforeignkeyupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Dept_Id", "dbo.Depts");
            DropForeignKey("dbo.Employees", "Division_Id", "dbo.Divisions");
            DropIndex("dbo.Employees", new[] { "Division_Id" });
            DropIndex("dbo.Employees", new[] { "Dept_Id" });
            RenameColumn(table: "dbo.Employees", name: "Dept_Id", newName: "DeptId");
            RenameColumn(table: "dbo.Employees", name: "Division_Id", newName: "DivisionId");
            AddColumn("dbo.Employees", "SubUnitId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "DivisionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DeptId");
            CreateIndex("dbo.Employees", "DivisionId");
            CreateIndex("dbo.Employees", "SubUnitId");
            AddForeignKey("dbo.Employees", "SubUnitId", "dbo.SubUnits", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "DeptId", "dbo.Depts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Depts");
            DropForeignKey("dbo.Employees", "SubUnitId", "dbo.SubUnits");
            DropIndex("dbo.Employees", new[] { "SubUnitId" });
            DropIndex("dbo.Employees", new[] { "DivisionId" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            AlterColumn("dbo.Employees", "DeptId", c => c.Int());
            AlterColumn("dbo.Employees", "DivisionId", c => c.Int());
            DropColumn("dbo.Employees", "SubUnitId");
            RenameColumn(table: "dbo.Employees", name: "DivisionId", newName: "Division_Id");
            RenameColumn(table: "dbo.Employees", name: "DeptId", newName: "Dept_Id");
            CreateIndex("dbo.Employees", "Dept_Id");
            CreateIndex("dbo.Employees", "Division_Id");
            AddForeignKey("dbo.Employees", "Division_Id", "dbo.Divisions", "Id");
            AddForeignKey("dbo.Employees", "Dept_Id", "dbo.Depts", "Id");
        }
    }
}
