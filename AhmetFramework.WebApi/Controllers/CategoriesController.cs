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
  public class CategoriesController : ControllerBase
  {
    private ICategoryService _categoryService;
    private IMapper _mapper;
    public CategoriesController(ICategoryService categoryService, IMapper mapper)
    {
      _categoryService = categoryService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _categoryService.GetAllAsync();

      if (result.Success)
      {
        return Ok(_mapper.Map<IEnumerable<CategoryDto>>(result.Data));
      }
      return BadRequest(result.Message);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var result = await _categoryService.GetAsync(c => c.CategoryId == id);

      if (result.Success)
      {
        return Ok(_mapper.Map<CategoryDto>(result.Data));
      }

      return BadRequest(result.Message);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategoryDto categoryDto)
    {
      var result = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
      if (result.Success)
      {
        return Created(result.Message,_mapper.Map<CategoryDto>(result.Data));
      }
      return BadRequest(result.Message);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
    {
      var updatedCategory = _mapper.Map<Category>(categoryDto);
      updatedCategory.CategoryId = id;

      var result = await _categoryService.UpdateAsync(updatedCategory);
      if (result.Success)
      {
        return NoContent();
      }
      return BadRequest(result.Message);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var category = await _categoryService.GetAsync(c => c.CategoryId == id);
      var result = await _categoryService.DeleteAsync(category.Data);

      if (result.Success)
      {
        return NoContent();
      }
      return BadRequest(result.Message);
    }

  }
}
