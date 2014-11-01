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
            return View();
        }
	}
}