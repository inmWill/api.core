namespace API.Core.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisclaimerText = c.String(),
                        LinkText = c.String(),
                        Style = c.String(),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        InputOptionType_Id = c.Int(),
                        Unit_Id = c.Int(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InputOptionTypes", t => t.InputOptionType_Id)
                .ForeignKey("dbo.UnitOfMeasures", t => t.Unit_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.InputOptionType_Id)
                .Index(t => t.Unit_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.InputOptionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitOfMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InputOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        value = c.String(),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Answer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.Answer_Id)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.EmployeeSurveyAudits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.Int(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Employee_Id = c.Int(),
                        Survey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEmployees", t => t.Employee_Id)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Survey_Id);
            
            CreateTable(
                "dbo.ClientEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        CompanyEmail = c.String(nullable: false, maxLength: 250),
                        PreferredEmail = c.String(maxLength: 250),
                        Street = c.String(nullable: false, maxLength: 150),
                        Unit = c.String(maxLength: 150),
                        City = c.String(nullable: false, maxLength: 150),
                        Region = c.String(nullable: false, maxLength: 150),
                        Postal = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 150),
                        LastSSN = c.String(nullable: false, maxLength: 4),
                        HipaaAuthorizationGiven = c.Boolean(nullable: false),
                        HomePhone = c.String(maxLength: 150),
                        WorkPhone = c.String(maxLength: 150),
                        CellPhone = c.String(maxLength: 150),
                        DateOfBirth = c.DateTime(nullable: false),
                        Client_Id = c.Int(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Question_Id = c.Int(),
                        EmployeeQuestionnaire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.EmployeeQuestionnaires", t => t.EmployeeQuestionnaire_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.EmployeeQuestionnaire_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Enabled = c.Boolean(nullable: false),
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
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Instructions = c.String(),
                        OtherInfo = c.String(),
                        Active = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Client_Id = c.Int(),
                        EmployeeQuestionnaire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.EmployeeQuestionnaires", t => t.EmployeeQuestionnaire_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.EmployeeQuestionnaire_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        QuestionText = c.String(nullable: false, maxLength: 500),
                        QuestionSubText = c.String(maxLength: 500),
                        IsRequired = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Dialog_Id = c.Int(),
                        Type_Id = c.Int(),
                        Survey_Id = c.Int(),
                        EmployeeQuestionnaire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dialogs", t => t.Dialog_Id)
                .ForeignKey("dbo.QuestionTypes", t => t.Type_Id)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id)
                .ForeignKey("dbo.EmployeeQuestionnaires", t => t.EmployeeQuestionnaire_Id)
                .Index(t => t.Dialog_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.Survey_Id)
                .Index(t => t.EmployeeQuestionnaire_Id);
            
            CreateTable(
                "dbo.Dialogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DialogText = c.String(nullable: false, maxLength: 500),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        SkipLogicRule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkipLogicRules", t => t.SkipLogicRule_Id)
                .Index(t => t.SkipLogicRule_Id);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeDependents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        LastSSN = c.String(nullable: false, maxLength: 4),
                        DateOfBirth = c.DateTime(nullable: false),
                        WorkPhone = c.String(),
                        HomePhone = c.String(),
                        CellPhone = c.String(),
                        Spouse = c.Boolean(nullable: false),
                        Excluded = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        ClientEmployee_Id = c.Int(),
                        DependentType_Id = c.Int(),
                        Plan_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEmployees", t => t.ClientEmployee_Id)
                .ForeignKey("dbo.DependentTypes", t => t.DependentType_Id)
                .ForeignKey("dbo.Plans", t => t.Plan_Id)
                .Index(t => t.ClientEmployee_Id)
                .Index(t => t.DependentType_Id)
                .Index(t => t.Plan_Id);
            
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
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Template_Id = c.Int(nullable: false),
                        ClientEmployee_Id = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Sent = c.Boolean(nullable: false),
                        Received = c.Boolean(nullable: false),
                        SentDate = c.DateTime(nullable: false),
                        ReceivedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEmployees", t => t.ClientEmployee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Templates", t => t.Template_Id, cascadeDelete: true)
                .Index(t => t.Template_Id)
                .Index(t => t.ClientEmployee_Id);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        HtmlBody = c.String(),
                        TextBody = c.String(),
                        State = c.Int(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeQuestionnaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Response = c.String(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        EmployeeSurveyAudit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeSurveyAudits", t => t.EmployeeSurveyAudit_Id)
                .Index(t => t.EmployeeSurveyAudit_Id);
            
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
                "dbo.ClientImportRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ClientEmployeeInternalId = c.String(nullable: false, maxLength: 150),
                        EmployeeSSN = c.String(nullable: false, maxLength: 9),
                        EmployeeEmail = c.String(nullable: false, maxLength: 250),
                        EmployeeLastName = c.String(nullable: false, maxLength: 150),
                        EmployeeMiddleName = c.String(maxLength: 150),
                        EmployeeFirstName = c.String(nullable: false, maxLength: 150),
                        EmployeeSuffix = c.String(maxLength: 50),
                        EmployeeDateOfBirth = c.DateTime(nullable: false),
                        EmployeeGender = c.String(maxLength: 25),
                        EmployeeStreetAddress1 = c.String(nullable: false, maxLength: 150),
                        EmployeeStreetAddress2 = c.String(nullable: false, maxLength: 150),
                        EmployeeCity = c.String(nullable: false, maxLength: 150),
                        EmployeeState = c.String(nullable: false, maxLength: 100),
                        EmployeeZipCode = c.String(nullable: false, maxLength: 25),
                        EmployeeHomePhone = c.String(maxLength: 25),
                        EmployeeWorkPhone = c.String(maxLength: 25),
                        DependentSSN = c.String(maxLength: 9),
                        DependentLastName = c.String(nullable: false, maxLength: 150),
                        DependentMiddleName = c.String(maxLength: 150),
                        DependentFirstName = c.String(nullable: false, maxLength: 150),
                        DependentSuffix = c.String(maxLength: 50),
                        DependentDateOfBirth = c.DateTime(nullable: false),
                        DependentGender = c.String(nullable: false, maxLength: 25),
                        RelationshipCode = c.String(nullable: false, maxLength: 25),
                        Vip = c.Boolean(nullable: false),
                        QMCSO = c.Boolean(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        Surcharge = c.Boolean(nullable: false),
                        MedicalPlan = c.String(nullable: false, maxLength: 150),
                        DentalPlan = c.String(nullable: false, maxLength: 150),
                        VisionPlan = c.String(nullable: false, maxLength: 150),
                        ExistingEmployee = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EmployeeSSN, unique: true);
            
            CreateTable(
                "dbo.MessageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperatorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.SkipLogicRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValidAnswer = c.String(),
                        NextQuestionId = c.Int(),
                        TriggerDialog = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        OperatorType_Id = c.Int(),
                        Question_Id = c.Int(),
                        Survey_Id = c.Int(),
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.NextQuestionId)
                .ForeignKey("dbo.OperatorTypes", t => t.OperatorType_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id)
                .ForeignKey("dbo.UnitOfMeasures", t => t.Unit_Id)
                .Index(t => t.NextQuestionId)
                .Index(t => t.OperatorType_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.Survey_Id)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.SurveyQuestionnaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsStartingQuestion = c.Boolean(nullable: false),
                        IsEndingQuestion = c.Boolean(nullable: false),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        Answer_Id = c.Int(),
                        Question_Id = c.Int(),
                        Survey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.Answer_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id)
                .Index(t => t.Answer_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.Survey_Id);
            
            CreateTable(
                "dbo.SurveyClientEmployees",
                c => new
                    {
                        Survey_Id = c.Int(nullable: false),
                        ClientEmployee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Survey_Id, t.ClientEmployee_Id })
                .ForeignKey("dbo.Surveys", t => t.Survey_Id, cascadeDelete: true)
                .ForeignKey("dbo.ClientEmployees", t => t.ClientEmployee_Id, cascadeDelete: true)
                .Index(t => t.Survey_Id)
                .Index(t => t.ClientEmployee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyQuestionnaires", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.SurveyQuestionnaires", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.SurveyQuestionnaires", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.SkipLogicRules", "Unit_Id", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.SkipLogicRules", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.SkipLogicRules", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.SkipLogicRules", "OperatorType_Id", "dbo.OperatorTypes");
            DropForeignKey("dbo.SkipLogicRules", "NextQuestionId", "dbo.Questions");
            DropForeignKey("dbo.Dialogs", "SkipLogicRule_Id", "dbo.SkipLogicRules");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EmployeeSurveyAudits", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.EmployeeQuestionnaires", "EmployeeSurveyAudit_Id", "dbo.EmployeeSurveyAudits");
            DropForeignKey("dbo.Surveys", "EmployeeQuestionnaire_Id", "dbo.EmployeeQuestionnaires");
            DropForeignKey("dbo.Questions", "EmployeeQuestionnaire_Id", "dbo.EmployeeQuestionnaires");
            DropForeignKey("dbo.ClientEmployees", "EmployeeQuestionnaire_Id", "dbo.EmployeeQuestionnaires");
            DropForeignKey("dbo.EmployeeSurveyAudits", "Employee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.Notifications", "Template_Id", "dbo.Templates");
            DropForeignKey("dbo.Notifications", "ClientEmployee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.EmployeeEvents", "ClientEmployee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.EmployeeEvents", "Type_Id", "dbo.EventTypes");
            DropForeignKey("dbo.EmployeeDependents", "Plan_Id", "dbo.Plans");
            DropForeignKey("dbo.Plans", "Type_Id", "dbo.PlanTypes");
            DropForeignKey("dbo.EmployeeDependents", "DependentType_Id", "dbo.DependentTypes");
            DropForeignKey("dbo.EmployeeDependents", "ClientEmployee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.Questions", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.Questions", "Type_Id", "dbo.QuestionTypes");
            DropForeignKey("dbo.ClientEmployees", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Dialog_Id", "dbo.Dialogs");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.SurveyClientEmployees", "ClientEmployee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.SurveyClientEmployees", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.Surveys", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientEmployees", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Audits", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Audits", "AuditType_Id", "dbo.AuditTypes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ClientEmployee_Id", "dbo.ClientEmployees");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InputOptions", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.Answers", "Unit_Id", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.Answers", "InputOptionType_Id", "dbo.InputOptionTypes");
            DropIndex("dbo.SurveyClientEmployees", new[] { "ClientEmployee_Id" });
            DropIndex("dbo.SurveyClientEmployees", new[] { "Survey_Id" });
            DropIndex("dbo.SurveyQuestionnaires", new[] { "Survey_Id" });
            DropIndex("dbo.SurveyQuestionnaires", new[] { "Question_Id" });
            DropIndex("dbo.SurveyQuestionnaires", new[] { "Answer_Id" });
            DropIndex("dbo.SkipLogicRules", new[] { "Unit_Id" });
            DropIndex("dbo.SkipLogicRules", new[] { "Survey_Id" });
            DropIndex("dbo.SkipLogicRules", new[] { "Question_Id" });
            DropIndex("dbo.SkipLogicRules", new[] { "OperatorType_Id" });
            DropIndex("dbo.SkipLogicRules", new[] { "NextQuestionId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ClientImportRecords", new[] { "EmployeeSSN" });
            DropIndex("dbo.EmployeeQuestionnaires", new[] { "EmployeeSurveyAudit_Id" });
            DropIndex("dbo.Notifications", new[] { "ClientEmployee_Id" });
            DropIndex("dbo.Notifications", new[] { "Template_Id" });
            DropIndex("dbo.EmployeeEvents", new[] { "ClientEmployee_Id" });
            DropIndex("dbo.EmployeeEvents", new[] { "Type_Id" });
            DropIndex("dbo.Plans", new[] { "Type_Id" });
            DropIndex("dbo.EmployeeDependents", new[] { "Plan_Id" });
            DropIndex("dbo.EmployeeDependents", new[] { "DependentType_Id" });
            DropIndex("dbo.EmployeeDependents", new[] { "ClientEmployee_Id" });
            DropIndex("dbo.Dialogs", new[] { "SkipLogicRule_Id" });
            DropIndex("dbo.Questions", new[] { "EmployeeQuestionnaire_Id" });
            DropIndex("dbo.Questions", new[] { "Survey_Id" });
            DropIndex("dbo.Questions", new[] { "Type_Id" });
            DropIndex("dbo.Questions", new[] { "Dialog_Id" });
            DropIndex("dbo.Surveys", new[] { "EmployeeQuestionnaire_Id" });
            DropIndex("dbo.Surveys", new[] { "Client_Id" });
            DropIndex("dbo.Audits", new[] { "Client_Id" });
            DropIndex("dbo.Audits", new[] { "AuditType_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "ClientEmployee_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ClientEmployees", new[] { "EmployeeQuestionnaire_Id" });
            DropIndex("dbo.ClientEmployees", new[] { "Question_Id" });
            DropIndex("dbo.ClientEmployees", new[] { "Client_Id" });
            DropIndex("dbo.EmployeeSurveyAudits", new[] { "Survey_Id" });
            DropIndex("dbo.EmployeeSurveyAudits", new[] { "Employee_Id" });
            DropIndex("dbo.InputOptions", new[] { "Answer_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Answers", new[] { "Unit_Id" });
            DropIndex("dbo.Answers", new[] { "InputOptionType_Id" });
            DropTable("dbo.SurveyClientEmployees");
            DropTable("dbo.SurveyQuestionnaires");
            DropTable("dbo.SkipLogicRules");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RefreshTokens");
            DropTable("dbo.OperatorTypes");
            DropTable("dbo.MessageTypes");
            DropTable("dbo.ClientImportRecords");
            DropTable("dbo.AuthorizedClients");
            DropTable("dbo.EmployeeQuestionnaires");
            DropTable("dbo.Templates");
            DropTable("dbo.Notifications");
            DropTable("dbo.EventTypes");
            DropTable("dbo.EmployeeEvents");
            DropTable("dbo.PlanTypes");
            DropTable("dbo.Plans");
            DropTable("dbo.DependentTypes");
            DropTable("dbo.EmployeeDependents");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Dialogs");
            DropTable("dbo.Questions");
            DropTable("dbo.Surveys");
            DropTable("dbo.AuditTypes");
            DropTable("dbo.Audits");
            DropTable("dbo.Clients");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ClientEmployees");
            DropTable("dbo.EmployeeSurveyAudits");
            DropTable("dbo.InputOptions");
            DropTable("dbo.UnitOfMeasures");
            DropTable("dbo.InputOptionTypes");
            DropTable("dbo.Answers");
        }
    }
}
