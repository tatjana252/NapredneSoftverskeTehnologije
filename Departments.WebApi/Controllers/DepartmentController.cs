using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Departments.Data.UnitOfWork;
using Departments.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Departments.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        //trebalo bi koristiti IDepartmentService
        public DepartmentController(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return uow.Departments.GetAll();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Department d = uow.Departments.FindById(new Department { DepartmentId = id });
            if(d == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] Department department)
        {
            uow.Departments.Add(department);
            uow.Commit();
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
