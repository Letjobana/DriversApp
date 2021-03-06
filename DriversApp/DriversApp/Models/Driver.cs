namespace DriversApp.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Requirement { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
