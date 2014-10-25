namespace TheCompany.Web.Frontend.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TheCompany.Common;
    using TheCompany.Data;
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
                var adminRole = new IdentityRole(RolesConst.Admin);
                if (!db.Roles.Any(role => role.Name == RolesConst.Admin))
                {
                    db.Roles.AddOrUpdate(adminRole);
                }

                var adminUser = new ApplicationUser("Admin");
                adminUser.PasswordHash = new PasswordHasher().HashPassword("Admin");
                adminUser.Roles.Add(new IdentityUserRole
                {
                    RoleId = adminRole.Id,
                    Role = adminRole,
                    User = adminUser,
                    UserId = adminUser.Id
                });

                if (!db.Users.Any(user => user.UserName == "Admin"))
                {
                    db.Users.AddOrUpdate(adminUser);
                }

                db.SaveChanges();

                var theCompanyDb = new TheCompanyDbContext();
                var menu = new Menu();
                menu.TitleEN = "Starters";
                menu.TitleBG = "Предястия";

                if (!theCompanyDb.Menus.Any(m => m.TitleEN == menu.TitleEN))
                {
                    theCompanyDb.Menus.Add(menu);
                    theCompanyDb.SaveChanges();
                }

                var menuItem = new MenuItem();
                menuItem.TitleEN = "New Zealand Green Shell Mussels";
                menuItem.TitleBG = "Новозеландски миди";
                menuItem.Price = 9.50m;
                menuItem.Grams = 200;
                menuItem.DescriptionBG = "Запечени с масло и чесън, чушки, лук и подправени с балсомово-лимонен дресинг";
                menuItem.DescriptionEN = "Grilled with Garlic Butter, bell peppers, shallots, onion, tomato and enhanced by a balsamic lemon dressing.";
                menuItem.MenuId = menu.Id;

                if (!theCompanyDb.MenuItems.Any(m => m.TitleEN == menuItem.TitleEN))
                {
                    theCompanyDb.MenuItems.Add(menuItem);
                    theCompanyDb.SaveChanges();
                }

                var contactInfo = new ContactInfo();
                contactInfo.TitleEN = "Opening Times:";
                contactInfo.TitleBG = "Работно Време:";
                contactInfo.DescriptionEN = "12:00 pm - 02:00 am";
                contactInfo.DescriptionBG = "12:00 - 02:00";

                if (!theCompanyDb.ContactInfos.Any(c => c.TitleEN == contactInfo.TitleEN))
                {
                    theCompanyDb.ContactInfos.Add(contactInfo);
                    theCompanyDb.SaveChanges();
                }
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
