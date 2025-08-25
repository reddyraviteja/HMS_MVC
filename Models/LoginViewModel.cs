using System.ComponentModel.DataAnnotations;
namespace HMS_MVC_Two.Models;

public class LoginViewModel
{
    
    public string? EmailId { get; set; }

    
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    
    public string? Role { get; set; }
}
