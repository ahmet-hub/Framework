using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.DataAccess.Concrete.EntityFramework.TestLogger
{
  public static class TestLogger 
  {
    public static readonly ILoggerFactory MyLoggerFactory =
    LoggerFactory.Create(
        builder =>
        {
          builder.AddConsole();
        }
   );
  }
}
