using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;

public partial class Department:BaseModel

{ 

    public string? Name { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

    public virtual ICollection<HospitalDepartment> HospitalDepartments { get; set; }

    public virtual ICollection<Nurse> Nurses { get; set; }
}
