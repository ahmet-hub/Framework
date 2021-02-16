using AhmetFramework.Core.DataAccess.EntityFramework;
using AhmetFramework.DataAccess.Abstract;
using AhmetFramework.Entities;

namespace AhmetFramework.DataAccess.Concrete.EntityFramework
{
    public class OrderRepository:EfEntityRepositoryBase<Order,NorthwindContext>,IOrderRepository
    {
        
    }
}