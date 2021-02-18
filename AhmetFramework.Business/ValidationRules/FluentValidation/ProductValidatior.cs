using AhmetFramework.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.Business.ValidationRules.FluentValidation
{
  public class ProductValidatior:AbstractValidator<Product>
  {
    public ProductValidatior()
    {
      RuleFor(p => p.ProductName).NotEmpty();
      
    }

  }
}
