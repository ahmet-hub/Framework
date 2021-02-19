using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AhmetFramework.Business.Abstract;
using AhmetFramework.Business.ValidationRules.FluentValidation;
using AhmetFramework.Core.Aspects.Autofac.Validation;
using AhmetFramework.Core.Business;
using AhmetFramework.Core.Utilities.Results;
using AhmetFramework.DataAccess.Abstract;
using AhmetFramework.Entities;
using AhmetFramework.Entities.ComplexType;

namespace AhmetFramework.Business.Concrete.Manager
{
  public class ProductManager : IProductService
  {
    private IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
      _productRepository = productRepository;

    }

    [ValidationAspect(typeof(ProductValidatior))]
    public async Task<IDataResult<Product>> AddAsync(Product entity)
    {
      return new SuccessDataResult<Product>(await _productRepository.AddAsync(entity), "Urun Eklendi");
    }

    public async Task<IResult> DeleteAsync(Product entity)
    {
      await _productRepository.DeleteAsync(entity);
      return new SuccessResult("Urun Silindi");
    }
   
    public async Task<IDataResult<IEnumerable<Product>>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
    {

      var result = new SuccessDataResult<IEnumerable<Product>>(await _productRepository.GetAllAsync(filter), "Urunler Listelendi");
      return result;
    }

    public async Task<IDataResult<Product>> GetAsync(Expression<Func<Product, bool>> filter)
    {
      return new SuccessDataResult<Product>(await _productRepository.GetAsync(filter), "Urun Listelendi");
    }

    public IDataResult<IEnumerable<ProductDetail>> GetProductWithCategories()
    {
      return new SuccessDataResult<IEnumerable<ProductDetail>>(_productRepository.ProductDetails());
    }

    public void TransactionOperation(Product updateProduct, Product addedProduct)
    {
      _productRepository.UpdateAsync(updateProduct);
      _productRepository.AddAsync(addedProduct);
    }
    [ValidationAspect(typeof(ProductValidatior))]
    public async Task<IDataResult<Product>> UpdateAsync(Product entity)
    {
      
      return new SuccessDataResult<Product>(await _productRepository.UpdateAsync(entity), "Urun Guncellendi");

    }

 
  }
}
