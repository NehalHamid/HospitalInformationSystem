using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO
{
    public class DoctorDTO
    {


        public string? FullName { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
                        ErrorMessage = "Email must be like user@example.com ")]
        public string? Email { get; set; }


        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
               ErrorMessage = "Password must have At least one digit, At least one lowercase character, At least one uppercase character, At least one special character, At least 8 characters in length")]
        public string? Password { get; set; }
        public string? Gender { get; set; }


        public string? IdPicture { get; set; } = null;
        public string? DoctorPicture { get; set; } = null;
        public DateOnly? BirthDate { get; set; }
        public string? Department { get; set; }

        public string? NationalId { get; set; }

        public string? Specialization { get; set; }

        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string? Phone { get; set; }

        public decimal? Salary { get; set; }

        public string? Image { get; set; }

    }
}
