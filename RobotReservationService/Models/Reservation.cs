using System;
using System.ComponentModel.DataAnnotations;

namespace RobotReservationService.Models
{
    public class Reservation : DbItem
    {
        [Required]
        [StringLength(10)]
        public string Username { get; set; }
        [StringLength(10)]
        public string RobotName { get; set; }
        [Required]
        public DateTime StartTime { get; set; }


        [Required]
        public DateTime EndTime { get; set; }

        public bool Paid { get; set; }
    }
}
