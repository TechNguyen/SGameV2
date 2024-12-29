using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.Core
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Attach(T entity);
        T Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T? GetById(object id);
        IQueryable<T> GetQueryable();
        Task Save();
        T Update(T entity);
        void Update(IEnumerable<T> entities);
    }
}
