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
using HSTrackerService.Interface;
using HSTrackerModel.Models;

namespace RSTracker.Controllers
{
    [Authorize()]
    public class RequisitionsController : Controller
    {
        private readonly IRequisitionService requisitionService;
        private readonly IEmployeeService employeeService;
        private readonly ISubUnitService subUnitService;
        private readonly IDivisionService divisionService;
        private readonly IDesignationService designationService;
        private readonly IDeptService deptService;
        private readonly IStatusService statusService;
        public RequisitionsController(
            IRequisitionService requisitionService,
            IEmployeeService employeeService,
            ISubUnitService subUnitService,
            IDivisionService divisionService,
            IDesignationService designationService,
            IDeptService deptService,
            IStatusService statusService
            )
        {
            this.requisitionService = requisitionService;
            this.employeeService = employeeService;
            this.subUnitService = subUnitService;
            this.divisionService = divisionService;
            this.designationService = designationService;
            this.deptService = deptService;
            this.statusService = statusService;
        }
        // GET: Requisitions
        public ActionResult Index()
        {
            //var requisitions = db.Requisitions.Include(r => r.Dept).Include(r => r.Designation).Include(r => r.Division).Include(r => r.RequiredByEmp).Include(r => r.Employee).Include(r => r.Status).Include(r => r.SubUnit);
            var requisitions = requisitionService.GetAllRequisition();
            return View(requisitions.Where(p=>p.StatusId != 3).OrderBy(p=>p.RequisitionDate).ToList());
        }

        // GET: Requisitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Requisition requisition = requisitionService.GetRequisition(id);
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
            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name");
            ViewBag.Position = new SelectList(designationService.GetAllDesignation(), "Id", "Name");
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name");
            ViewBag.RequiredBy = new SelectList(employeeService.GetAllEmployee(), "Id", "Name");
            ViewBag.RaisedBy = new SelectList(employeeService.GetAllEmployee(), "Id", "Name");
            ViewBag.StatusId = new SelectList(statusService.GetAllStatus(), "Id", "Name");
            ViewBag.SubUnitId = new SelectList(subUnitService.GetAllSubUnit(), "Id", "Name");

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
                requisitionService.CreateRequisition(requisition);
                requisitionService.SaveRequisition();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name", requisition.Dept);
            ViewBag.Position = new SelectList(designationService.GetAllDesignation(), "Id", "Name", requisition.PositionId);
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", requisition.Division);
            ViewBag.RequiredBy = new SelectList(employeeService.GetAllEmployee(), "Id", "Name", requisition.RequiredBy);
            ViewBag.RaisedBy = new SelectList(employeeService.GetAllEmployee(), "Id", "Name", requisition.RaisedBy);
            ViewBag.StatusId = new SelectList(statusService.GetAllStatus(), "Id", "Name", requisition.Status);
            ViewBag.SubUnitId = new SelectList(subUnitService.GetAllSubUnit(), "Id", "Name", requisition.SubUnit);

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
            Requisition requisition = requisitionService.GetRequisition(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name", requisition.Dept);
            ViewBag.PositionId = new SelectList(designationService.GetAllDesignation(), "Id", "Name", requisition.PositionId);
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", requisition.Division);
            ViewBag.RequiredBy = new SelectList(employeeService.GetAllEmployee(), "Id", "Name", requisition.RequiredBy);
            ViewBag.RaisedBy = new SelectList(employeeService.GetAllEmployee(), "Id", "Name", requisition.RaisedBy);
            ViewBag.StatusId = new SelectList(statusService.GetAllStatus(), "Id", "Name", requisition.Status);
            ViewBag.SubUnitId = new SelectList(subUnitService.GetAllSubUnit(), "Id", "Name", requisition.SubUnit);

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
                requisitionService.EditRequisition(requisition);
                requisitionService.SaveRequisition();
                return RedirectToAction("Index");
            }
            ViewBag.Dept = new SelectList(deptService.GetAllDept(), "Id", "Name", requisition.Dept);
            ViewBag.Position = new SelectList(designationService.GetAllDesignation(), "Id", "Name", requisition.PositionId);
            ViewBag.Division = new SelectList(divisionService.GetAllDivision(), "Id", "Name", requisition.Division);
            ViewBag.RequiredBy = new SelectList(employeeService.GetAllEmployee(), "Id", "Name", requisition.RequiredBy);
            ViewBag.RaisedBy = new SelectList(employeeService.GetAllEmployee(), "Id", "Name", requisition.RaisedBy);
            ViewBag.Status = new SelectList(statusService.GetAllStatus(), "Id", "Name", requisition.Status);
            ViewBag.SubUnit = new SelectList(subUnitService.GetAllSubUnit(), "Id", "Name", requisition.SubUnit);

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
            Requisition requisition = requisitionService.GetRequisition(id);
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
            Requisition requisition = requisitionService.GetRequisition(id);
            requisitionService.DeleteRequisition(requisition);
            requisitionService.SaveRequisition();
            return RedirectToAction("Index");
        }

    }
}
