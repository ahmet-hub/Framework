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
  public class CustomerManager : ICustomerService
  {
    private ICustomerRepository _customerRepository;

    public CustomerManager(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    [ValidationAspect(typeof(CustomerValidatior))]
    public async Task<IDataResult<Customer>> AddAsync(Customer entity)
    {
      return new SuccessDataResult<Customer>(await _customerRepository.AddAsync(entity), "Musteri Eklendi");
    }
   
    public async Task<IResult> DeleteAsync(Customer entity)
    {
      await _customerRepository.DeleteAsync(entity);
      return new SuccessResult("Musteri Silindi");
    }

    public async Task<IDataResult<IEnumerable<Customer>>> GetAllAsync(Expression<Func<Customer, bool>> filter = null)
    {
      return new SuccessDataResult<IEnumerable<Customer>>(await _customerRepository.GetAllAsync(filter), "Musteriler Listelendi");
    }
    
    public async Task<IDataResult<Customer>> GetAsync(Expression<Func<Customer, bool>> filter)
    {
      return new SuccessDataResult<Customer>(await _customerRepository.GetAsync(filter), "Musteri Listelendi");
    }
    [ValidationAspect(typeof(CustomerValidatior))]
    public async Task<IDataResult<Customer>> UpdateAsync(Customer entity)
    {
      return new SuccessDataResult<Customer>(await _customerRepository.UpdateAsync(entity), "Musteri Guncellendi");
    }
  }
}
