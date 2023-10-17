using AutoMapper;
using CRUD_WebApi_Net6.Entities;
using CRUD_WebApi_Net6.Helpers;
using CRUD_WebApi_Net6.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WebApi_Net6;

public class EmployeeService : IEmployee
{
    private DbContextData _dbContext;
    private readonly IMapper _mapper;

    public EmployeeService(DbContextData dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void EmployeeCreate(CreateEmpRequest empRequest)
    {
        var EmailExist = _dbContext.Employees.Any(e => e.Email == empRequest.Email);
        if (EmailExist == true)
        {
            throw new AppException("Employee Email ID: '" + empRequest.Email + "' Already Exist");
        }

        var emp = _mapper.Map<Employee>(empRequest);

        _dbContext.Add(emp);
        _dbContext.SaveChanges();
    }

    public void EmployeeDelete(int id)
    {
        var emp = _dbContext.Employees.Find(id);
        if (emp == null)
        {
            throw new AppException("Employee Not Found");
        }

        _dbContext.Remove(emp);
        _dbContext.SaveChanges();
    }

    public Employee EmployeeGetById(int id)
    {
        var emp = _dbContext.Employees.Find(id);
        if (emp == null)
        {
            throw new AppException("Employee Not Found");
        }
        return emp;
    }

    public void EmployeeUpdate(int id, UpdateEmpRequest empRequest)
    {
        var emp = EmployeeGetById(id);
        if (emp.Email == empRequest.Email)
        {
            throw new AppException("Employee Email ID: '" + empRequest.Email + "' Already Exist");
        }

        _mapper.Map(empRequest, emp);
        _dbContext.Employees.Update(emp);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Employee> GetAll()
    {
        return _dbContext.Employees;
    }
}