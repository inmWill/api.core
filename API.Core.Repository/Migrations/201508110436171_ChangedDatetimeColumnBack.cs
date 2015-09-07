namespace API.Core.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatetimeColumnBack : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Answers", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InputOptions", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InputOptions", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeSurveyAudits", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeSurveyAudits", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClientEmployees", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClientEmployees", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Audits", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Audits", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Surveys", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Surveys", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Questions", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Questions", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dialogs", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dialogs", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeDependents", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeDependents", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Plans", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Plans", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeEvents", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeEvents", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Templates", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Templates", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeQuestionnaires", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeQuestionnaires", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClientImportRecords", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClientImportRecords", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SkipLogicRules", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SkipLogicRules", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SurveyQuestionnaires", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SurveyQuestionnaires", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SurveyQuestionnaires", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SurveyQuestionnaires", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SkipLogicRules", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SkipLogicRules", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClientImportRecords", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClientImportRecords", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeQuestionnaires", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeQuestionnaires", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Templates", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Templates", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeEvents", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeEvents", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Plans", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Plans", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeDependents", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeDependents", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dialogs", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dialogs", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Questions", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Questions", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Surveys", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Surveys", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Audits", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Audits", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClientEmployees", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClientEmployees", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeSurveyAudits", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeSurveyAudits", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InputOptions", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InputOptions", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Answers", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Answers", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
