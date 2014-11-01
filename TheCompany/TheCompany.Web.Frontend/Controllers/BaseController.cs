using System.Web.Mvc;
using TheCompany.Common;
using TheCompany.Web.Frontend.Models;

namespace TheCompany.Web.Frontend.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.TheCompanyDb = new TheCompanyDbContext();
        }

        public TheCompanyDbContext TheCompanyDb { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (TheCompanyDb != null)
            {
                TheCompanyDb.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}