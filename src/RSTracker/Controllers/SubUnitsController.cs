using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSTracker.Models;
using HSTrackerService.Interface;
using HSTrackerModel.Models;

namespace RSTracker.Controllers
{
    [Authorize()]
    public class SubUnitsController : Controller
    {
        private readonly IDeptService deptService;
        private readonly ISubUnitService subUnitService;
        public SubUnitsController(ISubUnitService subUnitService, IDeptService deptService)
        {
            this.deptService = deptService;
            this.subUnitService = subUnitService;
        }

        // GET: SubUnits
        public ActionResult Index()
        {
            var subUnit = subUnitService.GetAllSubUnit();
            return View(subUnit.ToList());
        }

        // GET: SubUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubUnit subUnit = subUnitService.GetSubUnit(id);
            if (subUnit == null)
            {
                return HttpNotFound();
            }
            return View(subUnit);
        }

        // GET: SubUnits/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name");
            return View();
        }

        // POST: SubUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DeptId")] SubUnit subUnit)
        {
            if (ModelState.IsValid)
            {
                subUnitService.CreateSubUnit(subUnit);
                subUnitService.SaveSubUnit();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name", subUnit.DeptId);
            return View(subUnit);
        }

        // GET: SubUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubUnit subUnit = subUnitService.GetSubUnit(id);
            if (subUnit == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name", subUnit.DeptId);
            return View(subUnit);
        }

        // POST: SubUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DeptId")] SubUnit subUnit)
        {
            if (ModelState.IsValid)
            {
                subUnitService.EditSubUnit(subUnit);
                subUnitService.SaveSubUnit();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name", subUnit.DeptId);
            return View(subUnit);
        }

        // GET: SubUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubUnit subUnit = subUnitService.GetSubUnit(id);
            if (subUnit == null)
            {
                return HttpNotFound();
            }
            return View(subUnit);
        }

        // POST: SubUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubUnit subUnit = subUnitService.GetSubUnit(id);
            subUnitService.DeleteSubUnit(subUnit);
            subUnitService.SaveSubUnit();
            return RedirectToAction("Index");
        }

    }
}
