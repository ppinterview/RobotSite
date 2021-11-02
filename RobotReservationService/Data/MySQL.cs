using RobotReservationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RobotReservationService.Data
{
    public class MySQL : IDBProvider
    {
        public void Create<T>(T item) where T : DbItem
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(Guid id) where T : DbItem
        {
            throw new NotImplementedException();
        }

        public IList<T> Find<T>(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id) where T : DbItem
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T item) where T : DbItem
        {
            throw new NotImplementedException();
        }
    }
}
