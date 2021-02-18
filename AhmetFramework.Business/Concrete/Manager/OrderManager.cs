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
  public class OrderManager : IOrderService
  {
    private IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository orderRepository)
    {
      _orderRepository = orderRepository;
    }

    [ValidationAspect(typeof(OrderValidatior))]
    public async Task<IDataResult<Order>> AddAsync(Order entity)
    {
      return new SuccessDataResult<Order>(await _orderRepository.AddAsync(entity), "Siparis Eklendi");
    }


    public async Task<IResult> DeleteAsync(Order entity)
    {
      await _orderRepository.DeleteAsync(entity);
      return new SuccessResult("Siparis Silindi");
    }


    public async Task<IDataResult<IEnumerable<Order>>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
    {
      return new SuccessDataResult<IEnumerable<Order>>(await _orderRepository.GetAllAsync(filter), "Siparisler Listelendi");
    }

    public async Task<IDataResult<Order>> GetAsync(Expression<Func<Order, bool>> filter)
    {
      return new SuccessDataResult<Order>(await _orderRepository.GetAsync(filter), "Siparisler Listelendi");
    }

    [ValidationAspect(typeof(OrderValidatior))]
    public async Task<IDataResult<Order>> UpdateAsync(Order entity)
    {
      return new SuccessDataResult<Order>(await _orderRepository.UpdateAsync(entity), "Siparis Guncellendi");
    }
  }
}

