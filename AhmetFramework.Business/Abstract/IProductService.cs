using AhmetFramework.Core.Business;
using AhmetFramework.Entities;

namespace AhmetFramework.Business.Abstract
{
    public interface IProductService:IService<Product>
    {
    public void TransactionOperation(Product updateProduct, Product addedProduct);
    }
}
