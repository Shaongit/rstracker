namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifycircular : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Circulars", "CvSendtoLM", c => c.Int());
            AddColumn("dbo.Circulars", "SortedCvFromLM", c => c.Int());
            AddColumn("dbo.Circulars", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Circulars", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Circulars", "CreatedBy", c => c.String());
            AddColumn("dbo.Circulars", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Circulars", "NoOfCvFromAD", c => c.Int());
            AlterColumn("dbo.Circulars", "NoOfCvFromOnline", c => c.Int());
            AlterColumn("dbo.Circulars", "NoOfCvFromHardcopy", c => c.Int());
            AlterColumn("dbo.Circulars", "NoOfCvFromRef", c => c.Int());
            AlterColumn("dbo.Circulars", "FinalSelectedCandidate", c => c.Int());
            AlterColumn("dbo.Circulars", "WrittenTestPassedCandidate", c => c.Int());
            AlterColumn("dbo.Circulars", "VivaCandidate", c => c.Int());
            DropColumn("dbo.Circulars", "NoOfCvFrom");
            DropColumn("dbo.Circulars", "ShortLinedCvSendtoLm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Circulars", "ShortLinedCvSendtoLm", c => c.Int(nullable: false));
            AddColumn("dbo.Circulars", "NoOfCvFrom", c => c.Int(nullable: false));
            AlterColumn("dbo.Circulars", "VivaCandidate", c => c.Int(nullable: false));
            AlterColumn("dbo.Circulars", "WrittenTestPassedCandidate", c => c.Int(nullable: false));
            AlterColumn("dbo.Circulars", "FinalSelectedCandidate", c => c.Int(nullable: false));
            AlterColumn("dbo.Circulars", "NoOfCvFromRef", c => c.Int(nullable: false));
            AlterColumn("dbo.Circulars", "NoOfCvFromHardcopy", c => c.Int(nullable: false));
            AlterColumn("dbo.Circulars", "NoOfCvFromOnline", c => c.Int(nullable: false));
            AlterColumn("dbo.Circulars", "NoOfCvFromAD", c => c.Int(nullable: false));
            DropColumn("dbo.Circulars", "ModifiedBy");
            DropColumn("dbo.Circulars", "CreatedBy");
            DropColumn("dbo.Circulars", "ModifiedDate");
            DropColumn("dbo.Circulars", "CreateDate");
            DropColumn("dbo.Circulars", "SortedCvFromLM");
            DropColumn("dbo.Circulars", "CvSendtoLM");
        }
    }
}
