using System.Collections.Generic;

namespace DriversApp.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
