using AhmetFramework.Business.Concrete.Manager;
using AhmetFramework.DataAccess.Concrete.EntityFramework;
using AhmetFramework.Entities;
using System;
using System.Linq;

namespace TESTUI
{
  class Program
  {
    static  void Main(string[] args)
    {

      ProductManager productManager = new ProductManager(new ProductRepository());
      //var data=productManager.AddAsync(new Product { CategoryId=1});
      //var sounc= data.Result;

      var data = productManager.AddAsync(new Product { CategoryId = 1 });
      var sonuc=data.Result;
    }
  }
}
