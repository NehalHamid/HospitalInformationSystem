using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{
    public class PatientHospitalDTO
    {
        public int? Age { get; set; }

        public DateTime? ExamenDate { get; set; }

        public string? RequiredExamination { get; set; }
    }
}
