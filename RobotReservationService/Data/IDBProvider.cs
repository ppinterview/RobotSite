using RobotReservationService.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RobotReservationService.Data
{
    public interface IDBProvider
    {
        void Create<T>(T item) where T : DbItem;
        void Delete<T>(Guid id) where T : DbItem;
        IList<T> Find<T>(Expression<Func<T, bool>> predicate, string collectionName = null);
        T Get<T>(Guid id) where T : DbItem;
        IList<T> GetAll<T>();
        void Update<T>(T item) where T : DbItem;
    }
}