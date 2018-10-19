namespace HSTrackerData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Circular",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequisitionId = c.Int(nullable: false),
                        CircularDate = c.DateTime(),
                        NoOfCvFromAD = c.Int(),
                        NoOfCvFromOnline = c.Int(),
                        NoOfCvFromHardcopy = c.Int(),
                        NoOfCvFromRef = c.Int(),
                        CvSendtoLM = c.Int(),
                        SortedCvFromLM = c.Int(),
                        FinalSelectedCandidate = c.Int(),
                        WrittentestDate = c.DateTime(),
                        WrittenTestPassedCandidate = c.Int(),
                        VivaDate = c.DateTime(),
                        VivaCandidate = c.Int(),
                        FinalVivaCandidate = c.Int(),
                        ReferenceCheck = c.String(),
                        FinalMeetingWithCEO = c.String(),
                        SelectedCandidateDetails = c.String(),
                        ALIssueDate = c.DateTime(),
                        DateOfJoining = c.DateTime(),
                        ProcessLength = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requisitions", t => t.RequisitionId, cascadeDelete: true)
                .Index(t => t.RequisitionId);
            
            CreateTable(
                "dbo.Requisitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefNo = c.String(nullable: false),
                        RaisedBy = c.Int(),
                        PositionId = c.Int(),
                        DivisionId = c.Int(),
                        DeptId = c.Int(),
                        SubUnitId = c.Int(),
                        RequisitionDate = c.DateTime(),
                        RequiredBy = c.Int(),
                        VacancyTypeId = c.Int(),
                        LastWorkingDay = c.DateTime(nullable: false),
                        StatusId = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dept", t => t.DeptId)
                .ForeignKey("dbo.Designation", t => t.PositionId)
                .ForeignKey("dbo.Division", t => t.DivisionId)
                .ForeignKey("dbo.Employee", t => t.RaisedBy)
                .ForeignKey("dbo.Employee", t => t.RequiredBy)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.SubUnit", t => t.SubUnitId)
                .Index(t => t.RaisedBy)
                .Index(t => t.PositionId)
                .Index(t => t.DivisionId)
                .Index(t => t.DeptId)
                .Index(t => t.SubUnitId)
                .Index(t => t.RequiredBy)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Dept",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        DivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Division", t => t.DivisionId, cascadeDelete: true)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DesignationId = c.Int(),
                        DeptId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        SubUnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dept", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.Designation", t => t.DesignationId)
                .ForeignKey("dbo.Division", t => t.DivisionId, cascadeDelete: false)
                .ForeignKey("dbo.SubUnit", t => t.SubUnitId, cascadeDelete: true)
                .Index(t => t.DesignationId)
                .Index(t => t.DeptId)
                .Index(t => t.DivisionId)
                .Index(t => t.SubUnitId);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        DivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Division", t => t.DivisionId, cascadeDelete: true)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.SubUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dept", t => t.DeptId, cascadeDelete: false)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Circular", "RequisitionId", "dbo.Requisitions");
            DropForeignKey("dbo.Requisitions", "SubUnitId", "dbo.SubUnit");
            DropForeignKey("dbo.Requisitions", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Requisitions", "RequiredBy", "dbo.Employee");
            DropForeignKey("dbo.Requisitions", "RaisedBy", "dbo.Employee");
            DropForeignKey("dbo.Requisitions", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.Requisitions", "PositionId", "dbo.Designation");
            DropForeignKey("dbo.Requisitions", "DeptId", "dbo.Dept");
            DropForeignKey("dbo.Dept", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.Employee", "SubUnitId", "dbo.SubUnit");
            DropForeignKey("dbo.SubUnit", "DeptId", "dbo.Dept");
            DropForeignKey("dbo.Employee", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.Employee", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.Designation", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.Employee", "DeptId", "dbo.Dept");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SubUnit", new[] { "DeptId" });
            DropIndex("dbo.Designation", new[] { "DivisionId" });
            DropIndex("dbo.Employee", new[] { "SubUnitId" });
            DropIndex("dbo.Employee", new[] { "DivisionId" });
            DropIndex("dbo.Employee", new[] { "DeptId" });
            DropIndex("dbo.Employee", new[] { "DesignationId" });
            DropIndex("dbo.Dept", new[] { "DivisionId" });
            DropIndex("dbo.Requisitions", new[] { "StatusId" });
            DropIndex("dbo.Requisitions", new[] { "RequiredBy" });
            DropIndex("dbo.Requisitions", new[] { "SubUnitId" });
            DropIndex("dbo.Requisitions", new[] { "DeptId" });
            DropIndex("dbo.Requisitions", new[] { "DivisionId" });
            DropIndex("dbo.Requisitions", new[] { "PositionId" });
            DropIndex("dbo.Requisitions", new[] { "RaisedBy" });
            DropIndex("dbo.Circular", new[] { "RequisitionId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Status");
            DropTable("dbo.SubUnit");
            DropTable("dbo.Designation");
            DropTable("dbo.Employee");
            DropTable("dbo.Division");
            DropTable("dbo.Dept");
            DropTable("dbo.Requisitions");
            DropTable("dbo.Circular");
        }
    }
}
