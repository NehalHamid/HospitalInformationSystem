using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{
    public class PatientDTO
    {

        public string? FullName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
          ErrorMessage = "Email must be like user@example.com ")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Gender { get; set; }


        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string? Phone { get; set; }

        public string? RelativePhone { get; set; }

        public string? Type { get; set; }

        public string? Username { get; set; }
        public string? Image {  get; set; } 
      
        public string? NationalId { get; set; }

        public string? Governorate { get; set; }

        public string? CityOrVillage { get; set; }

        public string? DetailedAddress { get; set; }
    }
}

