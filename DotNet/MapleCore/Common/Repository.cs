using MapleCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapleCore.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(Guid id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public void Add<T>(T entity, bool comit = false) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            if (comit)
                _dbContext.SaveChanges();

        }

        public void Delete<T>(T entity, bool comit = false) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            if (comit)
                _dbContext.SaveChanges();
        }

        public void Update<T>(T entity, bool comit = false) where T : BaseEntity
        {
            var change = _dbContext.Entry(entity);
            change.State = EntityState.Modified;
            if (comit)
                _dbContext.SaveChanges();
        }

        public List<T> List<T>(Func<T, bool> predicate) where T : BaseEntity
        {
            if (predicate == null)
                throw new Exception("Cannot return all values, predecate must be set");

            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public IQueryable<T> GetQuery<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>();
        }

         public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
