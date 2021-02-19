using AhmetFramework.Core.Entities;

namespace AhmetFramework.Entities
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }
        
        public string Description { get; set; }       
        
    }
}
