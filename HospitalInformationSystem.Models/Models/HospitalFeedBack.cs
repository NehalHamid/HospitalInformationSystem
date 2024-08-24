using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class HospitalFeedBack:BaseModel
{

    public string? FeedBackContent { get; set; }
    public int Rate { get; set; }


    public int? PatientId { get; set; }
   
    public int? HospitalId { get; set; }
    


    public virtual Patient? Patient { get; set; }
    public Hospital Hospital { get; set; }

}
