namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyCircular2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Circulars", "FinalVivaCandidate", c => c.Int());
            AddColumn("dbo.Circulars", "ReferenceCheck", c => c.String());
            AddColumn("dbo.Circulars", "FinalMeetingWithCEO", c => c.String());
            AddColumn("dbo.Circulars", "SelectedCandidateDetails", c => c.String());
            AddColumn("dbo.Circulars", "ALIssueDate", c => c.DateTime());
            AddColumn("dbo.Circulars", "DateOfJoining", c => c.DateTime());
            AddColumn("dbo.Circulars", "ProcessLength", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Circulars", "ProcessLength");
            DropColumn("dbo.Circulars", "DateOfJoining");
            DropColumn("dbo.Circulars", "ALIssueDate");
            DropColumn("dbo.Circulars", "SelectedCandidateDetails");
            DropColumn("dbo.Circulars", "FinalMeetingWithCEO");
            DropColumn("dbo.Circulars", "ReferenceCheck");
            DropColumn("dbo.Circulars", "FinalVivaCandidate");
        }
    }
}
