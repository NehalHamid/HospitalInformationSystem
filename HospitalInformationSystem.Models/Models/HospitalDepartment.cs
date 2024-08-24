using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalInformationSystem.Models.Models;
[PrimaryKey(nameof(HospitalId),nameof(DepartmentId))]
public partial class HospitalDepartment
{
   
    public int HospitalId { get; set; }
    public int DepartmentId { get; set; }
    public int? NumberOfClinics { get; set; }

    public int? NumberOfEmployees { get; set; }

    public int? Floor { get; set; }

    public int? NumberOfOperationsRooms { get; set; }

    public  Department? Department { get; set; }

    public  Hospital? Hospital { get; set; }
}
