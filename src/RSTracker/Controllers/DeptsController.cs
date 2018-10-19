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
    public class DeptsController : Controller
    {
        private readonly IDeptService deptService;
        private readonly IDivisionService divisionService;

        public DeptsController(IDeptService deptService, IDivisionService divisionService)
        {
            this.deptService = deptService;
            this.divisionService = divisionService;
        }
        // GET: Depts
        public ActionResult Index()
        {
            var dept = deptService.GetAllDept();
            return View(dept.ToList());
        }

        // GET: Depts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = deptService.GetDept(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // GET: Depts/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name");
            return View();
        }

        // POST: Depts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DivisionId")] Dept dept)
        {
            if (ModelState.IsValid)
            {
                deptService.CreateDept(dept);
                deptService.SaveDept();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", dept.DivisionId);
            return View(dept);
        }

        // GET: Depts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = deptService.GetDept(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", dept.DivisionId);
            return View(dept);
        }

        // POST: Depts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DivisionId")] Dept dept)
        {
            if (ModelState.IsValid)
            {
                deptService.EditDept(dept);
                deptService.SaveDept();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", dept.DivisionId);
            return View(dept);
        }

        // GET: Depts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = deptService.GetDept(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // POST: Depts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dept dept = deptService.GetDept(id);
            deptService.DeleteDept(dept);
            deptService.SaveDept();
            return RedirectToAction("Index");
        }

    }
}
