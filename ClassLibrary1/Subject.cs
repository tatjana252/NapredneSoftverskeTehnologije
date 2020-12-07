using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Domain
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<SubjectItem> Items { get; set; }
        public List<StudentSubject> Students { get; set; }
    }
}
