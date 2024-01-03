using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrecture.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();


        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);

        void AddRange(IEnumerable<T> entities);

        Task RemoveAsync(T entity);
        void RemoveRange(IEnumerable<T> entities);

        Task<bool> UpdateAsync(T entity);
        Task<int> SaveAsync();
    }
}
