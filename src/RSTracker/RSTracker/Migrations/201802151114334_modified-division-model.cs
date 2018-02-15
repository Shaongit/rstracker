namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifieddivisionmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Divisions", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Divisions", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Divisions", "CreatedBy", c => c.String());
            AddColumn("dbo.Divisions", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Divisions", "ModifiedBy");
            DropColumn("dbo.Divisions", "CreatedBy");
            DropColumn("dbo.Divisions", "ModifiedDate");
            DropColumn("dbo.Divisions", "CreateDate");
        }
    }
}
