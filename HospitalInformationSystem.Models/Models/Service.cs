using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class Service:BaseModel
{
    public string? Name { get; set; } 
    public decimal Price { get; set; }

    public virtual ICollection<HospitalService> HospitalServices { get; set; }

    public virtual ICollection<PatientService> PatientServices { get; set; }
}
