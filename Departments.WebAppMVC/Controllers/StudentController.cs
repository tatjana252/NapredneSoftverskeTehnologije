using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Departments.Data.UnitOfWork;
using Departments.Domain;
using Departments.Dtos;
using Departments.Services;
using Departments.WebAppMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Departments.WebAppMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IStudentService service;

        public StudentController(IUnitOfWork uow, IStudentService service)
        {
            this.uow = uow;
            this.service = service;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            IEnumerable<Student> model = uow.Students.GetAll();
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            StudentViewModel model = new StudentViewModel();
            IEnumerable<Subject> subjects = uow.Subjects.GetAll();
            model.Subjects = subjects.Select(s => new SelectListItem { Text = s.Name, Value = s.SubjectId.ToString() }).ToList();
            return View("CreateStudent", model);
        }

        [HttpGet]
        public ActionResult AddSubject([FromQuery]int num, [FromQuery]int subjectId)
        {
            Subject subject = uow.Subjects.FindById(new Subject { SubjectId = subjectId });
            SubjectPartialViewModel viewModel = new SubjectPartialViewModel
            {
                Num = num,
                SubjectId = subject.SubjectId,
                Name = subject.Name
            };
            return PartialView("SubjectPartial", viewModel);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm, Bind(Prefix = "Student")]StudentDto student)
        {
            try
            {
                //validacija
                //uow.Students.Add(student);
                //uow.Commit();

                service.Save(student);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
                return Create();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
