using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Identity;
using API.Core.Repository.Models.Widgets;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Core.Repository.DbContexts
{
    public partial class APICoreContext : IdentityDbContext<AppUser>
    {

        //static APICoreContext()
        //{

            
        //}

        public APICoreContext() 
            : base("Name=APICoreContext")
        {
            Database.SetInitializer<APICoreContext>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
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
        
        public static APICoreContext Create()
        {
            return new APICoreContext();
        }

        // Authentication
        public DbSet<AuthorizedClient> AuthorizedClients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Widget> Widgets { get; set; }





        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types<IObjectWithState>().Configure(c => c.Ignore<State>(i => i.State));

            base.OnModelCreating(modelBuilder);

        }
    }
}
