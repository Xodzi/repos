using System;
using System.Collections.Generic;

namespace ClinicWPF.Models;

public partial class Prescription
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? MedicationId { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Medication? Medication { get; set; }

    public virtual Patient? Patient { get; set; }
}
