using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public string? FromDoctorName { get; set; }
        public string? ToDoctorName { get; set; }
        public string? PatientNationalId { get; set; }
        public string? DepartmentName { get; set;}
        public string? HospitalName { get; set;}


    }
}
