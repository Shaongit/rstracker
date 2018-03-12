using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSTracker.Models;

namespace RSTracker.Controllers
{
    [Authorize()]
    public class CircularsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Circulars
        public ActionResult Index(int? requisitionId)
        {
            List<Circular> circular = new List<Circular>();

            if (requisitionId != null)
            {
                circular = db.Circular.Include(c => c.Requisition).Where(p=>p.RequisitionId == requisitionId).ToList();
            }
            else
            {
                circular = db.Circular.Include(c => c.Requisition).ToList();
            }
            return View(circular.ToList());
        }

        // GET: Circulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circular circular = db.Circular.Find(id);
            if (circular == null)
            {
                return HttpNotFound();
            }
            return View(circular);
        }

        // GET: Circulars/Create
        public ActionResult Create()
        {
            ViewBag.RequisitionId = new SelectList(db.Requisitions, "Id", "RefNo");
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
                db.Circular.Add(circular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequisitionId = new SelectList(db.Requisitions, "Id", "RefNo", circular.RequisitionId);
            return View(circular);
        }

        // GET: Circulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circular circular = db.Circular.Find(id);
            if (circular == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequisitionId = new SelectList(db.Requisitions, "Id", "RefNo", circular.RequisitionId);
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
                db.Entry(circular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequisitionId = new SelectList(db.Requisitions, "Id", "RefNo", circular.RequisitionId);
            return View(circular);
        }

        // GET: Circulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circular circular = db.Circular.Find(id);
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
            Circular circular = db.Circular.Find(id);
            db.Circular.Remove(circular);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
