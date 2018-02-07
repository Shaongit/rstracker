namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Division_Id = c.Int(),
                        Dept_Id = c.Int(),
                        Designation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.Division_Id)
                .ForeignKey("dbo.Depts", t => t.Dept_Id)
                .ForeignKey("dbo.Designations", t => t.Designation_Id)
                .Index(t => t.Division_Id)
                .Index(t => t.Dept_Id)
                .Index(t => t.Designation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Designation_Id", "dbo.Designations");
            DropForeignKey("dbo.Employees", "Dept_Id", "dbo.Depts");
            DropForeignKey("dbo.Employees", "Division_Id", "dbo.Divisions");
            DropIndex("dbo.Employees", new[] { "Designation_Id" });
            DropIndex("dbo.Employees", new[] { "Dept_Id" });
            DropIndex("dbo.Employees", new[] { "Division_Id" });
            DropTable("dbo.Employees");
        }
    }
}
