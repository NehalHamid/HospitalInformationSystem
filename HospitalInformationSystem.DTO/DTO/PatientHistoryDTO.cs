using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{

    public class PatientTestdto
    {
        public List<string> tests { get; set; }
    }
    public class PatientXraydto
    {
        public List<string> xrays { get; set; }
    }
    public class PatientHistoryDTO
    {
        public string? NationalId { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public List<string>? Diagnosis { get; set; }
        public List<string>? XRays { get; set; }
        public List<string>? Tests { get; set; }
        public virtual List<string>? Medicines { get; set; }

    }
}
