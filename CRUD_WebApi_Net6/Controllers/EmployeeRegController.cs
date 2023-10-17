using AutoMapper;
using CRUD_WebApi_Net6.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_WebApi_Net6.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeRegController : ControllerBase
{
    private readonly IEmployee _employee;
    private readonly IMapper _mapper;

    public EmployeeRegController(IEmployee employee, IMapper mapper)
    {
        _employee = employee;
        _mapper = mapper;
    }
    // GET api/<EmployeeGerController>
    [HttpGet]
    public IActionResult Get()
    {
        var emp = _employee.GetAll();
        return Ok(emp);
    }
    // GET api/<EmployeeGerController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var emp = _employee.EmployeeGetById(id);
        return Ok(emp);
    }
    // POST api/<EmployeeGerController>
    [HttpPost]
    public IActionResult Post(CreateEmpRequest createEmpRequest)
    {
        _employee.EmployeeCreate(createEmpRequest);
        return Ok(new { Message = "Employee Created" });
    }
    // PUT api/<EmployeeGerController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateEmpRequest updateEmpRequest)
    {
        _employee.EmployeeUpdate(id, updateEmpRequest);
        return Ok(new { Message = "Employee Updated" });
    }
    // DELETE api/<EmployeeGerController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _employee.EmployeeDelete(id);
        return Ok(new { Message = "Employee Deleted" });
    }
}