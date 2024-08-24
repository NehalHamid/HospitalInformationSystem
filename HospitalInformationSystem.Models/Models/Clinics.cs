using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class Clinics
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Department { get; set; }

        public string? Phone { get; set; }

    }
}
