using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalInformationSystem.Models.Models;
[PrimaryKey(nameof(DoctorId),nameof(PatientId))]
public partial class DoctorPatient
{
    
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime? DateOfVisiting { get; set; }

    public Doctor? Doctor { get; set; } 

    public Patient?  Patient { get; set; } 
}

