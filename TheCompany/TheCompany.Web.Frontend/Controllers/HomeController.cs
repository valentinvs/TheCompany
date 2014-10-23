using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheCompany.Web.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new TheCompany.Web.Frontend.Models.TheCompanyDbContext();
            var menus = db.Menus.ToList();
            return View(menus);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}