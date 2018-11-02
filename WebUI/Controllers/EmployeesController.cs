using CqrsExample.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class EmployeesController : CustomController<Employee>
    {
        private IQuery<Department> _departmentQuery;

        public EmployeesController(
            IQuery<Employee> employeeQuery, ICommand<Employee> employeeCommand,
            IQuery<Department> departmentQuery
            ) : base(employeeQuery, employeeCommand)
        {
            _departmentQuery = departmentQuery;
        }

        [HttpGet]
        [Route("Employee/Create")]
        public ActionResult Create(Guid? id)
        {
            if (id != null)
            {
                ViewBag.DepName = _departmentQuery.Get(id.Value).Name;
                var model = new Employee { DepartmentId = id.Value };
                return View(model);
            }
            return RedirectToAction("Index", "Departments");
        }

        [HttpPost]
        [Route("Employee/Create")]
        public new ActionResult Create(Employee empl)
        {
            ViewBag.DepartmentId = new SelectList(_departmentQuery.GetAll(), "Id", "Name");
            if (ModelState.IsValid)
            {
                empl.Id = Guid.NewGuid();
                _command.Create(empl);
                return RedirectToAction("Index", "Departments");
            }
            return View(empl);
        }
        
        [HttpGet]
        [Route("Employee/Edit")]
        public new ActionResult Edit(Guid Id)
        {
            var result = _query.Get(Id);
            if (result != null)
            {
                ViewBag.DepartmentId = new SelectList(_departmentQuery.GetAll(), "Id", "Name", result.DepartmentId);
                return View(result);
            }
            return RedirectToAction("Index", "Departments");
        }

        [HttpPost]
        [Route("Employee/Edit")]
        public new ActionResult Edit(Employee empl)
        {
            if (ModelState.IsValid)
            {
                _command.Update(empl);
                return RedirectToAction("Index", "Departments");
            }
            ViewBag.DepartmentId = new SelectList(_departmentQuery.GetAll(), "Id", "Name", empl.DepartmentId);
            return View(empl);
        }

        [Route("Employee")]
        public new ActionResult Details(Guid Id)
        {
            var result = _query.Get(Id);
            result.Department = _departmentQuery.Get(result.DepartmentId.Value);
            return View(result);
        }
    }
}