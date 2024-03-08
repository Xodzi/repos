using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class Personal
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronimic { get; set; }

    public DateTime? Date { get; set; }

    public string? Phone { get; set; }

    public int PatiendId { get; set; }

    public string Email { get; set; } = null!;

    public virtual Patient Patiend { get; set; } = null!;
}
