using HSTrackerService.Interface;
using RSTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSTracker.Controllers
{
    [Authorize()]
    public class HomeController : Controller
    {
        private readonly IRequisitionService requisitionService;
        public HomeController(IRequisitionService requisitionService)
        {
            this.requisitionService = requisitionService;
        }
        public ActionResult Index()
        {
            var requisitions = requisitionService.GetAllRequisition();
            //.Include(r => r.Dep).Include(r => r.Designation).Include(r => r.Div).Include(r => r.Emp).Include(r => r.Employee).Include(r => r.Stat).Include(r => r.SubUni);
            return View(requisitions.Where(p => p.StatusId !=3).OrderBy(p => p.RequisitionDate).ToList());
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