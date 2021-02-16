using System;
using AhmetFramework.Core.Entities;

namespace AhmetFramework.Entities
{
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        public DateTime RequiredDate { get; set; }
        
        public DateTime ShippedDate { get; set; }
        
        public int ShipVia { get; set; }
        
        public decimal Freight { get; set; }
        
        public string ShipName { get; set; }
        
        public string ShipAddress { get; set; }
        
        public string ShipCity {get;set;}                                                                                                                                                          

        
    }
}