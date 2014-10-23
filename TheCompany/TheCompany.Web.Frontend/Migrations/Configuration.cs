namespace TheCompany.Web.Frontend.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TheCompany.Web.Frontend.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheCompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheCompanyDbContext context)
        {
            try
            {
                var db = new ApplicationDbContext();
                var adminRole = new IdentityRole("AdminRole");
                db.Roles.AddOrUpdate(adminRole);

                var adminUser = new ApplicationUser("Admin");
                adminUser.PasswordHash = new PasswordHasher().HashPassword("Admin");
                adminUser.Roles.Add(new IdentityUserRole
                {
                    RoleId = adminRole.Id,
                    Role = adminRole,
                    User = adminUser,
                    UserId = adminUser.Id
                });

                db.Users.AddOrUpdate(adminUser);

                db.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
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
    }
}
