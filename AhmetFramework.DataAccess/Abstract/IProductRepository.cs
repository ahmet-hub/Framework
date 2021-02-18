using AhmetFramework.Core.DataAccess;
using AhmetFramework.Entities;
using AhmetFramework.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.DataAccess.Abstract
{
  public interface IProductRepository : IEntityRepository<Product>
  {
      public List<ProductDetail> ProductDetails();
  }
}
