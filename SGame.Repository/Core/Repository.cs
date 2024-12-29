using Microsoft.EntityFrameworkCore;
using SGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SGameContext _context;
        private DbSet<T> _dbSet;

        public Repository(SGameContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }


        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }      

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {

                var idProperty = typeof(T).GetProperty("Id");
                if (idProperty == null)
                {
                    throw new InvalidOperationException("Entity does not have an Id property.");
                }
                var entityId = idProperty.GetValue(entity);
                var localEntity = _dbSet.Local.FirstOrDefault(e => idProperty.GetValue(e) == entityId);
                if (localEntity != null)
                {
                    _dbSet.Remove(localEntity);
                }
                else
                {
                    _dbSet.Attach(entity);
                }
            }

            _dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }
        
        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public T? GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();

        }

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }
        public void Update(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
