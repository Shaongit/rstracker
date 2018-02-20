namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyrequisition : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Requisitions", name: "Position", newName: "PositionId");
            RenameColumn(table: "dbo.Requisitions", name: "Dept", newName: "DeptId");
            RenameColumn(table: "dbo.Requisitions", name: "Division", newName: "DivisionId");
            RenameColumn(table: "dbo.Requisitions", name: "Status", newName: "StatusId");
            RenameColumn(table: "dbo.Requisitions", name: "SubUnit", newName: "SubUnitId");
            RenameIndex(table: "dbo.Requisitions", name: "IX_Position", newName: "IX_PositionId");
            RenameIndex(table: "dbo.Requisitions", name: "IX_Division", newName: "IX_DivisionId");
            RenameIndex(table: "dbo.Requisitions", name: "IX_Dept", newName: "IX_DeptId");
            RenameIndex(table: "dbo.Requisitions", name: "IX_SubUnit", newName: "IX_SubUnitId");
            RenameIndex(table: "dbo.Requisitions", name: "IX_Status", newName: "IX_StatusId");
            AddColumn("dbo.Requisitions", "VacancyTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Requisitions", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requisitions", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requisitions", "CreatedBy", c => c.String());
            AddColumn("dbo.Requisitions", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Requisitions", "RefNo", c => c.String(nullable: false));
            DropColumn("dbo.Requisitions", "VacancyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requisitions", "VacancyType", c => c.Int(nullable: false));
            AlterColumn("dbo.Requisitions", "RefNo", c => c.String());
            DropColumn("dbo.Requisitions", "ModifiedBy");
            DropColumn("dbo.Requisitions", "CreatedBy");
            DropColumn("dbo.Requisitions", "ModifiedDate");
            DropColumn("dbo.Requisitions", "CreateDate");
            DropColumn("dbo.Requisitions", "VacancyTypeId");
            RenameIndex(table: "dbo.Requisitions", name: "IX_StatusId", newName: "IX_Status");
            RenameIndex(table: "dbo.Requisitions", name: "IX_SubUnitId", newName: "IX_SubUnit");
            RenameIndex(table: "dbo.Requisitions", name: "IX_DeptId", newName: "IX_Dept");
            RenameIndex(table: "dbo.Requisitions", name: "IX_DivisionId", newName: "IX_Division");
            RenameIndex(table: "dbo.Requisitions", name: "IX_PositionId", newName: "IX_Position");
            RenameColumn(table: "dbo.Requisitions", name: "SubUnitId", newName: "SubUnit");
            RenameColumn(table: "dbo.Requisitions", name: "StatusId", newName: "Status");
            RenameColumn(table: "dbo.Requisitions", name: "DivisionId", newName: "Division");
            RenameColumn(table: "dbo.Requisitions", name: "DeptId", newName: "Dept");
            RenameColumn(table: "dbo.Requisitions", name: "PositionId", newName: "Position");
        }
    }
}
