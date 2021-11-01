using System;
using System.Collections.Generic;

namespace RobotReservationService.Models
{
    public abstract class DbItem
    {
        public Guid Id { get; set; }
    }
}
