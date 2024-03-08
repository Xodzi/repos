using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class MedicalTest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
}
