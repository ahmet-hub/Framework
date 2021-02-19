using AhmetFramework.Entities;
using AhmetFramework.Entities.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhmetFramework.WebApi.AutoMapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<ProductDto, Product>();
      CreateMap<Product, ProductDto>();

      CreateMap<CategoryDto, Category>();
      CreateMap<Category, CategoryDto>();
    }
  }
}

