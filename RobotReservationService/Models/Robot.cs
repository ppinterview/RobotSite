namespace RobotReservationService.Models
{
    public class Robot : DbItem
    {
        public string Name { get; set; }
        public string RobotType { get; set; }
        public string Description { get; set; }
    }
}
