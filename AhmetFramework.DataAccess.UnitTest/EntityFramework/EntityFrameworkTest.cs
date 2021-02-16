using AhmetFramework.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AhmetFramework.DataAccess.UnitTest.EntityFramework
{
  [TestClass]
  public class EntityFrameworkTest
  {
    [TestMethod]
    public void Get_all_return_all_product()
    {
      ProductRepository efProductDal = new ProductRepository();
      var result = efProductDal.GetAllAsync().Result.ToList();
      Assert.AreEqual(77, result.Count);
    }

    [TestMethod]
    public void Get_All_return_all_category()
    {

          CategoryRepository categoryRepository =new CategoryRepository();

          var result=categoryRepository.GetAllAsync().Result.ToList();
          Assert.AreEqual(8,result.Count);
      
    }

    [TestMethod]
    public void Get_All_return_all_Customers(){

        CustomerRepository customerRepository=new CustomerRepository();

        var result= customerRepository.GetAllAsync().Result.ToList();
        Assert.AreEqual(91,result.Count);


    }
  }
}
