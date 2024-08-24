using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{
    public class Med
    {
        public DateOnly date { get; set; }
        public string medicine { get; set; }
    }
    public class Historydto
    {
        public string Patientname { get; set; }
        public string Diagnosis { get; set; }
        public List<Med> Medicine { get; set; }
    }
    
    public class HistoryDTO
    {
        public string? Diagnosis { get; set; }

        public string? XRay { get; set; }
        public string? Test { get; set; }

        public int PatientId { get; set; }
        public string? PatientNationalId { get; set; }
        public string? PatientName { get; set; }

        public DateTime ExamenDate { get; set; } 

        public int DoctorId { get; set; }
        public string? DoctorNationalId { get; set; }

        public virtual List<string>? Medicine { get; set; }
    }

}
