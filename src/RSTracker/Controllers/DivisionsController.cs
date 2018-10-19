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
    public class DivisionsController : Controller
    {
        private readonly IDivisionService divisionService;
        public DivisionsController(IDivisionService divisionService)
        {
            this.divisionService = divisionService;
        }
        // GET: Divisions
        public ActionResult Index()
        {
            return View(divisionService.GetAllDivision());
        }

        // GET: Divisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = divisionService.GetDivision(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // GET: Divisions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Division division)
        {
            if (ModelState.IsValid)
            {
                divisionService.CreateDivision(division);
                divisionService.SaveDivision();
                return RedirectToAction("Index");
            }

            return View(division);
        }

        // GET: Divisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = divisionService.GetDivision(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Division division)
        {
            if (ModelState.IsValid)
            {
                divisionService.EditDivision(division);
                divisionService.SaveDivision();
                return RedirectToAction("Index");
            }
            return View(division);
        }

        // GET: Divisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = divisionService.GetDivision(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Division division = divisionService.GetDivision(id);
            divisionService.DeleteDivision(division);
            divisionService.SaveDivision();
            return RedirectToAction("Index");
        }

    }
}
