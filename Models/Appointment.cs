using System;
using System.Collections.Generic;

namespace HMS_MVC_Two.Models;

public partial class Appointment
{
    public Guid AppointmentId { get; set; }

    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string? ReasonForVisit { get; set; }

    public int PaymentStatus { get; set; }

    public DateTime CreatedAt { get; set; }




     public string? PaymentReference { get; set; }
}
