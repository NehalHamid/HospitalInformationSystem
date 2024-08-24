using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class Med
    {
        public string? Doctorname {  get; set; }
        public string? NID { get; set; }
        public string? Diagnosis { get; set; }
        public string? Medicine { get; set; }
      

    }

    public class Medication
    {
        public int Id { get; set; }
        public string? PatientNationalId { get; set; }
        public List<string>? MedicineName { get; set; }
        public List<string>? Time { get; set; }

    }
}
