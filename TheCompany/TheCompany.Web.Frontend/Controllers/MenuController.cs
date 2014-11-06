using System;
using System.Collections.Generic;
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
            var menus = TheCompanyDb.Menus
                .Where(m => m.Deleted == false)
                .AsEnumerable()
                .Select(x => new MenuViewModel
                {
                    Id = x.Id,
                    TitleEN = x.TitleEN,
                    TitleBG = x.TitleBG,
                    ParentMenuId = x.ParentMenuId,
                    Menus = GetActiveMenus()
                });

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
            var model = new MenuViewModel();
            model.Menus = GetActiveMenus();
            return View(model);
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

            var menuViewModel = new MenuViewModel();
            menuViewModel.Id = menuToEdit.Id;
            menuViewModel.TitleEN = menuToEdit.TitleEN;
            menuViewModel.TitleBG = menuToEdit.TitleBG;
            menuViewModel.ParentMenuId = menuToEdit.ParentMenuId;
            menuViewModel.Menus = GetActiveMenus();

            return View(menuViewModel);
        }

        //
        // POST: /Menu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MenuViewModel menuUpdated)
        {
            try
            {
                var menuToEdit = TheCompanyDb.Menus.First(m => m.Id == id);
                menuToEdit.TitleEN = menuUpdated.TitleEN;
                menuToEdit.TitleBG = menuUpdated.TitleBG;

                // check if given parent menu can be parent
                if (CanMenuBeParent(id, menuUpdated.ParentMenuId))
                {
                    menuToEdit.ParentMenuId = menuUpdated.ParentMenuId;
                }
                else
                {
                    throw new ArgumentException(
                        string.Format("The current menu \"{0}\" can not have \"{1}\" menu as parent, because menu \"{0}\" is already a parent to \"{1}\" menu!",
                        menuToEdit.TitleEN, TheCompanyDb.Menus.First(x => x.Id == menuUpdated.ParentMenuId).TitleEN));
                }

                TheCompanyDb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (ArgumentException exc)
            {
                var errorInfo = new HandleErrorInfo(exc, "MenuController", "Edit");
                return View("Error", errorInfo);
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

        private IEnumerable<SelectListItem> GetActiveMenus()
        {
            var activeMenus = TheCompanyDb.Menus
                .Where(m => m.Deleted == false)
                .AsEnumerable()
                .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.TitleEN });

            return new SelectList(activeMenus, "Value", "Text");
        }

        [ChildActionOnly]
        public ActionResult GetMenuChildren(int? id)
        {
            var menuChildren = TheCompanyDb.Menus
                .Where(m => m.ParentMenuId == id)
                .AsEnumerable()
                .Select(x => new MenuViewModel
                {
                    Id = x.Id,
                    ParentMenuId = x.ParentMenuId,
                    TitleBG = x.TitleBG,
                    TitleEN = x.TitleEN,
                    MenuItems = x.MenuItems
                });
            return PartialView("_GenerateMenuChildren", menuChildren);
        }

        [ChildActionOnly]
        public bool CanMenuBeParent(int currentMenuId, int? parentMenuId)
        {
            if (parentMenuId == null)
            {
                return true;
            }

            var currentMenu = TheCompanyDb.Menus.First(x => x.Id == currentMenuId);
            var parentMenu = TheCompanyDb.Menus.First(x => x.Id == parentMenuId);

            return !(parentMenu.ParentMenuId == currentMenu.Id);
        }
    }
}
