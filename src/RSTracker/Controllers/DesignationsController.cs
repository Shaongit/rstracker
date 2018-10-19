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
    public class DesignationsController : Controller
    {
        private readonly IDesignationService designationService;
        private readonly IDivisionService divisionService;
        public DesignationsController(IDesignationService designationService, IDivisionService divisionService)
        {
            this.designationService = designationService;
            this.divisionService = divisionService;
        }

        // GET: Designations
        public ActionResult Index()
        {
            var designation = designationService.GetAllDesignation();
            return View(designation.ToList());
        }

        // GET: Designations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = designationService.GetDesignation(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name");
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DivisionId")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                designationService.CreateDesignation(designation);
                designationService.SaveDesignation();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", designation.DivisionId);
            return View(designation);
        }

        // GET: Designations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = designationService.GetDesignation(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", designation.DivisionId);
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DivisionId")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                designationService.EditDesignation(designation);
                designationService.SaveDesignation();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", designation.DivisionId);
            return View(designation);
        }

        // GET: Designations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = designationService.GetDesignation(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designation designation = designationService.GetDesignation(id);
            designationService.DeleteDesignation(designation);
            designationService.SaveDesignation();
            return RedirectToAction("Index");
        }

    }
}
