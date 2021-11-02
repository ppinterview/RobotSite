using RobotReservationService.Data;
using RobotReservationService.Models;

namespace RobotReservationService.Repositories
{
    internal class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(IDBProvider db) : base(db) { }
    }
}
