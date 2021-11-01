using RobotReservationService.Data;
using RobotReservationService.Models;

namespace RobotReservationService.Repositories
{
    internal class UserReferenceRepository : Repository<UserReference>, IUserReferenceRepository
    {
        public UserReferenceRepository(IDBProvider db) : base(db) { }
    }
}
