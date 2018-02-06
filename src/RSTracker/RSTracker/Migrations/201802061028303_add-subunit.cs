namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubunit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depts", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubUnits", "DeptId", "dbo.Depts");
            DropIndex("dbo.SubUnits", new[] { "DeptId" });
            DropTable("dbo.SubUnits");
        }
    }
}
