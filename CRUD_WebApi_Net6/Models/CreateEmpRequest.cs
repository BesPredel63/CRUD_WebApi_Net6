using System.ComponentModel.DataAnnotations;
using CRUD_WebApi_Net6.Entities;

namespace CRUD_WebApi_Net6.Models;

public class CreateEmpRequest
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string designation { get; set; }
    public string Email { get; set; }
    [Required]
    public Role Role { get; set; }
    [Required]
    [MinLength(8)]
    public string password { get; set; }
    [Required]
    public string confirmpassword { get; set; }    
}