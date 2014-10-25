using System.Linq;
using System.Web.Mvc;
using TheCompany.Common;
using TheCompany.Data;

namespace TheCompany.Web.Frontend.Controllers
{
    [Authorize(Roles = RolesConst.Admin)]
    public class MenuController : BaseController
    {
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            var menus = TheCompanyDb.Menus.Where(m => m.Deleted == false).ToList();
            return View(menus);
        }

        //
        // GET: /Menu/Details/5
        public ActionResult Details(int id)
        {
            var menu = TheCompanyDb.Menus.First(m => m.Id == id);
            return View(menu);
        }

        //
        // GET: /Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Menu/Create
        [HttpPost]
        public ActionResult Create(Menu menuToAdd)
        {
            try
            {
                TheCompanyDb.Menus.Add(menuToAdd);
                TheCompanyDb.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Menu/Edit/5
        public ActionResult Edit(int id)
        {
            var menuToEdit = TheCompanyDb.Menus.First(m => m.Id == id);
            return View(menuToEdit);
        }

        //
        // POST: /Menu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Menu menuUpdated)
        {
            try
            {
                var menuToEdit = TheCompanyDb.Menus.First(m => m.Id == id);
                menuToEdit.TitleEN = menuUpdated.TitleEN;
                menuToEdit.TitleBG = menuUpdated.TitleBG;

                TheCompanyDb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Menu/Delete/5
        public ActionResult Delete(int id)
        {
            var menu = TheCompanyDb.Menus.First(m => m.Id == id);
            return View(menu);
        }

        //
        // POST: /Menu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var menuToDelete = TheCompanyDb.Menus.FirstOrDefault(m => m.Id == id);
                menuToDelete.Deleted = true;
                TheCompanyDb.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
