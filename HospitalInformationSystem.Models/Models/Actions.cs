
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class Action
    {
        public string? nationalID { get; set; }
        public string? nurseID { get; set; }
        public string? notes { get; set;}
    }
    public class Actions
    {
        public int Id { get; set; }
        public string? NurseNatinalId { get; set; }

        public string? PatientNationalId { get; set; }

        public string? Notes { get; set; }

        public DateTime AddedAt { get; set; }

    }
}
