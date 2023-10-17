using System.ComponentModel.DataAnnotations;
using CRUD_WebApi_Net6.Entities;

namespace CRUD_WebApi_Net6.Models;

public class UpdateEmpRequest
{
    public string Title { get; set; } 
    public string FirstName { get; set; }       
    public string LastName { get; set; }
    public string designation { get; set; }
 
    [EmailAddress]
    public string Email { get; set; }
 
    [EnumDataType(typeof(Role))]
    public string Role { get; set; }
 
    private string _password;
                     
    [MinLength(8)]
 
    public string password
    {
        get => _password; set => _password = replacewithNull(value);
    }
 
    private string _confirmpassword;
 
    [Compare("password")]
       
    public string confirmpassword
    {
        get => _confirmpassword;
        set => _confirmpassword = replacewithNull(value);
    }
 
    private string replacewithNull(string value)
    {
        return string.IsNullOrEmpty(value) ? null : value;
    }
}