using AhmetFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.Entities
{
  public class Product : IEntity
  {
    public int ProductId { get; set; }

    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public Int16 UnitsInStock { get; set; }

  }
}
