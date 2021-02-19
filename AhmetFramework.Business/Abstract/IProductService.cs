using AhmetFramework.Core.Business;
using AhmetFramework.Core.Utilities.Results;
using AhmetFramework.Entities;
using AhmetFramework.Entities.ComplexType;
using System.Collections.Generic;

namespace AhmetFramework.Business.Abstract
{
  public interface IProductService : IService<Product>
  {
    public void TransactionOperation(Product updateProduct, Product addedProduct);
    public IDataResult<IEnumerable<ProductDetail>> GetProductWithCategories();

  }
}
