using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;
[PrimaryKey(nameof(DoctorId),nameof(HospitalId))]
public partial class DoctorHospital
{
    
   public int DoctorId { get; set; }
   public int HospitalId { get; set; }

    public DateTime HiringDate { get; set; }
    public decimal NetSalary { get; set; }

    public DateTime TimeSlot { get; set; }
    public int? departmentID { get; set; }

    public Department Department { get; set; }

    public  Doctor? Doctor { get; set; }

    public  Hospital? Hospital { get; set; }

}
