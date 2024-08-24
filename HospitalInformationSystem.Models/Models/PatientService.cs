using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalInformationSystem.Models.Models;
[PrimaryKey(nameof(PatientId), nameof(ServiceId))]
public partial class PatientService
{
    public int PatientId { get; set; }
    public int ServiceId { get; set; }
    public int? HospitalId { get; set; }

    public DateTime DateOfOrder { get; set; }

    public  Hospital? Hospital { get; set; }

    public Patient? Patient { get; set; }

    public Service? Service { get; set; }
}
