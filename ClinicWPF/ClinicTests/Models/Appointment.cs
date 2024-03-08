using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int? PatiendId { get; set; }

    public int? DoctorId { get; set; }

    public DateTime? Date { get; set; }

    public string? Status { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patiend { get; set; }
}
