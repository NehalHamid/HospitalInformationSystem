using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models
{
    public partial class Room : BaseModel
    {

        public int Number { get; set; }

        public string? Type { get; set; }

        public int? NumberOfBeds { get; set; }
        public string? Department { get; set; }

        public decimal NightPrice { get; set; }

        public int? HospitalId { get; set; }

        public bool IsReserved { get; set; }
        public virtual Hospital? Hospital { get; set; }

        public virtual ICollection<PatientRoom> PatientRooms { get; set; }
    }


}

