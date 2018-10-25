using CqrsExample.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class DepartmentsController : CustomController<Department>
    {
        private readonly IQuery<Employee> _employeeQuery;
        public DepartmentsController(IQuery<Department> query, ICommand<Department> command,
            IQuery<Employee> employeeQuery) : base(query, command)
        {
            _employeeQuery = employeeQuery;
        }


        [HttpGet]
        [Route("Department")]
        public new ActionResult Details(Guid Id)
        {
            var employees = _employeeQuery.GetAll().Where(e => e.DepartmentId == Id);
            ViewBag.workers = employees;
            ViewBag.IsEmpty = employees.Any() ? false : true;
            return View(_query.Get(Id));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depId">DepartmentId</param>
        /// <returns>PartialView list of employees</returns>
        public ActionResult _getEmployees(Guid depId)
        {
            var result = _employeeQuery.GetAll().Where(e => e.DepartmentId == depId);
            return PartialView("_employees", result);
        }
    }
}