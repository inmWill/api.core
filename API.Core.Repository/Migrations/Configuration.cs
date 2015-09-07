using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using API.Core.Domain.Enums;
using API.Core.Repository.DbContexts;
using API.Core.Repository.Helpers;
using API.Core.Repository.Models.Client;
using API.Core.Repository.Models.Identity;
using API.Core.Repository.Models.Import;
using API.Core.Repository.Models.Lookup;
using API.Core.Repository.Models.Survey;
using API.Core.Utils.Cryptography;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using InputOptionType = API.Core.Repository.Models.Lookup.InputOptionType;
using OperatorType = API.Core.Repository.Models.Lookup.OperatorType;
using QuestionType = API.Core.Repository.Models.Lookup.QuestionType;
using UnitOfMeasure = API.Core.Repository.Models.Lookup.UnitOfMeasure;

namespace API.Core.Repository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<APICoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(APICoreContext context)
        {

            SeedLookups(context);
            context.SaveChanges();
            SeedClients(context);
            context.SaveChanges();
            SeedUsers(context);
            context.SaveChanges();
            SeedImportRecords(context);
            context.SaveChanges();
         //   SeedSurvey(context);



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void SeedImportRecords(APICoreContext context)
        {
            context.ClientImportRecords.AddOrUpdate(
                r => r.EmployeeSSN,
                new ClientImportRecord
                {
                    ClientId = 1,
                    ClientEmployeeInternalId = "000001",
                    EmployeeSSN = "100001111",
                    EmployeeEmail = "johndoe@companyclient.com",
                    EmployeeLastName = "Doe",
                    EmployeeMiddleName = "J",
                    EmployeeFirstName = "John",
                    EmployeeSuffix = "",
                    EmployeeDateOfBirth = DateTime.Parse("1/1/1970"),
                    EmployeeGender = "M",
                    EmployeeStreetAddress1 = "Street Address 1",
                    EmployeeStreetAddress2 = "Street Address 2",
                    EmployeeCity = "Denver",
                    EmployeeState = "CO",
                    EmployeeZipCode = "80000",
                    EmployeeHomePhone = "1234567890",
                    EmployeeWorkPhone = "0987654321",
                    DependentSSN = "100000001",
                    DependentLastName = "Doe",
                    DependentMiddleName = "D",
                    DependentFirstName = "Jane",
                    DependentSuffix = "",
                    DependentDateOfBirth = DateTime.Parse("1/1/1970"),
                    DependentGender = "F",
                    RelationshipCode = "SP",
                    Vip = false,
                    QMCSO = false,
                    Disabled = false,
                    Surcharge = false,
                    MedicalPlan = "Y",
                    DentalPlan = "Y",
                    VisionPlan = "Y",
                    ExistingEmployee = false,
                    CreatedOn = DateTime.Now,
                    IpAddress = "192.0.0.1",
                    ModifiedById = 1,
                    ModifiedOn = DateTime.Now
                },
                new ClientImportRecord
                {
                    ClientId = 1,
                    ClientEmployeeInternalId = "000002",
                    EmployeeSSN = "200002222",
                    EmployeeEmail = "johnsmith@companyclient.com",
                    EmployeeLastName = "Smith",
                    EmployeeMiddleName = "J",
                    EmployeeFirstName = "John",
                    EmployeeSuffix = "",
                    EmployeeDateOfBirth = DateTime.Parse("1/1/1970"),
                    EmployeeGender = "M",
                    EmployeeStreetAddress1 = "Street Address 1",
                    EmployeeStreetAddress2 = "Street Address 2",
                    EmployeeCity = "Denver",
                    EmployeeState = "CO",
                    EmployeeZipCode = "80000",
                    EmployeeHomePhone = "1234567890",
                    EmployeeWorkPhone = "0987654321",
                    DependentSSN = "200000001",
                    DependentLastName = "Smith",
                    DependentMiddleName = "D",
                    DependentFirstName = "Jane",
                    DependentSuffix = "",
                    DependentDateOfBirth = DateTime.Parse("1/1/1970"),
                    DependentGender = "F",
                    RelationshipCode = "SP",
                    Vip = false,
                    QMCSO = false,
                    Disabled = false,
                    Surcharge = false,
                    MedicalPlan = "Y",
                    DentalPlan = "Y",
                    VisionPlan = "Y",
                    ExistingEmployee = false,
                    CreatedOn = DateTime.Now,
                    IpAddress = "192.0.0.1",
                    ModifiedById = 1,
                    ModifiedOn = DateTime.Now
                },
                new ClientImportRecord
                {
                    ClientId = 1,
                    ClientEmployeeInternalId = "000003",
                    EmployeeSSN = "300003333",
                    EmployeeEmail = "johnjohn@companyclient.com",
                    EmployeeLastName = "John",
                    EmployeeMiddleName = "J",
                    EmployeeFirstName = "John",
                    EmployeeSuffix = "",
                    EmployeeDateOfBirth = DateTime.Parse("1/1/1970"),
                    EmployeeGender = "M",
                    EmployeeStreetAddress1 = "Street Address 1",
                    EmployeeStreetAddress2 = "Street Address 2",
                    EmployeeCity = "Denver",
                    EmployeeState = "CO",
                    EmployeeZipCode = "80000",
                    EmployeeHomePhone = "1234567890",
                    EmployeeWorkPhone = "0987654321",
                    DependentSSN = "300000001",
                    DependentLastName = "John",
                    DependentMiddleName = "D",
                    DependentFirstName = "Jane",
                    DependentSuffix = "",
                    DependentDateOfBirth = DateTime.Parse("1/1/1970"),
                    DependentGender = "F",
                    RelationshipCode = "SP",
                    Vip = false,
                    QMCSO = false,
                    Disabled = false,
                    Surcharge = false,
                    MedicalPlan = "Y",
                    DentalPlan = "Y",
                    VisionPlan = "Y",
                    ExistingEmployee = false,
                    CreatedOn = DateTime.Now,
                    IpAddress = "192.0.0.1",
                    ModifiedById = 1,
                    ModifiedOn = DateTime.Now
                }
                );
        }

        private ClientEmployee generateStaticClientEmployeeUser(string firstName, string lastName, string email, APICoreContext context)
        {
            var employee = new ClientEmployee
            {
                LastName = lastName,
                FirstName = firstName,
                CompanyEmail = email,
                Street = "Street",
                Unit = "Unit",
                City = "Denver",
                Region = "CO",
                Postal = "80000",
                Country = "USA",
                CreatedOn = DateTime.Now,
                IpAddress = "192.0.0.1",
                DateOfBirth = DateTime.Parse("1/1/1900"),
                LastSSN = "1234",
                ModifiedOn = DateTime.Now,
                ModifiedById = 0,
                Client = context.Clients.FirstOrDefault(t=>t.Id.Equals(1)),
                Dependents = new List<EmployeeDependent>
                    {
                        new EmployeeDependent
                        {
                            CreatedOn = DateTime.Now,
                            DateOfBirth = DateTime.Parse("1/1/1990"),
                            Excluded = false,
                            FirstName = "Child",
                            LastName = lastName,
                            IpAddress = "192.0.0.1",
                            LastSSN = "1111",
                            DependentType = context.DependentTypes.FirstOrDefault(t=>t.Id.Equals(3)),
                            ModifiedById = 0,
                            ModifiedOn = DateTime.Now,
                            Spouse = false                          
                        },
                        new EmployeeDependent
                        {
                            CreatedOn = DateTime.Now,
                            DateOfBirth = DateTime.Parse("1/1/1980"),
                            Excluded = false,
                            FirstName = "Spouse",
                            LastName = lastName,
                            IpAddress = "192.0.0.1",
                            DependentType = context.DependentTypes.FirstOrDefault(t=>t.Id.Equals(1)),
                            LastSSN = "2222",
                            ModifiedById = 0,
                            ModifiedOn = DateTime.Now,
                            Spouse = true
                        }
                    }
            };
            return employee;
        }

        private void SeedUsers(APICoreContext context)
        {
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            #region Default Roles

            const string adminRoleName = "Admin";
            // const string adminRoleDescription = "System Super Administrator";

            const string clientAdminRoleName = "ClientAdmin";
            // const string clientAdminRoleDescription = "Client Specific Administrator";

            const string employeeRoleName = "ClientEmployee";
            // const string employeRoleDescription = "Client Specific Administrator";

            // Create Role Admin if it does not exist
            var adminRole = roleManager.FindByName(adminRoleName);
            if (adminRole == null)
            {
                adminRole = new IdentityRole(adminRoleName);
                var roleresult = roleManager.Create(adminRole);
            }

            var clientAdminRole = roleManager.FindByName(clientAdminRoleName);
            if (clientAdminRole == null)
            {
                clientAdminRole = new IdentityRole(clientAdminRoleName);
                var roleresult = roleManager.Create(clientAdminRole);
            }

            var clientEmployeeRole = roleManager.FindByName(employeeRoleName);
            if (clientEmployeeRole == null)
            {
                clientEmployeeRole = new IdentityRole(employeeRoleName);
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
                    Email = "admin@company.com",
                    UserName = adminUsername,
                    Enabled = true,
                    ClientEmployee = generateStaticClientEmployeeUser("Admin", "AdminAccount", "admin@company.com", context)
                };

                var result = userManager.Create(adminUser, adminPassword);
                result = userManager.SetLockoutEnabled(adminUser.Id, false);
            }

            const string clientAdminUsername = "DemoClientAdmin";
            const string clientAdminPassword = "w34rdxse";

            var clientAdminUser = userManager.FindByName(clientAdminUsername);
            if (clientAdminUser == null)
            {
                clientAdminUser = new AppUser
                {
                    Email = "ClientStaff@democompany.com",
                    UserName = clientAdminUsername,
                    Enabled = true,
                    ClientEmployee = generateStaticClientEmployeeUser("ClientStaff", "StaffAccount", "ClientStaff@democompany.com", context)
                };

                var result = userManager.Create(clientAdminUser, clientAdminPassword);
            }

            const string clientEmployeeUsername = "DemoEmployee";
            const string clientEmployeePassword = "q23esaw";

            var clientEmployeeUser = userManager.FindByName(clientEmployeeUsername);
            if (clientEmployeeUser == null)
            {
                clientEmployeeUser = new AppUser
                {
                    Email = "michaelsmith@democompany.com",
                    UserName = clientEmployeeUsername,
                    Enabled = true,
                    ClientEmployee = generateStaticClientEmployeeUser("ClientStaff", "StaffAccount", "michaelsmith@democompany.com", context)
                };

                var result = userManager.Create(clientEmployeeUser, clientEmployeePassword);
            }

            #endregion


            var rolesForAdmin = userManager.GetRoles(adminUser.Id);
            if (!rolesForAdmin.Contains(adminRole.Name))
            {
                userManager.AddToRole(adminUser.Id, adminRole.Name);
            }

            var rolesForClientAdmin = userManager.GetRoles(clientAdminUser.Id);
            if (!rolesForClientAdmin.Contains(clientAdminRole.Name))
            {
                userManager.AddToRole(clientAdminUser.Id, clientAdminRole.Name);
            }

            var rolesForClientEmployee = userManager.GetRoles(clientEmployeeUser.Id);
            if (!rolesForClientEmployee.Contains(clientEmployeeRole.Name))
            {
                userManager.AddToRole(clientEmployeeUser.Id, clientEmployeeRole.Name);
            }

        }

        private void SeedLookups(APICoreContext context)
        {
            context.AuditTypes.AddOrUpdate(
              p => p.Description,
              new AuditType { Description = "Full Audit" },
              new AuditType { Description = "WSS Only" },
              new AuditType { Description = "Eligibility Only" }
            );

            context.DependentTypes.AddOrUpdate(
                d => d.Description,
                new DependentType { Description = "Spouse" },
                new DependentType { Description = "Domestic Partner" },
                new DependentType { Description = "Child" }
            );

            context.EventTypes.AddOrUpdate(
                e => e.Description,
                new EventType { Description = "Account" },
                new EventType { Description = "Audit" },
                new EventType { Description = "Separation" },
                new EventType { Description = "Eligibility" }
            );

            context.MessageTypes.AddOrUpdate(
                m => m.Description,
                new MessageType { Description = "Screen" },
                new MessageType { Description = "Email" },
                new MessageType { Description = "Voice" },
                new MessageType { Description = "SMS" }
            );

            context.PlanTypes.AddOrUpdate(
                m => m.Description,
                new PlanType { Description = "Medical" },
                new PlanType { Description = "Dental" },
                new PlanType { Description = "Vision" },
                new PlanType { Description = "ADD" }
            );


            context.InputOptionTypes.AddOrUpdate(
                new InputOptionType { Id = 1, Description = "Text" },
                new InputOptionType { Id = 2, Description = "Radio" },
                new InputOptionType { Id = 3, Description = "MultiLine" }
                );


            context.OperatorTypes.AddOrUpdate(
                new OperatorType { Id = 1, Description = "EqualsTo" },
                new OperatorType { Id = 2, Description = "NotEqualsTo" },
                new OperatorType { Id = 3, Description = "GreaterThan" },
                new OperatorType { Id = 4, Description = "LessThan" },
                new OperatorType { Id = 5, Description = "GreaterThanEqualsTo" },
                new OperatorType { Id = 6, Description = "LessThanEqualsTo" },
                new OperatorType { Id = 7, Description = "NoOperator" }
                );


            context.QuestionTypes.AddOrUpdate(
                 new QuestionType { Id = 1, Description = "Conditional" },
                 new QuestionType { Id = 2, Description = "Informational" }
                );


            context.UnitOfMeasures.AddOrUpdate(
                 new UnitOfMeasure { Id = 1, Description = "Date" },
                 new UnitOfMeasure { Id = 2, Description = "Currency" },
                 new UnitOfMeasure { Id = 3, Description = "Text" },
                 new UnitOfMeasure { Id = 4, Description = "Boolean" }
                );

        }

        private static List<ClientEmployee> GenerateEmployees(string company, int amount, APICoreContext context)
        {
            var employees = new List<ClientEmployee>();
            DateTime parentDOB = new DateTime(1940, 1, 1);
            DateTime childDOB = new DateTime(1980, 1, 1);

            Random random = new Random();

            int parentRange = (DateTime.Today - parentDOB).Days - 20;
            int childRange = (DateTime.Today - childDOB).Days;

            #region Seed Names

            var seedFirstNames = new List<string>
            {
                "Michelle",
                "Kristie",
                "Lenora",
                "Antione",
                "Millard",
                "Marianela",
                "Penni",
                "Anitra",
                "Elda",
                "Nona",
                "Vivan",
                "Yuette",
                "Alyssa",
                "Gaynell",
                "Willene",
                "Arminda",
                "Alta",
                "Ava",
                "Patrica",
                "Hana",
                "Hae",
                "Chrissy",
                "Kristi",
                "Linette",
                "Liane",
                "Chieko",
                "Kiersten",
                "Fausto",
                "Elanor",
                "Lasonya",
                "Noelle",
                "Maragret",
                "Diamond",
                "Claris",
                "Ezekiel",
                "Charlena",
                "Celsa",
                "Rachelle",
                "Ardella",
                "Ardith",
                "Adelina",
                "Emile",
                "Apryl",
                "Penney",
                "Jaimee",
                "Bell",
                "Elvera",
                "Eli",
                "Leah",
                "Malvina"
            };

            var seedLastNames = new List<string>
            {
                "Barber",
                "Pop",
                "Mann",
                "Soliz",
                "Banvelos",
                "Eisenmann",
                "Bright",
                "Elsea",
                "Olive",
                "Mani",
                "Burgett",
                "Walz",
                "Pew",
                "Tyus",
                "Bough",
                "Geier",
                "Venable",
                "Valez",
                "Wissing",
                "Lenart",
                "Papageorge",
                "Coonrod",
                "Barbagallo",
                "Acton",
                "Saban",
                "Tenenbaum",
                "Moeller",
                "Anker",
                "Fodor",
                "Liebsch",
                "Schnell",
                "Luciani",
                "Colclough",
                "Gammage",
                "Hurley",
                "Zuccaro",
                "Regal",
                "Altschuler",
                "Badeaux",
                "Moak",
                "Accetta",
                "Ebbert",
                "Broadwell",
                "Preciado",
                "Bremer",
                "Hastie",
                "Clemans",
                "Bordner",
                "Barcus",
                "Hendershot"
            };

            var seedStreetNames = new List<string>
            {
                "Amber",
                "Acorn",
                "Acres",
                "Auburn",
                "Anchor",
                "Alcove",
                "Bent",
                "Apple",
                "Arbor",
                "Big",
                "Autumn",
                "Avenue",
                "Birch",
                "Axe",
                "Bank",
                "Blue",
                "Barn",
                "Bayou",
                "Bright",
                "Beacon",
                "Bend",
                "Broad",
                "Bear",
                "Bluff",
                "Burning",
                "Beaver",
                "Byway",
                "Calm",
                "Berry",
                "Canyon",
                "Cinder",
                "Bird",
                "Chase",
                "Clear",
                "Blossom",
                "Circle",
                "Cold",
                "Bluff",
                "Corner",
                "Colonial",
                "Branch",
                "Court",
                "Cool",
                "Bridge",
                "Cove",
                "Cotton",
                "Brook",
                "Crest",
                "Cozy",
                "Butterfly",
                "Cut",
                "Crimson",
                "Butternut",
                "Dale",
                "Crystal",
                "Castle",
                "Dell",
                "Dewy",
                "Chestnut",
                "Drive",
                "Dusty",
                "Cider",
                "Edge",
                "Easy",
                "Cloud",
                "Estates",
                "Emerald"
            };

            #endregion

            var firstNameGenerator = new MarkovNameGenerator(seedFirstNames, 1, 3);
            var lastNameGenerator = new MarkovNameGenerator(seedLastNames, 1, 5);
            var streetNameGenerator = new MarkovNameGenerator(seedStreetNames, 1, 5);

            string companyEmail = "@" + company + ".com";

            for (int i = 0; i <= amount; i++)
            {
                var firstName = firstNameGenerator.NextName;
                var lastName = lastNameGenerator.NextName;
                var street = random.Next(1, 20000) + " " + streetNameGenerator.NextName + " Street.";
                var dependentFirstName = new List<string>();

                for (int j = 0; j <= 4; j++)
                {
                    dependentFirstName.Add(firstNameGenerator.NextName);
                }

                var employee = new ClientEmployee
                {
                    LastName = lastName,
                    FirstName = firstName,
                    CompanyEmail = "testemployee" + i + companyEmail,
                    Street = street,
                    City = "Denver",
                    Region = "CO",
                    Postal = "80000",
                    Country = "USA",
                    CreatedOn = DateTime.Now,
                    IpAddress = "192.0.0.1",
                    DateOfBirth = parentDOB.AddDays(random.Next(parentRange)),
                    LastSSN = random.Next(1000, 9999).ToString(),
                    ModifiedOn = DateTime.Now,
                    ModifiedById = 0,
                    Dependents = new List<EmployeeDependent>
                    {
                        new EmployeeDependent
                        {
                            CreatedOn = DateTime.Now,
                            DateOfBirth = childDOB.AddDays(random.Next(childRange)),
                            Excluded = false,
                            FirstName = dependentFirstName[0],
                            LastName = lastName,
                            IpAddress = "192.0.0.1",
                            LastSSN = random.Next(1000, 9999).ToString(),
                            DependentType = context.DependentTypes.FirstOrDefault(t=>t.Id.Equals(3)),
                            ModifiedById = 0,
                            ModifiedOn = DateTime.Now,
                            Spouse = false
                        },
                        new EmployeeDependent
                        {
                            CreatedOn = DateTime.Now,
                            DateOfBirth = childDOB.AddDays(random.Next(childRange)),
                            Excluded = false,
                            FirstName =  dependentFirstName[1],
                            LastName = lastName,
                            IpAddress = "192.0.0.1",
                            LastSSN = random.Next(1000, 9999).ToString(),
                            DependentType = context.DependentTypes.FirstOrDefault(t=>t.Id.Equals(3)),
                            ModifiedById = 0,
                            ModifiedOn = DateTime.Now,
                            Spouse = false
                        },
                        new EmployeeDependent
                        {
                            CreatedOn = DateTime.Now,
                            DateOfBirth = childDOB.AddDays(random.Next(childRange)),
                            Excluded = false,
                            FirstName = dependentFirstName[2],
                            LastName = lastName,
                            IpAddress = "192.0.0.1",
                            LastSSN = random.Next(1000, 9999).ToString(),
                            DependentType = context.DependentTypes.FirstOrDefault(t=>t.Id.Equals(3)),
                            ModifiedById = 0,
                            ModifiedOn = DateTime.Now,
                            Spouse = false
                        },
                        new EmployeeDependent
                        {
                            CreatedOn = DateTime.Now,
                            DateOfBirth = parentDOB.AddDays(random.Next(parentRange)),
                            Excluded = false,
                            FirstName = dependentFirstName[3],
                            LastName = lastName,
                            IpAddress = "192.0.0.1",
                            DependentType = context.DependentTypes.FirstOrDefault(t=>t.Id.Equals(1)),
                            LastSSN = random.Next(1000, 9999).ToString(),
                            ModifiedById = 0,
                            ModifiedOn = DateTime.Now,
                            Spouse = true
                        }
                    }

                };

                employees.Add(employee);
            }
            return employees;
        }


        private static void SeedClients(APICoreContext context)
        {
            context.AuthorizedClients.AddOrUpdate(
                  a => a.Id,
                new AuthorizedClient
                {
                    Id = "coreApp",
                    Name = "Core Angular UI",
                    Secret = HashHelper.GetHash("Q@#eszaw"),
                    Active = true,
                    AllowedOrigin = "http://localhost:55792",
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
                    AllowedOrigin = "http://sandcastle01:8882/",
                    RefreshTokenLifeTime = 72000,
                    ApplicationType = ApplicationTypes.JavaScript
                }
                );

            context.Clients.AddOrUpdate(
                c => c.Email,
                new Client
                {
                    Name = "Bertelsmann",
                    Description = "Media worldwide",
                    Contact = "HR Rep",
                    Email = "hr@bertelsmann.com",
                    Phone = "(123) 456-789",
                    Website = "bertelsmann.com",
                    Active = true,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IpAddress = "192.168.0.1",
                    Employees = GenerateEmployees("BertelsmannTest", 500, context),
                    ModifiedById = 1
                    
                },
                new Client
                {
                    Name = "Ericsson",
                    Description = "Ericsson Southwest",
                    Contact = "HR Rep",
                    Email = "hr@ericsson.com",
                    Phone = "(321) 456-789",
                    Website = "ericsson.com",
                    Active = true,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IpAddress = "192.168.0.1",
                    Employees = GenerateEmployees("EricssonTest", 250, context),
                    ModifiedById = 1
                },
                new Client
                {
                    Name = "Pepsi",
                    Description = "Pepsi Global",
                    Contact = "HR Rep",
                    Email = "hr@pepsi.com",
                    Phone = "(231) 456-789",
                    Website = "pepsi.com",
                    Active = true,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IpAddress = "192.168.0.1",
                    Employees = GenerateEmployees("PepsiTest", 250, context),
                    ModifiedById = 1
                },
                new Client
                {
                    Name = "Swedish Health Services",
                    Description = "Swedish Health Services Corporate",
                    Contact = "HR Rep",
                    Email = "hr@swedishhealthservices.com",
                    Phone = "(231) 456-789",
                    Website = "swedishhealthservices.com",
                    Active = false,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IpAddress = "192.168.0.1",
                    Employees = GenerateEmployees("SwedishHealthServicesTest", 2000, context),
                    ModifiedById = 1
                }
                );
        }

        private void SeedSurvey(APICoreContext context)
        {

            context.Surveys.AddOrUpdate(
                new Survey
                {
                    Id = 4,
                    Title = "Demo Survey",
                    StartDate = Convert.ToDateTime("05/01/2015"),
                    EndDate = Convert.ToDateTime("07/01/2015"),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    Client = context.Clients.Where(c => c.Name == "Bertelsmann").FirstOrDefault(),
                    Active = true
                }
               );

            context.SaveChanges();

            context.Dialogs.AddOrUpdate(
                new Dialog
                {
                    Id = 2,
                    DialogText = "Did your spouse file 1040 or 1099 for last tax season",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }
                );

            context.Questions.AddOrUpdate(
                      new Question
                      {
                          Id = 1,
                          QuestionText = "Is your spouse self employed?",
                          Type = context.QuestionTypes.Where(q => q.Description == "Conditional").FirstOrDefault(),
                          Title = "Self Employed",
                          Dialog = context.Dialogs.Where(p => p.DialogText == "Did your spouse file 1040 or 1099 for last tax season").FirstOrDefault(),
                          CreatedOn = DateTime.Now,
                          ModifiedOn = DateTime.Now
                      },

                      //new Question
                //{
                //    Id = 2,
                //    QuestionText = "Is your spouse employed by Demo company?",
                //    Type = Enums.QuestionType.Conditional,
                //    Title = "Spouse Employed Current Company",
                //    Dialog = new Dialog { DialogText = "Help text about spouse employed" }
                //},

                      new Question
                      {
                          Id = 2,
                          QuestionText = "Spouse Employer Name",
                          Type = context.QuestionTypes.Where(q => q.Description == "Informational").FirstOrDefault(),
                          Title = "Spouse Employer",
                          //Dialog = new Dialog { DialogText = "Help text about spouse employed" }
                          CreatedOn = DateTime.Now,
                          ModifiedOn = DateTime.Now

                      },

                      new Question
                      {
                          Id = 3,
                          QuestionText = "Signature capture question",
                          Type = context.QuestionTypes.Where(q => q.Description == "Informational").FirstOrDefault(),
                          Title = "Electronic Signature",
                          //Dialog = new Dialog { DialogText = "Help text about spouse employed" }
                          CreatedOn = DateTime.Now,
                          ModifiedOn = DateTime.Now

                      }

               );

            context.SaveChanges();

            var inputOptions = new List<InputOption>();

            inputOptions.Add(new InputOption
            {
                value = "Yes",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            });

            inputOptions.Add(new InputOption
            {
                value = "No",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            });


            context.Answers.AddOrUpdate(
                new Answer
                {
                    Id = 1,
                    InputOptionType = context.InputOptionTypes.Where(p => p.Description == "Text").FirstOrDefault(),
                    Unit = context.UnitOfMeasures.Where(p => p.Description == "Text").FirstOrDefault(),
                    Values = inputOptions,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    LinkText = "http://www.company.com/",
                    Style = "blockButton-info"

                },

                new Answer
                {
                    Id = 2,
                    InputOptionType = context.InputOptionTypes.Where(p => p.Description == "Text").FirstOrDefault(),
                    Unit = context.UnitOfMeasures.Where(p => p.Description == "Text").FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    Style = "blockButton-info"

                },

                new Answer
                {
                    Id = 3,
                    InputOptionType = context.InputOptionTypes.Where(p => p.Description == "Text").FirstOrDefault(),
                    Unit = context.UnitOfMeasures.Where(p => p.Description == "Currency").FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    Style = "blockButton-info"

                },

                new Answer
                {
                    Id = 4,
                    InputOptionType = context.InputOptionTypes.Where(p => p.Description == "Text").FirstOrDefault(),
                    Unit = context.UnitOfMeasures.Where(p => p.Description == "Date").FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    Style = "blockButton-info"
                }
               );

            context.SaveChanges();


            context.SurveyQuestions.AddOrUpdate(
                new SurveyQuestionnaire
                {
                    Id = 1,
                    IsStartingQuestion = true,
                    IsEndingQuestion = false,
                    Question = context.Questions.Where(p => p.Title.Equals("Self Employed")).FirstOrDefault(),
                    Survey = context.Surveys.Where(p => p.Title.Equals("Demo Survey")).FirstOrDefault(),
                    Answer = context.Answers.Where(p => p.Id == 1).FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now

                },

                //new SurveyQuestionnaire
                //{
                //    IsStartingQuestion = false,
                //    IsEndingQuestion = false,
                //    Question = context.Questions.Where(p => p.Title.Equals("Spouse Employed Current Company")).SingleOrDefault(),
                //    Survey = context.Surveys.Where(p => p.SurveyName.Equals("Demo Survey")).SingleOrDefault()
                //},

                new SurveyQuestionnaire
                {
                    Id = 2,
                    IsStartingQuestion = false,
                    IsEndingQuestion = false,
                    Question = context.Questions.Where(p => p.Title.Equals("Spouse Employer")).FirstOrDefault(),
                    Survey = context.Surveys.Where(p => p.Title.Equals("Demo Survey")).FirstOrDefault(),
                    Answer = context.Answers.Where(p => p.Id == 2).SingleOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now

                },

                new SurveyQuestionnaire
                {
                    Id = 3,
                    IsStartingQuestion = false,
                    IsEndingQuestion = true,
                    Question = context.Questions.Where(p => p.Title.Equals("Electronic Signature")).FirstOrDefault(),
                    Survey = context.Surveys.Where(p => p.Title.Equals("Demo Survey")).FirstOrDefault(),
                    Answer = context.Answers.Where(p => p.Id == 2).FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now

                }
              );



            context.Rules.AddOrUpdate(

                new SkipLogicRule
                {
                    Id = 1,
                    Question = context.Questions.Where(p => p.Title.Equals("Self Employed")).FirstOrDefault(),
                    NextQuestion = context.Questions.Where(p => p.Title.Equals("Electronic Signature")).FirstOrDefault(),
                    OperatorType = context.OperatorTypes.Where(p => p.Description == "EqualsTo").FirstOrDefault(),
                    TriggerDialog = false,
                    Unit = context.UnitOfMeasures.Where(p => p.Description == "Text").FirstOrDefault(),
                    ValidAnswer = "Yes",
                    Survey = context.Surveys.Where(p => p.Title.Equals("Demo Survey")).FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now

                },

                new SkipLogicRule
                {
                    Id = 2,
                    Question = context.Questions.Where(p => p.Title.Equals("Self Employed")).FirstOrDefault(),
                    NextQuestion = context.Questions.Where(p => p.Title.Equals("Spouse Employer")).FirstOrDefault(),
                    OperatorType = context.OperatorTypes.Where(p => p.Description.Equals("EqualsTo")).FirstOrDefault(),
                    TriggerDialog = false,
                    Unit = context.UnitOfMeasures.Where(p => p.Description.Equals("Text")).FirstOrDefault(),
                    ValidAnswer = "No",
                    Survey = context.Surveys.Where(p => p.Title.Equals("Demo Survey")).FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now

                },

                new SkipLogicRule
                {
                    Id = 3,
                    Question = context.Questions.Where(p => p.Title.Equals("Spouse Employer")).FirstOrDefault(),
                    NextQuestion = context.Questions.Where(p => p.Title.Equals("Electronic Signature")).FirstOrDefault(),
                    OperatorType = context.OperatorTypes.Where(p => p.Description == "NoOperator").FirstOrDefault(),
                    TriggerDialog = false,
                    Unit = context.UnitOfMeasures.Where(p => p.Description == "Text").FirstOrDefault(),
                    ValidAnswer = null,
                    Survey = context.Surveys.Where(p => p.Title.Equals("Demo Survey")).FirstOrDefault(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now

                }

                );
            context.SaveChanges();
        }

    }
}

