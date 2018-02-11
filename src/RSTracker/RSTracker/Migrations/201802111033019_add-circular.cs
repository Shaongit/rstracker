namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcircular : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Circulars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequisitionId = c.Int(nullable: false),
                        CircularDate = c.DateTime(nullable: false),
                        NoOfCvFrom = c.Int(nullable: false),
                        NoOfCvFromAD = c.Int(nullable: false),
                        NoOfCvFromOnline = c.Int(nullable: false),
                        NoOfCvFromHardcopy = c.Int(nullable: false),
                        NoOfCvFromRef = c.Int(nullable: false),
                        ShortLinedCvSendtoLm = c.Int(nullable: false),
                        FinalSelectedCandidate = c.Int(nullable: false),
                        WrittentestDate = c.DateTime(nullable: false),
                        WrittenTestPassedCandidate = c.Int(nullable: false),
                        VivaDate = c.DateTime(nullable: false),
                        VivaCandidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Requisitions", t => t.RequisitionId, cascadeDelete: true)
                .Index(t => t.RequisitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Circulars", "RequisitionId", "dbo.Requisitions");
            DropIndex("dbo.Circulars", new[] { "RequisitionId" });
            DropTable("dbo.Circulars");
        }
    }
}
