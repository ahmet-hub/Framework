using AhmetFramework.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.Business.ValidationRules.FluentValidation
{
  public class CategoryValidatior:AbstractValidator<Category>
  {
    public CategoryValidatior()
    {
      RuleFor(c => c.CategoryId).NotEmpty();
      RuleFor(c => c.CategoryName).NotEmpty();
    }
  }
}