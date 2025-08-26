using System;
using System.Collections.Generic;

namespace HMS_MVC_Two.Models;
public class Doctor
{
    public Guid DoctorId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Specialty { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

