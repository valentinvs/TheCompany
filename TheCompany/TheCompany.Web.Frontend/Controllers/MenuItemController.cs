using System.Linq;
using System.Web.Mvc;
using TheCompany.Common;
using TheCompany.Data;

namespace TheCompany.Web.Frontend.Controllers
{
    [Authorize(Roles = RolesConst.Admin)]
    public class MenuItemController : BaseController
    {
        //
        // GET: /MenuItem/Create
        public ActionResult Create(int menuId)
        {
            var emptyMenuItem = new MenuItem();
            emptyMenuItem.MenuId = menuId;
            return View(emptyMenuItem);
        }

        //
        // POST: /MenuItem/Create
        [HttpPost]
        public ActionResult Create(MenuItem menuItemToAdd)
        {
            try
            {
                TheCompanyDb.MenuItems.Add(menuItemToAdd);
                TheCompanyDb.SaveChanges();

                return RedirectToAction("Details", "Menu", new { id = menuItemToAdd.MenuId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MenuItem/Edit/5
        public ActionResult Edit(int id)
        {
            var menuItemToEdit = TheCompanyDb.MenuItems.First(mi => mi.Id == id);
            return View(menuItemToEdit);
        }

        //
        // POST: /MenuItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MenuItem menuItemUpdatedByTheUser)
        {
            try
            {
                var menuItemToUpdate = TheCompanyDb.MenuItems.First(mi => mi.Id == id);
                menuItemToUpdate.DescriptionBG = menuItemUpdatedByTheUser.DescriptionBG;
                menuItemToUpdate.DescriptionEN = menuItemUpdatedByTheUser.DescriptionEN;
                menuItemToUpdate.Grams = menuItemUpdatedByTheUser.Grams;
                menuItemToUpdate.Price = menuItemUpdatedByTheUser.Price;
                menuItemToUpdate.TitleBG = menuItemUpdatedByTheUser.TitleBG;
                menuItemToUpdate.TitleEN = menuItemUpdatedByTheUser.TitleEN;

                TheCompanyDb.SaveChanges();

                return RedirectToAction("Details", "Menu", new { id = menuItemToUpdate.MenuId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MenuItem/Delete/5
        public ActionResult Delete(int id)
        {
            var menuItemToDelete = TheCompanyDb.MenuItems.First(mi => mi.Id == id);
            return View(menuItemToDelete);
        }

        //
        // POST: /MenuItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MenuItem menuItemToDelete)
        {
            try
            {
                var itemToDelete = TheCompanyDb.MenuItems.First(mi => mi.Id == id);
                itemToDelete.Deleted = true;
                TheCompanyDb.SaveChanges();

                return RedirectToAction("Details", "Menu", new { id = itemToDelete.MenuId });
            }
            catch
            {
                return View();
            }
        }
    }
}
