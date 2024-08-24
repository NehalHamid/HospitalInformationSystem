using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class Reserveclinic
    {
        public string? patientId { get; set; }
        public string? clinicName { get; set; }
        public List<string>? appointments { get; set; }

    }
    public class ReserveHospital
    {
        public string? name {  get; set; }
        public string? nationalID { get; set; }
        public string? hospital { get; set; }
        public string? department { get; set; }

    }
    public class Reservations: BaseModel
    {
        public string? PatientName { get; set; }

        public string? PatientNationalId { get; set; }
        public string? Name { get; set; }
        public string? DepartmentName { get; set; }

        public DateTime date { get; set; }

        public string? time { get; set; }



    }
}
