using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class Drugs:BaseModel
{
  
    public string? MedicineName { get; set; }

    public DateTime? DateOfDrugApproval { get; set; }
    public string? FromInternalPharmacy { get; set; }

    public int? DoctorId { get; set; }

    public int? HistoryId { get; set; }


    public virtual Doctor? Doctor { get; set; }

    public virtual History? History { get; set; }
}
