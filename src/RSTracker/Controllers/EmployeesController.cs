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
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ISubUnitService subUnitService;
        private readonly IDivisionService divisionService;
        private readonly IDesignationService designationService;
        private readonly IDeptService deptService;
        public EmployeesController(
            IEmployeeService employeeService,
            ISubUnitService subUnitService,
            IDivisionService divisionService,
            IDesignationService designationService,
            IDeptService deptService
            )
        {
            this.employeeService = employeeService;
            this.subUnitService = subUnitService;
            this.divisionService = divisionService;
            this.designationService = designationService;
            this.deptService = deptService;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employee = employeeService.GetAllEmployee();
            return View(employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(designationService.GetAllDesignation(), "Id", "Name");
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name");
            ViewBag.SubUnitId = new SelectList(subUnitService.GetAllSubUnit(), "Id", "Name");
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
                employeeService.CreateEmployee(employee);
                employeeService.SaveEmployee();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(designationService.GetAllDesignation(), "Id", "Name");
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name");
            ViewBag.SubUnitId = new SelectList(subUnitService.GetAllSubUnit(), "Id", "Name");
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(designationService.GetAllDesignation(), "Id", "Name");
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name");
            ViewBag.SubUnitId = new SelectList(subUnitService.GetAllSubUnit(), "Id", "Name");
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
                employeeService.EditEmployee(employee);
                employeeService.SaveEmployee();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(deptService.GetAllDept(), "Id", "Name", employee.DeptId);
            ViewBag.DesignationId = new SelectList(designationService.GetAllDesignation(), "Id", "Name", employee.DesignationId);
            ViewBag.DivisionId = new SelectList(divisionService.GetAllDivision(), "Id", "Name", employee.DivisionId);
            ViewBag.SubUnitId = new SelectList(subUnitService.GetAllSubUnit(), "Id", "Name", employee.SubUnitId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeService.GetEmployee(id);
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
            Employee employee = employeeService.GetEmployee(id);
            employeeService.DeleteEmployee(employee);
            employeeService.SaveEmployee();
            return RedirectToAction("Index");
        }

    }
}
