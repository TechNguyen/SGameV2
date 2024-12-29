using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.Core
{
    public interface IService<T> where T : class
    {
        Task Create(T entity);
        Task Create(IEnumerable<T> entities);
        Task<T> CreateRe(T entity);
        Task Delete(T entity);
        Task Delete(IEnumerable<T> entities);
        Task DeleteSoft(T entity);
        Task DeleteSoft(IEnumerable<T> entity);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T? GetById(Guid? Id);
        IQueryable<T> GetQueryable();
        Task Update(T entity);
        Task Update(IEnumerable<T> entities);
    }
}
