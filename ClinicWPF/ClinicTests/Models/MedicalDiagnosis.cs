using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class MedicalDiagnosis
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Mkb { get; set; }
}
