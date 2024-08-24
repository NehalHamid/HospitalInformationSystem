using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class Finance:BaseModel
{
  

    public decimal? TotalCost { get; set; }

    public decimal? TotalRevenues { get; set; }

    public decimal? NetProfit { get; set; }

    public string? DetailedCosts { get; set; }

    public string? DetailedRevenues { get; set; }

    public DateOnly? ScheduleDate { get; set; }

    public int? HospitalId { get; set; }

    public virtual Hospital? Hospital { get; set; }
}
