
using Infrastrecture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrecture.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DBcontexAppt dbcontext;
        public GenericRepository(DBcontexAppt dbcontext)
        {
            this.dbcontext = dbcontext;
            
        }
        public void Add(T entity)
        {
            dbcontext.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            dbcontext.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbcontext.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return dbcontext.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return dbcontext.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            dbcontext.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbcontext.Set<T>().RemoveRange(entities);
        }
     
        public void Save(T entity)
        {
            dbcontext.SaveChanges();
        }
    }
}
