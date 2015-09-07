using System.Data.Entity.ModelConfiguration;
using API.Core.Repository.Models.Identity;

namespace API.Core.Repository.Models.Mapping
{
    public class AppUserMap : EntityTypeConfiguration<AppUser>
    {
        public AppUserMap()
        {
            HasRequired(cu => cu.ClientEmployee).WithOptional(ce => ce.AppUser);
            Ignore(cu => cu.UserRoles);
        }
    }
}
