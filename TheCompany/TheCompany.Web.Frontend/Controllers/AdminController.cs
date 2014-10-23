using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheCompany.Common;
using TheCompany.Web.Frontend.Models;

namespace TheCompany.Web.Frontend.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles = RolesConst.Admin)]
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            var admins = db.Users.Where(user => user.Roles.Any(role => role.Role.Name == RolesConst.Admin)).ToList();
            return View(admins);
        }
	}
}