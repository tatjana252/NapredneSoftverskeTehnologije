using Departments.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Data.Implementation
{
    public class RepositoryDepartment : GenericRepository<Department>, IRepositoryDepartment
    {
        public RepositoryDepartment(DbContext context) : base(context)
        {
        }

        public override Department FindById(Department t)
        {
            return _context.Set<Department>().Find(t.DepartmentId);
        }
    }
}
