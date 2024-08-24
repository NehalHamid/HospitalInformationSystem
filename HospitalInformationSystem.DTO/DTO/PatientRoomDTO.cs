using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{
    public class OperationRoom
    {
        public string nationalID { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public int room_num { get; set; }
    }
    public class NormalRoom
    {
        public string nationalID { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string type { get; set; }
        public int room_num { get; set; }
    }
    public class PatientRoomDTO
    {
        public string PatientNationalId { get; set; }  
        public string DoctorName { get; set; }
        public string RoomType { get; set; } 
        public string? NormalRoomType { get; set; } 
        public string? Department { get; set; }
        public DateTime? EnteringDate { get; set; }

        public DateTime? LeavingDate { get; set; }

        public string? Breakfast { get; set; }

        public string? Lunch { get; set; }

        public string? Dinner { get; set; }
    }
}
