namespace RSTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig01 : DbMigration
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
                .ForeignKey("dbo.Depts", t => t.DeptId)
                .ForeignKey("dbo.Designations", t => t.PositionId)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .ForeignKey("dbo.Employees", t => t.RaisedBy)
                .ForeignKey("dbo.Employees", t => t.RequiredBy)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.SubUnits", t => t.SubUnitId)
                .Index(t => t.RaisedBy)
                .Index(t => t.PositionId)
                .Index(t => t.DivisionId)
                .Index(t => t.DeptId)
                .Index(t => t.SubUnitId)
                .Index(t => t.RequiredBy)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Depts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        Employees_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .Index(t => t.DivisionId)
                .Index(t => t.Employees_Id);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DesignationId = c.Int(),
                        DeptId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        SubUnitId = c.Int(nullable: false),
                        Division_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depts", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .ForeignKey("dbo.SubUnits", t => t.SubUnitId, cascadeDelete: true)
                .ForeignKey("dbo.Divisions", t => t.Division_Id)
                .Index(t => t.DesignationId)
                .Index(t => t.DeptId)
                .Index(t => t.DivisionId)
                .Index(t => t.SubUnitId)
                .Index(t => t.Division_Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.SubUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depts", t => t.DeptId)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
            DropForeignKey("dbo.Circulars", "RequisitionId", "dbo.Requisitions");
            DropForeignKey("dbo.Requisitions", "SubUnitId", "dbo.SubUnits");
            DropForeignKey("dbo.Requisitions", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Requisitions", "RequiredBy", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "RaisedBy", "dbo.Employees");
            DropForeignKey("dbo.Requisitions", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Requisitions", "PositionId", "dbo.Designations");
            DropForeignKey("dbo.Requisitions", "DeptId", "dbo.Depts");
            DropForeignKey("dbo.Depts", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Depts", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Employees", "Division_Id", "dbo.Divisions");
            DropForeignKey("dbo.Employees", "SubUnitId", "dbo.SubUnits");
            DropForeignKey("dbo.SubUnits", "DeptId", "dbo.Depts");
            DropForeignKey("dbo.Employees", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Designations", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Depts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SubUnits", new[] { "DeptId" });
            DropIndex("dbo.Designations", new[] { "DivisionId" });
            DropIndex("dbo.Employees", new[] { "Division_Id" });
            DropIndex("dbo.Employees", new[] { "SubUnitId" });
            DropIndex("dbo.Employees", new[] { "DivisionId" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Depts", new[] { "Employees_Id" });
            DropIndex("dbo.Depts", new[] { "DivisionId" });
            DropIndex("dbo.Requisitions", new[] { "StatusId" });
            DropIndex("dbo.Requisitions", new[] { "RequiredBy" });
            DropIndex("dbo.Requisitions", new[] { "SubUnitId" });
            DropIndex("dbo.Requisitions", new[] { "DeptId" });
            DropIndex("dbo.Requisitions", new[] { "DivisionId" });
            DropIndex("dbo.Requisitions", new[] { "PositionId" });
            DropIndex("dbo.Requisitions", new[] { "RaisedBy" });
            DropIndex("dbo.Circulars", new[] { "RequisitionId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Status");
            DropTable("dbo.SubUnits");
            DropTable("dbo.Designations");
            DropTable("dbo.Employees");
            DropTable("dbo.Divisions");
            DropTable("dbo.Depts");
            DropTable("dbo.Requisitions");
            DropTable("dbo.Circulars");
        }
    }
}
