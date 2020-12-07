using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Departments.Data.UnitOfWork;
using Departments.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Departments.WebAppMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork uow;

        public DepartmentController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Departments ASP.NET MVC Core";
            ViewData["Title"] = "Departments ASP.NET MVC Core";
            List<Department> model = uow.Departments.GetAll().ToList();
            return View(model);
        }

        [ActionName("Create")]
        public ActionResult CreateDepartment()
        {
            return View("CreateDepartment");
        }

        [HttpPost]
        public ActionResult CreateDepartment([FromForm]Department department)
        {
            //if (string.IsNullOrWhiteSpace(department.Name))
            //{
            //    return View();
            //}

            //ModelState.AddModelError("Error", "Error! Create Department!");
            //return View();

            if (!ModelState.IsValid)
            {
                return View();
            }
            uow.Departments.Add(department);
            uow.Commit();
            return RedirectToAction("Index");
        }

    }
}
