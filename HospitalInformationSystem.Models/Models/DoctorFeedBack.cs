using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class DoctorFeedBack:BaseModel
    {

        public string? FeedBackContent { get; set; }
        public int Rate { get; set; }


        public int? PatientId { get; set; }

        public int? DoctorId { get; set; }



        public virtual Patient? Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
}
