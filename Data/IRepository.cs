using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Departments.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        T FindById(T t);
        IEnumerable<T> Where(Expression<Func<T, bool>> pred);

    }
}
