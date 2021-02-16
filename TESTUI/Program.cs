using AhmetFramework.DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;

namespace TESTUI
{
  class Program
  {
    static void Main(string[] args)
    {
      ProductRepository efProductDal = new ProductRepository();
      var result = efProductDal.GetAllAsync().Result.ToList();
      Console.WriteLine(result.Count);
      var data=efProductDal.ProductDetails();
      
      //foreach (var item in data)
      //{
      //  Console.WriteLine(item.ProductName+"---" +item.CategoryName);

      //}
    }
  }
}
