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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employee = db.Employee.Include(e => e.Dept).Include(e => e.Designation).Include(e => e.Division).Include(e => e.SubUnit);
            return View(employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Dept, "Id", "Name");
            ViewBag.DesignationId = new SelectList(db.Designation, "Id", "Name");
            ViewBag.DivisionId = new SelectList(db.Division, "Id", "Name");
            ViewBag.SubUnitId = new SelectList(db.SubUnit, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DesignationId,DeptId,DivisionId,SubUnitId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Dept, "Id", "Name", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designation, "Id", "Name", employee.DesignationId);
            ViewBag.DivisionId = new SelectList(db.Division, "Id", "Name", employee.DivisionId);
            ViewBag.SubUnitId = new SelectList(db.SubUnit, "Id", "Name", employee.SubUnitId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Dept, "Id", "Name", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designation, "Id", "Name", employee.DesignationId);
            ViewBag.DivisionId = new SelectList(db.Division, "Id", "Name", employee.DivisionId);
            ViewBag.SubUnitId = new SelectList(db.SubUnit, "Id", "Name", employee.SubUnitId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DesignationId,DeptId,DivisionId,SubUnitId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Dept, "Id", "Name", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designation, "Id", "Name", employee.DesignationId);
            ViewBag.DivisionId = new SelectList(db.Division, "Id", "Name", employee.DivisionId);
            ViewBag.SubUnitId = new SelectList(db.SubUnit, "Id", "Name", employee.SubUnitId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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
