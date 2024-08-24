using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class XRay
    {
        public string NID { get; set; }
        public string DoctorName { get; set; }
        public IFormFile img { get; set; }

    }
    public class XRays: BaseModel
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }

    }
}
