using System.Linq;
using System.Web.Mvc;
using TheCompany.Common;
using TheCompany.Web.Frontend.Models;

namespace TheCompany.Web.Frontend.Controllers
{
    [Authorize(Roles = RolesConst.Admin)]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            var admins = db.Users.Where(user => user.Roles.Any(role => role.Role.Name == RolesConst.Admin)).ToList();
            return View(admins);
        }
	}
}