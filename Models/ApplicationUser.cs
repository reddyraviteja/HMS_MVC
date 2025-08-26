using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMS_MVC_Two.Models;

public partial class ApplicationUser
{
    [Key]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Name is Required**")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email Id Required**")]
    [EmailAddress(ErrorMessage = "Give the proper Email ID")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password Required**")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Compare("Password", ErrorMessage = "Password didn't match")]
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "10 diigits only")]
    public string? Phone { get; set; }

    [Required]
    public string? Role { get; set; }

    public bool IsEmailVerified { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
