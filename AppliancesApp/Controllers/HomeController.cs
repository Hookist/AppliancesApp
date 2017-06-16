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
            Dictionary<string, bool?> dict = new Dictionary<string, bool?>();
            foreach(var restr in restrictions)
            {
                dict.Add(restr.Name, restr.IsHidden);
            }
            ViewBag.restricts = dict;
            if (appl != null)
            {
                return PartialView("Edit", appl);
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
    }
}