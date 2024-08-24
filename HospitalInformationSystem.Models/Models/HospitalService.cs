using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalInformationSystem.Models.Models;
[PrimaryKey(nameof(HospitalId), nameof(ServiceId))]
public partial class HospitalService
{
  
    public int HospitalId { get; set; }
    public int ServiceId { get; set; }

    public decimal Price { get; set; }

    public  Hospital? Hospital { get; set; }

    public  Service? Service { get; set; }
}
