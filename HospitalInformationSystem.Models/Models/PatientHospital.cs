using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalInformationSystem.Models.Models;
[PrimaryKey(nameof(HospitalId), nameof(PatientId))]
public partial class PatientHospital
{

    public int HospitalId { get; set; }
    public int PatientId { get; set; }
    public int? Age { get; set; }

    public DateTime? ExamenDate { get; set; }

    public string? RequiredExamination { get; set; }

    public Hospital? Hospital { get; set; }

    public Patient? Patient { get; set; }
}
