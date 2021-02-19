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
  public class EmployeesController : ControllerBase
  {
    private IEmployeeService _employeeService;
    private IMapper _mapper;

    public EmployeesController(IEmployeeService employeeService, IMapper mapper)
    {
      _employeeService = employeeService;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _employeeService.GetAllAsync();
      if (result.Success)
      {
        return Ok(_mapper.Map<EmployeeDto>(result.Data));
      }

      return BadRequest(result.Message);
     }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var result = await _employeeService.GetAsync(e => e.EmployeeId == id);
      if (result.Success)
      {
        return Ok(_mapper.Map<EmployeeDto>(result.Data));
      }
      return BadRequest(result.Message);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EmployeeDto employeeDto)
    {
      var result = await _employeeService.AddAsync(_mapper.Map<Employee>(employeeDto));
      if (result.Success)
      {
        return Created(result.Message,_mapper.Map<ProductDto>(result.Data));
      }
      return BadRequest(result.Message);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Update(int id,EmployeeDto employeeDto)
    {
      var addedEmployee = _mapper.Map<Employee>(employeeDto);
      addedEmployee.EmployeeId = id;

      var result = await _employeeService.UpdateAsync(addedEmployee);
      if (result.Success)
      {
        return NoContent();
      }
      return BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var deletedEmployee = await _employeeService.GetAsync(p => p.EmployeeId == id);
      var result = await _employeeService.DeleteAsync(deletedEmployee.Data);
      if (result.Success)
      {
        return NoContent();
      }

      return BadRequest(result.Message);
          
    }

  }
}
