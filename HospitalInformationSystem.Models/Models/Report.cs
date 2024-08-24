using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class Report:BaseModel
{
  
    public string? Name { get; set; }

    public string? Result { get; set; }

    public int HospitalId { get; set; }

    public virtual Hospital Hospital { get; set; } = null!;
}
