namespace ConSova.OCV.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        TextAnswer = c.String(),
                        BooleanAnswer = c.Boolean(),
                        DecimalAnswer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.AnswerId);
            
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        AuditType_Id = c.Int(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditTypes", t => t.AuditType_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.AuditType_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.AuditTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorizedClients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ApplicationType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        CompanyEmail = c.String(nullable: false, maxLength: 250),
                        Street = c.String(nullable: false, maxLength: 150),
                        Unit = c.String(maxLength: 150),
                        Region = c.String(nullable: false, maxLength: 150),
                        Postal = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 150),
                        LastSSN = c.String(nullable: false, maxLength: 4),
                        DateOfBirth = c.DateTime(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
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
                        ClientEmployee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEmployees", t => t.ClientEmployee_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.ClientEmployee_Id);
            
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.EmployeeDependents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        LastSSN = c.String(nullable: false, maxLength: 4),
                        DateOfBirth = c.DateTime(nullable: false),
                        Excluded = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        DependentType_Id = c.Int(),
                        Plan_Id = c.Int(),
                        ClientEmployee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DependentTypes", t => t.DependentType_Id)
                .ForeignKey("dbo.Plans", t => t.Plan_Id)
                .ForeignKey("dbo.ClientEmployees", t => t.ClientEmployee_Id)
                .Index(t => t.DependentType_Id)
                .Index(t => t.Plan_Id)
                .Index(t => t.ClientEmployee_Id);
            
            CreateTable(
                "dbo.DependentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ProviderName = c.String(),
                        Active = c.Boolean(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlanTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.PlanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 150),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Type_Id = c.Int(),
                        ClientEmployee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTypes", t => t.Type_Id)
                .ForeignKey("dbo.ClientEmployees", t => t.ClientEmployee_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.ClientEmployee_Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 250),
                        Contact = c.String(maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(maxLength: 50),
                        Website = c.String(maxLength: 150),
                        Active = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        SurveyId = c.Int(nullable: false, identity: true),
                        SurveyName = c.String(nullable: false, maxLength: 255),
                        Instructions = c.String(),
                        Type = c.Int(nullable: false),
                        OtherInfo = c.String(),
                        IsRequired = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SurveyId)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Dialogs",
                c => new
                    {
                        DialogId = c.Int(nullable: false, identity: true),
                        PromptingQuestionId = c.Int(nullable: false),
                        RespondingQuestionId = c.Int(nullable: false),
                        TriggerOnBool = c.Boolean(),
                        TriggerOnPhrase = c.String(),
                        TriggerOnDecimalLow = c.Decimal(precision: 18, scale: 2),
                        TriggerOnDecimalHigh = c.Decimal(precision: 18, scale: 2),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.DialogId);
            
            CreateTable(
                "dbo.MessageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        QuestionText = c.String(),
                        QuestionSubText = c.String(),
                        Type = c.Int(nullable: false),
                        Required = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.RefreshTokens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 50),
                        ClientId = c.String(nullable: false, maxLength: 50),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Surveys", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientEmployees", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Audits", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.EmployeeEvents", "ClientEmployee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.EmployeeEvents", "Type_Id", "dbo.EventTypes");
            DropForeignKey("dbo.EmployeeDependents", "ClientEmployee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.EmployeeDependents", "Plan_Id", "dbo.Plans");
            DropForeignKey("dbo.Plans", "Type_Id", "dbo.PlanTypes");
            DropForeignKey("dbo.EmployeeDependents", "DependentType_Id", "dbo.DependentTypes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ClientEmployee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Audits", "AuditType_Id", "dbo.AuditTypes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Surveys", new[] { "Client_Id" });
            DropIndex("dbo.EmployeeEvents", new[] { "ClientEmployee_Id" });
            DropIndex("dbo.EmployeeEvents", new[] { "Type_Id" });
            DropIndex("dbo.Plans", new[] { "Type_Id" });
            DropIndex("dbo.EmployeeDependents", new[] { "ClientEmployee_Id" });
            DropIndex("dbo.EmployeeDependents", new[] { "Plan_Id" });
            DropIndex("dbo.EmployeeDependents", new[] { "DependentType_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "ClientEmployee_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ClientEmployees", new[] { "Client_Id" });
            DropIndex("dbo.Audits", new[] { "Client_Id" });
            DropIndex("dbo.Audits", new[] { "AuditType_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RefreshTokens");
            DropTable("dbo.Questions");
            DropTable("dbo.MessageTypes");
            DropTable("dbo.Dialogs");
            DropTable("dbo.Surveys");
            DropTable("dbo.Clients");
            DropTable("dbo.EventTypes");
            DropTable("dbo.EmployeeEvents");
            DropTable("dbo.PlanTypes");
            DropTable("dbo.Plans");
            DropTable("dbo.DependentTypes");
            DropTable("dbo.EmployeeDependents");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ClientEmployees");
            DropTable("dbo.AuthorizedClients");
            DropTable("dbo.AuditTypes");
            DropTable("dbo.Audits");
            DropTable("dbo.Answers");
        }
    }
}
