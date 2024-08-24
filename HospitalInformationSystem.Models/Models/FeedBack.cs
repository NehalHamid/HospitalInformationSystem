using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class FeedBacks
    {
        public string? Name { get; set; }
        public string? feedback { get; set; }
        public string? nationalID { get; set; }
        public int rate { get; set; }
    }
    public class FeedBack
    {
        public int Id { get; set; }
        public string? NameOfService { get; set; }
        public string? PatientNationalId { get; set; }
        public int Rate { get; set; }
        public string? FeedBackContent { get; set; }

    }
}
