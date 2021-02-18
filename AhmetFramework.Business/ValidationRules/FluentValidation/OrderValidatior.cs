using AhmetFramework.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.Business.ValidationRules.FluentValidation
{
  public class OrderValidatior:AbstractValidator<Order>
  {
    public OrderValidatior()
    {
      RuleFor(o => o.CustomerId).NotEmpty();
      RuleFor(o => o.EmployeeId).NotEmpty();
      RuleFor(o => o.ShipName).NotEmpty();
      //
    }
  }
}
