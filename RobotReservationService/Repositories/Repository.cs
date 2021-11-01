using RobotReservationService.Data;
using RobotReservationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotReservationService.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : DbItem
    {

        public IDBProvider db;

        public Repository(IDBProvider db) {
            this.db = db;
        }
        
        public IList<T> All()
        {
            return db.GetAll<T>();
        }

        public T GetById(Guid id)
        {
            return db.GetAll<T>().FirstOrDefault(x => x.Id == id);
        }

        public bool Add(T item)
        {
            if (db.GetAll<T>().Any(i => item.Id == i.Id))
            {
                return false;
            }
            db.Create(item);
            return true;
        }

        public bool Update(T item)
        {
            if (!Delete(item.Id))
            {
                return false;
            }
            db.Create(item);
            return true;
        }

        public bool Delete(Guid id)
        {
            var foundItem = GetById(id);
            if (foundItem == default(T))
            {
                return false;
            }
            db.Delete<T>(foundItem.Id);
            return true;
        }
    }
}
