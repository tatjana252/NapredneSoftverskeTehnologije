using Departments.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departments.WebAppMVC.Models
{
    public class StudentViewModel
    {
        public Student Student { get; set; }

        public List<SelectListItem> Subjects { get; set; }
    }
}
