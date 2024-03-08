using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class TestResult
{
    public int Id { get; set; }

    public int? TestId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? Date { get; set; }

    public string? Result { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual MedicalTest? Test { get; set; }
}
