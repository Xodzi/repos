using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class MedicalProcedure
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
