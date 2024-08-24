using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class Store:BaseModel
{
  

    public string? Name { get; set; }

    public string? Type { get; set; }

    public int? HospitalId { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual ICollection<MedicineStore> MedicineStores { get; set; }
}
