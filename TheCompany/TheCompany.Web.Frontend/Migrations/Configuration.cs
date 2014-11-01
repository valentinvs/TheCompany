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
                CreateAdmin();

                var theCompanyDb = new TheCompanyDbContext();

                var menuStarters = CreateMenu(theCompanyDb, "Starters", "Предястия");
                CreateMenuItem(theCompanyDb, menuStarters, "New Zealand Green Shell Mussels", "Новозеландски миди", "Grilled with Garlic Butter, bell peppers, shallots, onion, tomato and enhanced by a balsamic lemon dressing.", "Запечени с масло и чесън, чушки, лук и подправени с балсомово-лимонен дресинг", 200, 9.50m);
                CreateMenuItem(theCompanyDb, menuStarters, "Deep fried Wedge of Brie", "Панирано сирене Бри", "Enhanced by an Onion Marmalade, and Balsamic glazed Beetroot.", "Сервира се с мармалад от лук и карамелизирано червено цвекло", 150, 8.50m);
                CreateMenuItem(theCompanyDb, menuStarters, "Soup of the moment", "Супа на деня", "Made up from locally sourced market ingredients and served with homemade Guinness bread.", "Приготвена от свежи зеленчуци според сезона и сервирана с домашно приготвен хляб \"Гинес\"", 380, 5.90m);
                CreateMenuItem(theCompanyDb, menuStarters, "Thai Green Vegetable Soup", "Тайландскa зеленчукова супа", "Authentic Thai Soup flavored with aromatic spices accompanied by freshly baked bread.", "Автентична тайландска зеленчукова супа ароматизирана с тайландски подправки, поднесена с прясно изпечен хляб", 380, 6.50m);

                var menuSalads = CreateMenu(theCompanyDb, "Salads", "Салати");
                CreateMenuItem(theCompanyDb, menuSalads, "Green Salad", "Зелена Салата", "Mixed leaves, peppers, cucumber, tomatoes, red onions, black and green olives dressed with Greek extra virgin olive oil, grain mustard and balsamic vinegar.", "Микс от салати, чушки, краставици, домати, червен лук, черни и зелени маслини с дресинг от гръцки зехтин, горчица и балсамов оцет.", 300, 6.80m);
                CreateMenuItem(theCompanyDb, menuSalads, "Greek Salad", "Гръцка салата", "Beef tomatoes, fresh cucumbers, green peppers, black olives, red onion, and Feta cheese dressed with oregano and olive oil.", "Домати, микс от салати, чушки и сирене фета с дресинг от зехтин и балсамов оцет", 300, 9.90m);
                CreateMenuItem(theCompanyDb, menuSalads, "Ceasar Salad", "Салата Цезар", "Mixed leaves, rosemary and garlic flavoured croutons, bound in a traditional Ceasar dressing and topped with tender chicken fillet, pesto and parmesan shavings.", "Микс от зелени салати, пилешки филенца, крутони с розмарин и чесън, овкусени с традиционен сос \"Цезар\", песто и филетиран пармезан", 300, 11.80m);
                CreateMenuItem(theCompanyDb, menuSalads, "Tuna Salad", "Салата с риба тон", "Tossed with mixed leaves, Rocket, black and green olives, peppers, red onions, tomatoes and bound with a lemon and olive oil dressing.", "Микс от зелени салати, рукола, черни и зелени маслини, чушки, червен лук, домати, овкусени с дресинг по специална рецепта", 300, 10.20m);
                CreateMenuItem(theCompanyDb, menuSalads, "Toasted Goats Cheese Salad", "Салата с запечено козе сирене", "Served with Rocket Salad, candied Beetroot and roasted Cashew nuts, enhanced by a thyme infused balsamic reduction.", "Сервира се с рукола, захаросано цвекло и печено кашу, подправена с мащерка и балсамов оцет", 300, 12.50m);

                var menuSnacks = CreateMenu(theCompanyDb, "Snacks", "Плата");
                CreateMenuItem(theCompanyDb, menuSnacks, "Louisiana Hot Wings", "Пикантни пилешки крилца \"Луизиана\"", "Crisp Chicken wings tossed in a chilli butter sauce accompanied by a blue cheese and garlic dip.", "Хрупкави пилешки крилца, потопени в маслен чили сос, придружени със синьо сирене и чеснов сос", 400, 10.50m);
                CreateMenuItem(theCompanyDb, menuSnacks, "Chicken Tenders", "Пилешки филенца", "Goujons of Chicken tenderloin in a lemon pepper breadcrumb served with a seasonal salad.", "Жулиени от пилешко филе с лимонова панировка, свежа салата", 300, 8.50m);
                CreateMenuItem(theCompanyDb, menuSnacks, "Cheese Board-Big", "Плато Сирена-Голямо", "Brie, Blue cheese, Goat cheese served with Red Onion Marmalade, olives and grapes", "Сирене Бри, синьо сирене, козе сирене, поднесено с мармалад от червен лук с маслини и грозде", 250, 24m);
                CreateMenuItem(theCompanyDb, menuSnacks, "Cheese Board-Small", "Плато Сирена-Малко", "Brie, Blue cheese, Goat cheese served with Red Onion Marmalade, olives and grapes", "Сирене Бри, синьо сирене, козе сирене, поднесено с мармалад от червен лук с маслини и грозде", 400, 32m);

                CreateContactInfo(theCompanyDb, "Opening Times:", "Работно Време:", "12:00 pm - 02:00 am", "12:00 - 02:00");

                theCompanyDb.Dispose();
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
        }

        private static void CreateContactInfo(TheCompanyDbContext theCompanyDb, string titleEN, string titleBG, string descriptionEN, string descriptionBG)
        {
            var contactInfo = new ContactInfo();
            contactInfo.TitleEN = titleEN;
            contactInfo.TitleBG = titleBG;
            contactInfo.DescriptionEN = descriptionEN;
            contactInfo.DescriptionBG = descriptionBG;

            if (!theCompanyDb.ContactInfos.Any(c => c.TitleEN == contactInfo.TitleEN))
            {
                theCompanyDb.ContactInfos.Add(contactInfo);
                theCompanyDb.SaveChanges();
            }
        }

        private static void CreateMenuItem(TheCompanyDbContext theCompanyDb, Menu menu, string titleEN, string titleBG, string descriptionBG, string descriptionEN, double grams, decimal price)
        {
            var menuItem = new MenuItem();
            menuItem.TitleEN = titleEN;
            menuItem.TitleBG = titleBG;
            menuItem.DescriptionEN = descriptionEN;
            menuItem.DescriptionBG = descriptionBG;
            menuItem.Grams = grams;
            menuItem.Price = price;
            menuItem.MenuId = menu.Id;

            if (!theCompanyDb.MenuItems.Any(m => m.TitleEN == menuItem.TitleEN && m.MenuId == menu.Id && m.Deleted == false))
            {
                theCompanyDb.MenuItems.Add(menuItem);
                theCompanyDb.SaveChanges();
            }
        }

        private static Menu CreateMenu(TheCompanyDbContext dbContext, string titleEN, string titleBG)
        {
            var menu = new Menu();
            menu.TitleEN = titleEN;
            menu.TitleBG = titleBG;

            if (!dbContext.Menus.Any(m => m.TitleEN == menu.TitleEN && m.Deleted == false))
            {
                dbContext.Menus.Add(menu);
                dbContext.SaveChanges();
            }
            return menu;
        }



        private static void CreateAdmin()
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
            db.Dispose();
        }
    }
}
