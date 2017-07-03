using AppliancesApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AppliancesApp.Controllers
{
    public class HomeController : Controller
    {
        ApplianceContext db = new ApplianceContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Appliance appl = db.Appliances.Find(id);
            List<ApplianceRestriction> restrictions = db.ApplianceRestrictions.ToList();
            ViewBag.restricts = GetRestrictions();
            if (appl != null)
            {
                return PartialView("Edit", appl);
            }
            return View("List");
        }

        public ActionResult Add()
        {
            return PartialView("Add", new Appliance());
        }

        public ActionResult Delete(int id)
        {
            Appliance appl = db.Appliances.Find(id);
            if (appl != null)
            {
                return PartialView("Delete", appl);
            }
            return View("List");
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

        [HttpGet]
        public ActionResult GetAllAppliances()
        {
            var allAppliances = db.Appliances.ToList();

            if (allAppliances.Count <= 0)
            {
                return HttpNotFound();
            }

            return PartialView("List", allAppliances);
        }

        [HttpPost]
        public ActionResult UpdateAppliance(Appliance appliance)
        {
            appliance.CreateDate = Convert.ToDateTime(appliance.CreateDate);
            db.Entry(appliance).State = EntityState.Modified;
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult AddAppliance(Appliance appliance)
        {
            db.Appliances.Add(appliance);
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult DeleteAppliance(Appliance appliance)
        {
            db.Appliances.Remove(db.Appliances.Where(p => p.Id == appliance.Id).First());
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private Dictionary<string, bool?> GetRestrictions()
        {
            List<ApplianceRestriction> restrictions = db.ApplianceRestrictions.ToList();
            Dictionary<string, bool?> dict = new Dictionary<string, bool?>();
            foreach (var restr in restrictions)
            {
                dict.Add(restr.Name, restr.IsHidden);
            }
            return dict;
        }
    }
}