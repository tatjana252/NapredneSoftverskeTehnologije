using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Domain
{
    public class SubjectItem
    {
        public int SubjectItemId { get; set; }
        public string Name { get; set; }

        public Content Content { get; set; }
    }
}
