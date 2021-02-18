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
  public class EmployeeManager : IEmployeeService
  {
    IEmployeeRepository _employeeRepository;

    public EmployeeManager(IEmployeeRepository employeeRepository)
    {
      _employeeRepository = employeeRepository;
    }
    [ValidationAspect(typeof(EmployeeValidatior))]
    public async Task<IDataResult<Employee>> AddAsync(Employee entity)
    {
      return new SuccessDataResult<Employee>(await _employeeRepository.AddAsync(entity), "Calisan Eklendi");
    }
    
    public async Task<IResult> DeleteAsync(Employee entity)
    {
      await _employeeRepository.DeleteAsync(entity);
      return new SuccessResult("Calisan Silindi");
    }
  
    public async Task<IDataResult<IEnumerable<Employee>>> GetAllAsync(Expression<Func<Employee, bool>> filter = null)
    {
      return new SuccessDataResult<IEnumerable<Employee>>(await _employeeRepository.GetAllAsync(filter), "Calisanlar Listelendi");
    }
   
    public async Task<IDataResult<Employee>> GetAsync(Expression<Func<Employee, bool>> filter)
    {
      return new SuccessDataResult<Employee>(await _employeeRepository.GetAsync(filter), "Calisan Listelendi");
    }
    [ValidationAspect(typeof(EmployeeValidatior))]
    public async Task<IDataResult<Employee>> UpdateAsync(Employee entity)
    {
      return new SuccessDataResult<Employee>(await _employeeRepository.UpdateAsync(entity), "Calisan Guncellendi");
    }
  }
}
