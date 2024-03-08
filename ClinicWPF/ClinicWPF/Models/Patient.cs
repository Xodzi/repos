using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public class Patient
{
    public int Id { get; set; }

    public string? Note { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public string? Anamnesis { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
}
