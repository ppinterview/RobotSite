using RobotReservationService.Data;
using RobotReservationService.Models;

namespace RobotReservationService.Repositories
{
    internal class RobotRepository : Repository<Robot>, IRobotRepository
    {
        public RobotRepository(IDBProvider db) : base(db) { }
    }
}
