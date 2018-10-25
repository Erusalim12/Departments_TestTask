using CqrsExample.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public abstract class CustomController<T> : Controller where T : class
    {
        protected readonly IQuery<T> _query;
        protected readonly ICommand<T> _command;
        public CustomController(IQuery<T> query, ICommand<T> command)
        {
            _query = query;
            _command = command;
        }
        // GET: Departments
        public ActionResult Index()
        {
            return View(_query.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(T item)
        {
            if (ModelState.IsValid)
            {
                _command.Create(item);
                return RedirectToAction("Index", "Departments");
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var result = _query.Get(id);
            if (result != null) return View(result);
            return RedirectToAction("Index", "Departments");

        }

        [HttpPost]
        public ActionResult Edit(T item)
        {
            if (ModelState.IsValid)
            {
                _command.Update(item);
                return RedirectToAction("Index", "Departments");
            }
            return View(item);
        }

        public ActionResult Delete(Guid id)
        {
            var result = _query.Get(id);
            if (result != null) _command.Delete(id);
            return RedirectToAction("Index", "Departments");
        }

        public virtual ActionResult Details(Guid Id)
        {
            var result = _query.Get(Id);
            return View(result);
        }


    }
}