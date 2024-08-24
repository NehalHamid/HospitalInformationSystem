using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class Hospital:BaseModel
{
    
    public string? Name { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? Street { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<DoctorHospital>? DoctorHospitals { get; set; } 

    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<Finance> Finances { get; set; }
    public virtual ICollection<HospitalFeedBack> HospitalFeedBacks { get; set; } 

    public virtual ICollection<HospitalDepartment> HospitalDepartments { get; set; } 

    public virtual ICollection<HospitalService> HospitalServices { get; set; } 

    public virtual ICollection<Nurse> Nurses { get; set; }

    public virtual ICollection<PatientHospital> PatientHospitals { get; set; }

    public virtual ICollection<PatientService> PatientServices { get; set; }

    public virtual Pharmacy? Pharmacy { get; set; }

    public virtual ICollection<Report> Reports { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } 

    public virtual ICollection<Store> Stores { get; set; }
}
