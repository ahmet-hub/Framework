using AhmetFramework.Core.DataAccess.EntityFramework;
using AhmetFramework.DataAccess.Abstract;
using AhmetFramework.Entities;
using AhmetFramework.Entities.ComplexType;
using System.Collections.Generic;
using System.Linq;

namespace AhmetFramework.DataAccess.Concrete.EntityFramework
{
  public class ProductRepository : EfEntityRepositoryBase<Product, NorthwindContext>, IProductRepository
  {
    public List<ProductDetail> ProductDetails()
    {
     
     using (var context=new NorthwindContext())
     {
        var result = from p in context.Products
        join c in context.Categories on p.CategoryId equals c.CategoryId
        select new ProductDetail {
          ProductId =p.ProductId,
          ProductName=p.ProductName,
          CategoryName=c.CategoryName
        };
        return result.ToList();
         
     }

    }
  }
}
