using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalInformationSystem.Models.Models
{

    [PrimaryKey(nameof(PatientId), nameof(RoomId))]
    public class PatientRoom
    {

        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public string PatientNationalId { get; set; }
        public int RoomId { get; set; }
        public int Number { get; set; }

        public string RoomType { get; set; }
        public string? NormalRoomType { get; set; }
        public string? Department { get; set; }

        public DateTime EnteringDate { get; set; }

        public DateTime? LeavingDate { get; set; }

        public string? Breakfast { get; set; }

        public string? Lunch { get; set; }

        public string? Dinner { get; set; }

        public Patient? Patient { get; set; }

        public Room? Room { get; set; }
    }

}
