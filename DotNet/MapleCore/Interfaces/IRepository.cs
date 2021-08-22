using MapleCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapleCore.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(Guid id) where T : BaseEntity;
        IQueryable<T> GetQuery<T>() where T : BaseEntity;
        List<T> List<T>(Func<T, bool> predicate) where T : BaseEntity;
        void Add<T>(T entity, bool comit = true) where T : BaseEntity;
        void Update<T>(T entity, bool comit = true) where T : BaseEntity;
        void Delete<T>(T entity, bool comit = true) where T : BaseEntity;
        void SaveChanges();
    }
}
