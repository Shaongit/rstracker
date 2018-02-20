namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requistionenablenull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requisitions", "DeptId", "dbo.Depts");
            DropForeignKey("dbo.Requisitions", "PositionId", "dbo.Designations");
            DropForeignKey("dbo.Requisitions", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Requisitions", "RaisedBy", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "RequiredBy", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Requisitions", "SubUnitId", "dbo.SubUnits");
            DropIndex("dbo.Requisitions", new[] { "RaisedBy" });
            DropIndex("dbo.Requisitions", new[] { "PositionId" });
            DropIndex("dbo.Requisitions", new[] { "DivisionId" });
            DropIndex("dbo.Requisitions", new[] { "DeptId" });
            DropIndex("dbo.Requisitions", new[] { "SubUnitId" });
            DropIndex("dbo.Requisitions", new[] { "RequiredBy" });
            DropIndex("dbo.Requisitions", new[] { "StatusId" });
            AlterColumn("dbo.Requisitions", "RaisedBy", c => c.Int());
            AlterColumn("dbo.Requisitions", "PositionId", c => c.Int());
            AlterColumn("dbo.Requisitions", "DivisionId", c => c.Int());
            AlterColumn("dbo.Requisitions", "DeptId", c => c.Int());
            AlterColumn("dbo.Requisitions", "SubUnitId", c => c.Int());
            AlterColumn("dbo.Requisitions", "RequisitionDate", c => c.DateTime());
            AlterColumn("dbo.Requisitions", "RequiredBy", c => c.Int());
            AlterColumn("dbo.Requisitions", "VacancyTypeId", c => c.Int());
            AlterColumn("dbo.Requisitions", "StatusId", c => c.Int());
            CreateIndex("dbo.Requisitions", "RaisedBy");
            CreateIndex("dbo.Requisitions", "PositionId");
            CreateIndex("dbo.Requisitions", "DivisionId");
            CreateIndex("dbo.Requisitions", "DeptId");
            CreateIndex("dbo.Requisitions", "SubUnitId");
            CreateIndex("dbo.Requisitions", "RequiredBy");
            CreateIndex("dbo.Requisitions", "StatusId");
            AddForeignKey("dbo.Requisitions", "DeptId", "dbo.Depts", "Id");
            AddForeignKey("dbo.Requisitions", "PositionId", "dbo.Designations", "Id");
            AddForeignKey("dbo.Requisitions", "DivisionId", "dbo.Divisions", "Id");
            AddForeignKey("dbo.Requisitions", "RaisedBy", "dbo.Employees", "Id");
            AddForeignKey("dbo.Requisitions", "RequiredBy", "dbo.Employees", "Id");
            AddForeignKey("dbo.Requisitions", "StatusId", "dbo.Status", "Id");
            AddForeignKey("dbo.Requisitions", "SubUnitId", "dbo.SubUnits", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requisitions", "SubUnitId", "dbo.SubUnits");
            DropForeignKey("dbo.Requisitions", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Requisitions", "RequiredBy", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "RaisedBy", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Requisitions", "PositionId", "dbo.Designations");
            DropForeignKey("dbo.Requisitions", "DeptId", "dbo.Depts");
            DropIndex("dbo.Requisitions", new[] { "StatusId" });
            DropIndex("dbo.Requisitions", new[] { "RequiredBy" });
            DropIndex("dbo.Requisitions", new[] { "SubUnitId" });
            DropIndex("dbo.Requisitions", new[] { "DeptId" });
            DropIndex("dbo.Requisitions", new[] { "DivisionId" });
            DropIndex("dbo.Requisitions", new[] { "PositionId" });
            DropIndex("dbo.Requisitions", new[] { "RaisedBy" });
            AlterColumn("dbo.Requisitions", "StatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requisitions", "VacancyTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requisitions", "RequiredBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Requisitions", "RequisitionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Requisitions", "SubUnitId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requisitions", "DeptId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requisitions", "DivisionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requisitions", "PositionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requisitions", "RaisedBy", c => c.Int(nullable: false));
            CreateIndex("dbo.Requisitions", "StatusId");
            CreateIndex("dbo.Requisitions", "RequiredBy");
            CreateIndex("dbo.Requisitions", "SubUnitId");
            CreateIndex("dbo.Requisitions", "DeptId");
            CreateIndex("dbo.Requisitions", "DivisionId");
            CreateIndex("dbo.Requisitions", "PositionId");
            CreateIndex("dbo.Requisitions", "RaisedBy");
            AddForeignKey("dbo.Requisitions", "SubUnitId", "dbo.SubUnits", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requisitions", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requisitions", "RequiredBy", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requisitions", "RaisedBy", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requisitions", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requisitions", "PositionId", "dbo.Designations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requisitions", "DeptId", "dbo.Depts", "Id", cascadeDelete: true);
        }
    }
}
