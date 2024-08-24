using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models
{
    public class payment
    {
        public string Name {  get; set; }

        public List<Servs> Services { get; set; }

    }

    public class Servs
    {
        public string NameOfService { get; set; }

        public decimal Price { get; set; }
    }
    public partial class History : BaseModel
    {
        public string? Diagnosis { get; set; }

        public string? XRay { get; set; }
        public string? Test { get; set; }


        public int PatientId { get; set; }

        public string? PatientNationalId { get; set; }
        public DateTime ExamenDate { get; set; }

        public int DoctorId { get; set; }
        public string? DoctorNationalId { get; set; }
        public virtual List<string>? Medicine { get; set; }

        public virtual Doctor? Doctor { get; set; }

        public virtual List<Drugs>? Medicines { get; set; }

        public virtual Patient? Patient { get; set; }
    }


}

