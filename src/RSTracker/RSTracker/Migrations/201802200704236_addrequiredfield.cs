namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequiredfield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Depts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Designations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SubUnits", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Status", "Name", c => c.String());
            AlterColumn("dbo.SubUnits", "Name", c => c.String());
            AlterColumn("dbo.Designations", "Name", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Depts", "Name", c => c.String());
        }
    }
}
