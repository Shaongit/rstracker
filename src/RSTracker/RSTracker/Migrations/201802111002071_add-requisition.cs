namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequisition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requisitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefNo = c.String(),
                        RaisedBy = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        Division = c.Int(nullable: false),
                        Dept = c.Int(nullable: false),
                        SubUnit = c.Int(nullable: false),
                        RequisitionDate = c.DateTime(nullable: false),
                        RequiredBy = c.Int(nullable: false),
                        VacancyType = c.Int(nullable: false),
                        LastWorkingDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depts", t => t.Dept, cascadeDelete: false)
                .ForeignKey("dbo.Designations", t => t.Position, cascadeDelete: false)
                .ForeignKey("dbo.Divisions", t => t.Division, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.RequiredBy, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.RaisedBy, cascadeDelete: false)
                .ForeignKey("dbo.SubUnits", t => t.SubUnit, cascadeDelete: false)
                .Index(t => t.RaisedBy)
                .Index(t => t.Position)
                .Index(t => t.Division)
                .Index(t => t.Dept)
                .Index(t => t.SubUnit)
                .Index(t => t.RequiredBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requisitions", "SubUnit", "dbo.SubUnits");
            DropForeignKey("dbo.Requisitions", "RaisedBy", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "RequiredBy", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "Division", "dbo.Divisions");
            DropForeignKey("dbo.Requisitions", "Position", "dbo.Designations");
            DropForeignKey("dbo.Requisitions", "Dept", "dbo.Depts");
            DropIndex("dbo.Requisitions", new[] { "RequiredBy" });
            DropIndex("dbo.Requisitions", new[] { "SubUnit" });
            DropIndex("dbo.Requisitions", new[] { "Dept" });
            DropIndex("dbo.Requisitions", new[] { "Division" });
            DropIndex("dbo.Requisitions", new[] { "Position" });
            DropIndex("dbo.Requisitions", new[] { "RaisedBy" });
            DropTable("dbo.Requisitions");
        }
    }
}
