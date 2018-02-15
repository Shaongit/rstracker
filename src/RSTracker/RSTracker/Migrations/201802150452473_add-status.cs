namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Requisitions", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requisitions", "Status");
            DropTable("dbo.Status");
        }
    }
}
