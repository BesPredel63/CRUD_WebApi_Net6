using CRUD_WebApi_Net6.Entities;
using CRUD_WebApi_Net6.Models;

namespace CRUD_WebApi_Net6;

public interface IEmployee
{
    void EmployeeCreate(CreateEmpRequest empRequest);
    void EmployeeUpdate(int id, UpdateEmpRequest empRequest);
    void EmployeeDelete(int id);
    IEnumerable<Employee> GetAll();
    Employee EmployeeGetById(int id);
}