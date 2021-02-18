using AhmetFramework.Business.Abstract;
using AhmetFramework.Entities;
using AhmetFramework.Entities.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhmetFramework.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private IProductService _productService;
    private IMapper _mapper;
    public ProductsController(IProductService productService, IMapper mapper)
    {
      _productService = productService;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _productService.GetAllAsync();
      if (result.Success)
      {
        return Ok(_mapper.Map<IEnumerable<ProductDto>>(result.Data));
      }

      return BadRequest(result.Message);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var result = await _productService.GetAsync(p => p.ProductId == id);

      if (result.Success)
      {
        return Ok(_mapper.Map<ProductDto>(result.Data));

      }

      return BadRequest(result.Message);

    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductDto productDto)
    {

      var addedProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

      if (addedProduct.Success)
      {
        return Created(addedProduct.Message, _mapper.Map<ProductDto>(addedProduct.Data));
      }
      return BadRequest(addedProduct.Message);

    }
    [HttpPost("{id}")]
    public async Task<IActionResult> Update(int id, ProductDto productDto)
    {
      var result = _mapper.Map<Product>(productDto);
      result.ProductId = id;
      var updatedProduct = await _productService.UpdateAsync(result);

      if (updatedProduct.Success)
      {
        return NoContent();
      }

      return BadRequest(updatedProduct.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var deletedProduct = await _productService.GetAsync(p => p.ProductId == id);
      var result = await _productService.DeleteAsync(deletedProduct.Data);

      if (result.Success)
      {
        return NoContent();
      }

      return BadRequest(result.Message);
    }


  }
}
