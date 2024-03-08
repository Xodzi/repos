using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class Medication
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Dose { get; set; }

    public string? Instruction { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
