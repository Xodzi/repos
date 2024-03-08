using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Specialization { get; set; }

    public string? Phone { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
