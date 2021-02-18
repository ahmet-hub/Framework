using AhmetFramework.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.Business.ValidationRules.FluentValidation
{
  public class CustomerValidatior:AbstractValidator<Customer>
  {
    public CustomerValidatior()
    {
      RuleFor(c => c.CustomerId).NotEmpty();
      //
    }
  }
}
