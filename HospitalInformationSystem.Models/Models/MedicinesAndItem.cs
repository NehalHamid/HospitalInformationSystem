using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class MedicinesAndItem:BaseModel
{
   

    public string? Name { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? StoreId { get; set; }

    public virtual ICollection<MedicineStore> MedicineStores { get; set; }
}
