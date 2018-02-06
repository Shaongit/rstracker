namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DesignationId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        SubUnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depts", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .ForeignKey("dbo.SubUnits", t => t.SubUnitId, cascadeDelete: true)
                .Index(t => t.DesignationId)
                .Index(t => t.DeptId)
                .Index(t => t.DivisionId)
                .Index(t => t.SubUnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SubUnitId", "dbo.SubUnits");
            DropForeignKey("dbo.Employees", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Depts");
            DropIndex("dbo.Employees", new[] { "SubUnitId" });
            DropIndex("dbo.Employees", new[] { "DivisionId" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropTable("dbo.Employees");
        }
    }
}
