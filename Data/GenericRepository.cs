using Departments.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Departments.Data
{
    //ovaj GenericRepository radi sa EntityFrameworkom
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        //da bi metode mogle da se overriduju mora da se stavi virtual!
        public virtual void Add(T t)
        {
            _context.Add(t);
        }

        public virtual void Delete(T t)
        {
            _context.Remove(t);
        }

        public virtual T FindById(T t)
        {
            //id je specifican za svaku klasu tako da svaki repozitorijum mora da implementira ovu metodu, da je uvek int onda moze i da se prosledi int

            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public virtual void Update(T t)
        {
            _context.Update(t);
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> pred)
        {
            return _context.Set<T>().Where(pred);
        }

    }
}
