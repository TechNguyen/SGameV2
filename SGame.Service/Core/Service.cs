using Microsoft.AspNetCore.Http;
using SGame.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SGame.Model.Core;
using SGame.Repository.Core;

namespace SGame.Service.Core
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        private readonly IHttpContextAccessor _contextAccessor;

        public Service(IRepository<T> repository, IHttpContextAccessor contextAccessor)
        {
            _repository = repository;
            _contextAccessor = contextAccessor;
        }
        public async Task Create(T entity)
        {
            entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
            var userId = _contextAccessor.HttpContext?.User.FindFirst("_userId")?.Value;
            var userName = _contextAccessor.HttpContext?.User.FindFirst("user")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                entity.GetType().GetProperty("CreatedID").SetValue(entity, userId);
            }
            if (!string.IsNullOrEmpty(userName))
            {
                entity.GetType().GetProperty("CreatedBy").SetValue(entity, userName);
            }
            _repository.Add(entity);
            await _repository.Save();
        }

        public async Task<T> CreateRe(T entity)
        {
            entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
            var userId = _contextAccessor.HttpContext?.User.FindFirst("_userId")?.Value;
            var userName = _contextAccessor.HttpContext?.User.FindFirst("user")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                entity.GetType().GetProperty("CreatedID").SetValue(entity, userId);
            }
            if (!string.IsNullOrEmpty(userName))
            {
                entity.GetType().GetProperty("CreatedBy").SetValue(entity, userName);
            }

            _repository.Add(entity);
            await _repository.Save();

            return entity;

        }
        public async Task Create(IEnumerable<T> entities)
        {
            //set default something
            foreach (var item in entities)
            {
                item.GetType().GetProperty("CreatedDate").SetValue(item, DateTime.Now);
                var userId = _contextAccessor.HttpContext?.User.FindFirst("_userId")?.Value;
                var userName = _contextAccessor.HttpContext?.User.FindFirst("user")?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    item.GetType().GetProperty("CreatedID").SetValue(item, userId);
                }
                if (!string.IsNullOrEmpty(userName))
                {
                    item.GetType().GetProperty("CreatedBy").SetValue(item, userName);
                }
            }
            _repository.AddRange(entities);
            await _repository.Save();

        }
        public async Task Delete(T entity)
        {
            _repository.Delete(entity);
            await _repository.Save();
        }

        public async Task Delete(IEnumerable<T> entities)
        {
            
            _repository.DeleteRange(entities);
            await _repository.Save();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public T? GetById(Guid? Id)
        {
            return _repository.GetById(Id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public async Task Update(T entity)
        {
            entity.GetType().GetProperty("UpdatedDate").SetValue(entity, DateTime.Now);
            var userId = _contextAccessor.HttpContext?.User.FindFirst("_userId")?.Value;
            var userName = _contextAccessor.HttpContext?.User.FindFirst("user")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                entity.GetType().GetProperty("UpdatedID").SetValue(entity, userId);
            }
            if (!string.IsNullOrEmpty(userName))
            {
                var updatedByProperty = entity.GetType().GetProperty("UpdatedBy");
                if (updatedByProperty != null)
                {
                    updatedByProperty.SetValue(entity, userName);
                }
            }
            _repository.Update(entity);
            await _repository.Save();
        }

        public async Task Update(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                item.GetType().GetProperty("UpdatedDate").SetValue(item, DateTime.Now);
                var userId = _contextAccessor.HttpContext?.User.FindFirst("_userId")?.Value;
                var userName = _contextAccessor.HttpContext?.User.FindFirst("user")?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    item.GetType().GetProperty("UpdatedID").SetValue(item, userId);
                }
                if (!string.IsNullOrEmpty(userName))
                {
                    item.GetType().GetProperty("UpdatedBy").SetValue(item, userName);
                }
            }
            _repository.Update(entities);
            await _repository.Save();
        }


        public async Task DeleteSoft(T entity)
        {
            entity.GetType().GetProperty("DeleteTime").SetValue(entity, DateTime.Now);
            var userId = _contextAccessor.HttpContext?.User.FindFirst("_userId")?.Value;
            var userName = _contextAccessor.HttpContext?.User.FindFirst("user")?.Value;


            if (!string.IsNullOrEmpty(userId))
            {
                entity.GetType().GetProperty("DeleteId").SetValue(entity, userId);
            }

            if (!string.IsNullOrEmpty(userName))
            {
                entity.GetType().GetProperty("DeleteBy").SetValue(entity, userName);
            }
            _repository.Update(entity);
            await _repository.Save();   
        }


        public async Task DeleteSoft(IEnumerable<T> entity)
        {
            foreach (var item in entity)
            {
                item.GetType().GetProperty("DeleteTime").SetValue(item, DateTime.Now);
                var userId = _contextAccessor.HttpContext?.User.FindFirst("_userId")?.Value;
                var userName = _contextAccessor.HttpContext?.User.FindFirst("user")?.Value;


                if (!string.IsNullOrEmpty(userId))
                {
                    item.GetType().GetProperty("DeleteId").SetValue(item, userId);
                }

                if (!string.IsNullOrEmpty(userName))
                {
                    item.GetType().GetProperty("DeleteBy").SetValue(item, userName);
                }
                _repository.Update(item);
                await _repository.Save();
            }
          
        }

    }
}
