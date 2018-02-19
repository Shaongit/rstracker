namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifieddiv : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Divisions", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Divisions", "Name", c => c.String());
        }
    }
}