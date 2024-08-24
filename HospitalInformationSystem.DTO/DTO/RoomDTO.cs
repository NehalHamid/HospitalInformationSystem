using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{
   public class RoomDTO
    {
        public int Number { get; set; }
        public string? Type { get; set; }

        public int? NumberOfBeds { get; set; }

        public decimal NightPrice { get; set; }

    }
   
}