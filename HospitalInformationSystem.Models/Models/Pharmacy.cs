using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class Pharmacy:BaseModel
{
    

    public string? PharmacyName { get; set; }

    public int? HospitalId { get; set; }

    public virtual Hospital? Hospital { get; set; }
}
