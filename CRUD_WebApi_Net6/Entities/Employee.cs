using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRUD_WebApi_Net6.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Designation { get; set; }
    public string Title { get; set; }
    public string Email { get; set; }
    [Required]
    [EnumDataType(typeof(Role))]
    public string Role { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
}