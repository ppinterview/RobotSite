using RobotReservationService.Models;
using System;
using System.Collections.Generic;

namespace RobotReservationService.Repositories
{
    public interface IRepository<T> where T : DbItem
    {
        IList<T> All();
        T GetById(Guid id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(Guid id);
    }
}