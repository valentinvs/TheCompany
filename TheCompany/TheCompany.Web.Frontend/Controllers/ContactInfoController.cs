using System.Web.Mvc;
using TheCompany.Common;
using System.Linq;
using TheCompany.Data;

namespace TheCompany.Web.Frontend.Controllers
{
    [Authorize(Roles = RolesConst.Admin)]
    public class ContactInfoController : BaseController
    {
        //
        // GET: /ContactInfo/
        public ActionResult Index()
        {
            var contactInfoList = TheCompanyDb.ContactInfos.ToList();
            return View(contactInfoList);
        }

        //
        // GET: /ContactInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ContactInfo/Create
        [HttpPost]
        public ActionResult Create(ContactInfo newContactInfo)
        {
            try
            {
                TheCompanyDb.ContactInfos.Add(newContactInfo);
                TheCompanyDb.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ContactInfo/Edit/5
        public ActionResult Edit(int id)
        {
            var contactInfoToEdit = TheCompanyDb.ContactInfos.First(c => c.Id == id);
            return View(contactInfoToEdit);
        }

        //
        // POST: /ContactInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactInfo updatedContactInfo)
        {
            try
            {
                var toUpdate = TheCompanyDb.ContactInfos.First(c => c.Id == id);
                toUpdate.TitleEN = updatedContactInfo.TitleEN;
                toUpdate.TitleBG = updatedContactInfo.TitleBG;
                toUpdate.DescriptionEN = updatedContactInfo.DescriptionEN;
                toUpdate.DescriptionBG = updatedContactInfo.DescriptionBG;
                TheCompanyDb.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ContactInfo/Delete/5
        public ActionResult Delete(int id)
        {
            var contactInfoToDelete = TheCompanyDb.ContactInfos.First(c => c.Id == id);
            return View(contactInfoToDelete);
        }

        //
        // POST: /ContactInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ContactInfo contactInfoToRemove)
        {
            try
            {
                var toRemove = TheCompanyDb.ContactInfos.First(c => c.Id == id);
                TheCompanyDb.ContactInfos.Remove(toRemove);
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
