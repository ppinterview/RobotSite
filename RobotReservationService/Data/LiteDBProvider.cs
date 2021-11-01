using RobotReservationService.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RobotReservationService.Data
{
    public class LiteDBProvider : IDBProvider
    {

        private LiteRepository GetRepository()
        {
            return new LiteRepository("RobotReservationService.db");
        }

        public IList<T> GetAll<T>()
        {
            return GetRepository().Query<T>().ToList();
        }

        public IList<T> Find<T>(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            return GetRepository().Fetch(predicate, collectionName);
        }

        public T Get<T>(Guid id) where T : DbItem
        {
            return GetAll<T>().FirstOrDefault<T>(x => x.Id == id);
        }

        public void Update<T>(T item) where T : DbItem
        {
            GetRepository().Update(item);
        }

        public void Create<T>(T item) where T : DbItem
        {
            GetRepository().Insert(item);
        }

        public void Delete<T>(Guid id) where T : DbItem
        {
            GetRepository().Delete<T>(x => x.Id == id);
        }
    }
}
