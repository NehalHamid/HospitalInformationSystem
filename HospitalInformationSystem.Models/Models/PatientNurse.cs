using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalInformationSystem.Models.Models;
[PrimaryKey(nameof(PatientId), nameof(NurseId))]
public partial class PatientNurse
{
  
    public int PatientId { get; set; }  
    public int NurseId { get; set; }  

    public DateTime? VisitingDate { get; set; }

    public string? MedicineReport { get; set; }

    public  Nurse? Nurse { get; set; }

    public  Patient? Patient { get; set; }
}
