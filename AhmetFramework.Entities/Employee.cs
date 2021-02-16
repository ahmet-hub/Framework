using AhmetFramework.Core.Entities;

namespace AhmetFramework.Entities
{
    public class Employee:IEntity
    {
        public int EmployeeId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Title { get; set; }
        
        public string Adress { get; set; }
        
        public string City { get; set; }              
        
    }
}