using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.Core.Utilities.Results
{
  public interface IDataResult<T>:IResult
  {
    public T Data { get; }
  }
}
