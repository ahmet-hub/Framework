using AhmetFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace AhmetFramework.DataAccess.Concrete.EntityFramework
{
  public class NorthwindContext : DbContext
  {

    public NorthwindContext()
    {

    }
    public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

      var connectionString = @"Data Source=DESKTOP-J6RC35J;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
      //var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder
          .UseLoggerFactory(TestLogger.TestLogger.MyLoggerFactory)
          .UseSqlServer(connectionString
          );

      }
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    

  }
}
