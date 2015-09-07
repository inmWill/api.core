using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Client;
using API.Core.Repository.Models.Communications;
using API.Core.Repository.Models.Event;
using API.Core.Repository.Models.Identity;
using API.Core.Repository.Models.Import;
using API.Core.Repository.Models.Lookup;
using API.Core.Repository.Models.Mapping;
using API.Core.Repository.Models.Survey;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Core.Repository.DbContexts
{
    public partial class APICoreContext : IdentityDbContext<AppUser>
    {

        static APICoreContext()
        {
            Database.SetInitializer<APICoreContext>(null);
            
        }
        public APICoreContext()
            : base("Name=APICoreContext")

        {
            ((IObjectContextAdapter)this).ObjectContext
            .ObjectMaterialized += (sender, args) =>
            {
                var entity = args.Entity as IObjectWithState;
                if (entity != null)
                {
                    entity.State = State.Unchanged;
                }
            };
        }
        


        // Authentication
        public DbSet<AuthorizedClient> AuthorizedClients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        //Lookups
        public DbSet<AuditType> AuditTypes { get; set; }
        public DbSet<DependentType> DependentTypes { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<PlanType> PlanTypes { get; set; }
        public DbSet<InputOptionType> InputOptionTypes { get; set; }
        public DbSet<OperatorType> OperatorTypes { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        // Imported Data
        public DbSet<ClientImportRecord> ClientImportRecords { get; set; }

        // Clients
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientEmployee> ClientEmployees { get; set; }
        public DbSet<EmployeeDependent> EmployeeDependents { get; set; }


        // Audits
        public DbSet<Audit> Audits { get; set; }

        // Events
        public DbSet<EmployeeEvent> EmployeeEvents { get; set; }

        // Notifications
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Template> Templates { get; set; }

        // Surveys
        public DbSet<Answer> Answers { get; set; }    
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<EmployeeQuestionnaire> EmployeeQuestionnaire { get; set; }
        public DbSet<EmployeeSurveyAudit> Audit { get; set; }
        public DbSet<SkipLogicRule> Rules { get; set; }
        public DbSet<SurveyQuestionnaire> SurveyQuestions { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());

            modelBuilder.Types<IObjectWithState>().Configure(c => c.Ignore<State>(i => i.State));

            base.OnModelCreating(modelBuilder);

        }
    }
}
