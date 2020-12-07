using Departments.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Data.Implementation
{
    public class RepositorySubject : GenericRepository<Subject>, IRepositorySubject
    {
        public RepositorySubject(DbContext context) : base(context)
        {

        }

        public override Subject FindById(Subject t)
        {
            return _context.Set<Subject>().Find(t.SubjectId);
        }

    }
}
