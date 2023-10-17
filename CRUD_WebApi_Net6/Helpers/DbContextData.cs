using CRUD_WebApi_Net6.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WebApi_Net6.Helpers;

public class DbContextData : DbContext
{
    public DbContextData(DbContextOptions<DbContextData> option) : base(option) {}
    public virtual DbSet<Employee> Employees { get; set; }
}