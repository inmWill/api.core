namespace API.Core.Repository.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using API.Core.Domain.Enums;
    using API.Core.Repository.Models.Identity;
    using Utils.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<API.Core.Repository.DbContexts.APICoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(API.Core.Repository.DbContexts.APICoreContext context)
        {
            SeedUsers(context);
            SeedAuthorizedClients(context);
        }

        private void SeedUsers(API.Core.Repository.DbContexts.APICoreContext context)
        {
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            #region Default Roles

            const string adminRoleName = "Admin";
            // const string adminRoleDescription = "System Super Administrator";

            const string staffRoleName = "Staff";
            // const string clientAdminRoleDescription = "Client Specific Administrator";

            const string userRoleName = "User";
            // const string employeRoleDescription = "Client Specific Administrator";

            // Create Role Admin if it does not exist
            var adminRole = roleManager.FindByName(adminRoleName);
            if (adminRole == null)
            {
                adminRole = new IdentityRole(adminRoleName);
                var roleresult = roleManager.Create(adminRole);
            }

            var clientAdminRole = roleManager.FindByName(staffRoleName);
            if (clientAdminRole == null)
            {
                clientAdminRole = new IdentityRole(staffRoleName);
                var roleresult = roleManager.Create(clientAdminRole);
            }

            var clientEmployeeRole = roleManager.FindByName(userRoleName);
            if (clientEmployeeRole == null)
            {
                clientEmployeeRole = new IdentityRole(userRoleName);
                var roleresult = roleManager.Create(clientEmployeeRole);
            }

            #endregion


            #region Default User Accounts

            // Initial Admin user
            // Require password reset in production
            const string adminUsername = "Admin";
            const string adminPassword = "R%^YGVFT";

            var adminUser = userManager.FindByName(adminUsername);

            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    Email = "admin@api.com",
                    UserName = adminUsername,
                    Firstname = "Admin",
                    Lastname = "Account"
       
                };

                var result = userManager.Create(adminUser, adminPassword);
                result = userManager.SetLockoutEnabled(adminUser.Id, false);
            }

            const string staffUsername = "Staff";
            const string staffPassword = "w34rdxse";

            var staffUser = userManager.FindByName(staffUsername);
            if (staffUser == null)
            {
                staffUser = new AppUser
                {
                    Email = "staff@api.com",
                    UserName = staffUsername,
                    Firstname = "Staff",
                    Lastname = "Account"
                };

                var result = userManager.Create(staffUser, staffPassword);
            }

            const string username = "User";
            const string password = "q23esaw";

            var User = userManager.FindByName(username);
            if (User == null)
            {
                User = new AppUser
                {
                    Email = "user@api.com",
                    UserName = username,
                    Firstname = "User",
                    Lastname = "Account"
                };

                var result = userManager.Create(User, password);
            }

            #endregion


            var rolesForAdmin = userManager.GetRoles(adminUser.Id);
            if (!rolesForAdmin.Contains(adminRole.Name))
            {
                userManager.AddToRole(adminUser.Id, adminRole.Name);
            }

            var rolesForClientAdmin = userManager.GetRoles(staffUser.Id);
            if (!rolesForClientAdmin.Contains(clientAdminRole.Name))
            {
                userManager.AddToRole(staffUser.Id, clientAdminRole.Name);
            }

            var rolesForClientEmployee = userManager.GetRoles(User.Id);
            if (!rolesForClientEmployee.Contains(clientEmployeeRole.Name))
            {
                userManager.AddToRole(User.Id, clientEmployeeRole.Name);
            }

        }

        private void SeedAuthorizedClients(DbContexts.APICoreContext context)
        {
            context.AuthorizedClients.AddOrUpdate(
                  a => a.Id,
                new AuthorizedClient
                {
                    Id = "coreApp",
                    Name = "Core Angular UI",
                    Secret = HashHelper.GetHash("Q@#eszaw"),
                    Active = true,
                    AllowedOrigin = "http://localhost:10101/",
                    RefreshTokenLifeTime = 72000,
                    ApplicationType = ApplicationTypes.JavaScript
                }
                );

            context.AuthorizedClients.AddOrUpdate(
                  a => a.Id,
                new AuthorizedClient
                {
                    Id = "coreAzureApp",
                    Name = "Core Azure Angular UI",
                    Secret = HashHelper.GetHash("Q@#eszaw"),
                    Active = true,
                    AllowedOrigin = "http://coreui.azurewebsites.net/",
                    RefreshTokenLifeTime = 72000,
                    ApplicationType = ApplicationTypes.JavaScript
                }
                );
        }
    }
}
