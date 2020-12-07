using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Departments.Domain
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="Naziv je obavezno polje!")]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
