using AhmetFramework.Business.Abstract;
using AhmetFramework.Business.Concrete.Manager;
using AhmetFramework.Core.Utilities.Interceptors;
using AhmetFramework.DataAccess.Abstract;
using AhmetFramework.DataAccess.Concrete.EntityFramework;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmetFramework.Business.DependencyResorvers.Autofac
{
  public class AutofacBusinessModule:Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
      builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();

      builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
      builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();

      builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
      builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();

      builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
      builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();

      builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
      builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();

      var assembly = System.Reflection.Assembly.GetExecutingAssembly();

      builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
          .EnableInterfaceInterceptors(new ProxyGenerationOptions()
          {
            Selector = new AspectInterceptorSelector()
          }).SingleInstance();

    }
  }
}
