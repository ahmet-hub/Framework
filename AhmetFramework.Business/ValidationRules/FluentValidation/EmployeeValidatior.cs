using AhmetFramework.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.Business.ValidationRules.FluentValidation
{
  public class EmployeeValidatior:AbstractValidator<Employee>
  {
    public EmployeeValidatior()
    {
      RuleFor(e => e.FirstName).NotEmpty();
      RuleFor(e => e.LastName).NotEmpty();
      //
    }
  }
}
