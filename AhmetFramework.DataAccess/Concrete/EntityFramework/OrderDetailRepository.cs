using AhmetFramework.Core.DataAccess.EntityFramework;
using AhmetFramework.DataAccess.Abstract;
using AhmetFramework.Entities;

namespace AhmetFramework.DataAccess.Concrete.EntityFramework
{
    public class OrderDetailRepository:EfEntityRepositoryBase<Order,NorthwindContext>, IOrderRepository
    {
        
    }
}