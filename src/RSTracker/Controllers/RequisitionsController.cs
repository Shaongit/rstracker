using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSTracker.Models;
using RSTracker.Utility;

namespace RSTracker.Controllers
{
    [Authorize()]
    public class RequisitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Requisitions
        public ActionResult Index()
        {
            var requisitions = db.Requisitions.Include(r => r.Dept).Include(r => r.Designation).Include(r => r.Division).Include(r => r.RequiredByEmp).Include(r => r.Employee).Include(r => r.Status).Include(r => r.SubUnit);
            return View(requisitions.Where(p=>p.StatusId != 3).OrderBy(p=>p.RequisitionDate).ToList());
        }

        // GET: Requisitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Requisition requisition = db.Requisitions.Find(id);
            int vacancyTypeId = requisition.VacancyTypeId ?? 0;
            requisition.VacancyTypeName = VacancyType.GetVacancyType(vacancyTypeId);

            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // GET: Requisitions/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Dept, "Id", "Name");
            ViewBag.Position = new SelectList(db.Designation, "Id", "Name");
            ViewBag.DivisionId = new SelectList(db.Division, "Id", "Name");
            ViewBag.RequiredBy = new SelectList(db.Employee, "Id", "Name");
            ViewBag.RaisedBy = new SelectList(db.Employee, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name");
            ViewBag.SubUnitId = new SelectList(db.SubUnit, "Id", "Name");

            List<SelectListItem> vacancyTypeList = new List<SelectListItem>();
            vacancyTypeList.Add(new SelectListItem { Text = "New", Value = "1" });
            vacancyTypeList.Add(new SelectListItem { Text = "Replacement", Value = "2" });

            ViewBag.VacancyTypeId = vacancyTypeList;

            return View();
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,RefNo,RaisedBy,Position,Division,Dept,SubUnit,RequisitionDate,RequiredBy,VacancyType,LastWorkingDay,Status")] Requisition requisition)
        public ActionResult Create(Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Requisitions.Add(requisition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Dept, "Id", "Name", requisition.Dept);
            ViewBag.Position = new SelectList(db.Designation, "Id", "Name", requisition.PositionId);
            ViewBag.DivisionId = new SelectList(db.Division, "Id", "Name", requisition.Division);
            ViewBag.RequiredBy = new SelectList(db.Employee, "Id", "Name", requisition.RequiredBy);
            ViewBag.RaisedBy = new SelectList(db.Employee, "Id", "Name", requisition.RaisedBy);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name", requisition.Status);
            ViewBag.SubUnitId = new SelectList(db.SubUnit, "Id", "Name", requisition.SubUnit);

            List<SelectListItem> vacancyTypeList = new List<SelectListItem>();
            vacancyTypeList.Add(new SelectListItem { Text = "New", Value = "1" });
            vacancyTypeList.Add(new SelectListItem { Text = "Replacement", Value = "2" });

            ViewBag.VacancyTypeId = vacancyTypeList;


            return View(requisition);
        }

        // GET: Requisitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Dept, "Id", "Name", requisition.Dept);
            ViewBag.PositionId = new SelectList(db.Designation, "Id", "Name", requisition.PositionId);
            ViewBag.DivisionId = new SelectList(db.Division, "Id", "Name", requisition.Division);
            ViewBag.RequiredBy = new SelectList(db.Employee, "Id", "Name", requisition.RequiredBy);
            ViewBag.RaisedBy = new SelectList(db.Employee, "Id", "Name", requisition.RaisedBy);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name", requisition.Status);
            ViewBag.SubUnitId = new SelectList(db.SubUnit, "Id", "Name", requisition.SubUnit);

            List<SelectListItem> vacancyTypeList = new List<SelectListItem>();
            vacancyTypeList.Add(new SelectListItem { Text = "New", Value = "1" });
            vacancyTypeList.Add(new SelectListItem { Text = "Replacement", Value = "2" });

            ViewBag.VacancyTypeId = new SelectList(vacancyTypeList, "Value", "Text",requisition.VacancyTypeId);

            //ViewBag.VacancyTypeId = new SelectList(db.Division, "Id", "Name", dept.DivisionId);
            //ViewBag.DivisionId = new SelectList(db.Division, "Id", "Name", dept.DivisionId);
            return View(requisition);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dept = new SelectList(db.Dept, "Id", "Name", requisition.Dept);
            ViewBag.Position = new SelectList(db.Designation, "Id", "Name", requisition.PositionId);
            ViewBag.Division = new SelectList(db.Division, "Id", "Name", requisition.Division);
            ViewBag.RequiredBy = new SelectList(db.Employee, "Id", "Name", requisition.RequiredBy);
            ViewBag.RaisedBy = new SelectList(db.Employee, "Id", "Name", requisition.RaisedBy);
            ViewBag.Status = new SelectList(db.Status, "Id", "Name", requisition.Status);
            ViewBag.SubUnit = new SelectList(db.SubUnit, "Id", "Name", requisition.SubUnit);

            List<SelectListItem> vacancyTypeList = new List<SelectListItem>();
            vacancyTypeList.Add(new SelectListItem { Text = "New", Value = "1" });
            vacancyTypeList.Add(new SelectListItem { Text = "Replacement", Value = "2" });

            ViewBag.VacancyTypeId = new SelectList(vacancyTypeList, "Value", "Text", requisition.VacancyTypeId);

            return View(requisition);
        }

        // GET: Requisitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisition requisition = db.Requisitions.Find(id);
            db.Requisitions.Remove(requisition);
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
