using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{
    public class TransferDTO
    {
        public string? FromdoctorName { get; set; }
        public string? TodoctorName { get; set; }
        public string? patientID { get; set; }
        public string? department { get; set; }
        public string? hospital { get; set; }
    }
}
