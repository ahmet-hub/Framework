using AhmetFramework.Business.Abstract;
using AhmetFramework.Business.ValidationRules.FluentValidation;
using AhmetFramework.Core.Aspects.Autofac.Validation;
using AhmetFramework.Core.Utilities.Results;
using AhmetFramework.DataAccess.Abstract;
using AhmetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AhmetFramework.Business.Concrete.Manager
{
  public class CategoryManager : ICategoryService
  {
    private ICategoryRepository _categoryRepository;
    public CategoryManager(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;

    }
    [ValidationAspect(typeof(CategoryValidatior))]
    public async Task<IDataResult<Category>> AddAsync(Category entity)
    {
      return new SuccessDataResult<Category>(await _categoryRepository.AddAsync(entity), "Kategori Eklendi");
    }
  
    public async Task<IResult> DeleteAsync(Category entity)
    {
      await _categoryRepository.DeleteAsync(entity);
      return new SuccessDataResult<Category>("Categori Silindi");
    }
     
    public async Task<IDataResult<IEnumerable<Category>>> GetAllAsync(Expression<Func<Category, bool>> filter = null)
    {
      return new SuccessDataResult<IEnumerable<Category>>(await _categoryRepository.GetAllAsync(), "Kategoriler Listelendi");
    }
   
    public async Task<IDataResult<Category>> GetAsync(Expression<Func<Category, bool>> filter)
    {
      return new SuccessDataResult<Category>(await _categoryRepository.GetAsync(filter), "Kategori Listelendi");
    }
    [ValidationAspect(typeof(CategoryValidatior))]
    public async Task<IDataResult<Category>> UpdateAsync(Category entity)
    {
      return new SuccessDataResult<Category>(await _categoryRepository.UpdateAsync(entity), "Kategori Guncellendi");
    }
  }
}
