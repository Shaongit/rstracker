using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSTracker.Models;
using HSTrackerModel.Models;
using HSTrackerService.Interface;

namespace RSTracker.Controllers
{
    [Authorize()]
    public class CircularsController : Controller
    {
        private readonly ICircularService circularService;
        private readonly IRequisitionService requisitionService;
        public CircularsController(IRequisitionService requisitionService, ICircularService circularService)
        {
            this.circularService = circularService;
            this.requisitionService = requisitionService;
        }

        // GET: Circulars
        public ActionResult Index(int? requisitionId)
        {
            var circular = circularService.GetAllCircular(requisitionId);

            return View(circular);
        }

        // GET: Circulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var circular = circularService.GetCircular(id);
            if (circular == null)
            {
                return HttpNotFound();
            }
            return View(circular);
        }

        // GET: Circulars/Create
        public ActionResult Create()
        {
            ViewBag.RequisitionId = new SelectList(requisitionService.GetAllRequisition(), "Id", "RefNo");
            return View();
        }

        // POST: Circulars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Circular circular)
        {
            if (ModelState.IsValid)
            {
                circularService.CreateCircular(circular);
                circularService.SaveCircular();
                return RedirectToAction("Index");
            }

            ViewBag.RequisitionId = new SelectList(requisitionService.GetAllRequisition(), "Id", "RefNo", circular.RequisitionId);
            return View(circular);
        }

        // GET: Circulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circular circular = circularService.GetCircular(id);
            if (circular == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequisitionId = new SelectList(requisitionService.GetAllRequisition(), "Id", "RefNo", circular.RequisitionId);
            return View(circular);
        }

        // POST: Circulars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Circular circular)
        {
            if (ModelState.IsValid)
            {
                circularService.EditCircular(circular);
                circularService.SaveCircular();
                return RedirectToAction("Index");
            }
            ViewBag.RequisitionId = new SelectList(requisitionService.GetAllRequisition(), "Id", "RefNo", circular.RequisitionId);
            return View(circular);
        }

        // GET: Circulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circular circular = circularService.GetCircular(id);
            if (circular == null)
            {
                return HttpNotFound();
            }
            return View(circular);
        }

        // POST: Circulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circular circular = circularService.GetCircular(id);
            circularService.DeleteCircular(circular);
            circularService.SaveCircular();
            return RedirectToAction("Index");
        }

    }
}
