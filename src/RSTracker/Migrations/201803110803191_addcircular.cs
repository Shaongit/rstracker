namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcircular : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Circulars", "CircularDate", c => c.DateTime());
            AlterColumn("dbo.Circulars", "WrittentestDate", c => c.DateTime());
            AlterColumn("dbo.Circulars", "VivaDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Circulars", "VivaDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Circulars", "WrittentestDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Circulars", "CircularDate", c => c.DateTime(nullable: false));
        }
    }
}
