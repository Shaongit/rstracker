using RSTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSTracker.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var requisitions = db.Requisitions.ToList();
            //.Include(r => r.Dep).Include(r => r.Designation).Include(r => r.Div).Include(r => r.Emp).Include(r => r.Employee).Include(r => r.Stat).Include(r => r.SubUni);
            return View(requisitions);
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