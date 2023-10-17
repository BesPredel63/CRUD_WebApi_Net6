using System.Text.Json.Serialization;
using CRUD_WebApi_Net6;
using CRUD_WebApi_Net6.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(json =>
{
    json.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    json.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddDbContext<DbContextData>(connection =>
                                                 connection.UseSqlServer(
                                                     builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<MiddlewareErrorHandler>();

app.MapControllers();

app.Run();