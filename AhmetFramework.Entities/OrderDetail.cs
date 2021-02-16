using System;
using AhmetFramework.Core.Entities;

namespace AhmetFramework.Entities
{
    public class OrderDetail:IEntity
    {
        public int OrderId { get; set; }
        
        public int ProductId { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public Int16 Quantitiy { get; set; }
        
          
        
        

    
        
        
    }
}