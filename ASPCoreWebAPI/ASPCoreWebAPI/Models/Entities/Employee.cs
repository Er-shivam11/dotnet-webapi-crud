namespace ASPCoreWebAPI.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public Decimal Salary { get; set; }
    }
}
