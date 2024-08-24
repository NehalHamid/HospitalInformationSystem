using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{

    public class RegisterModel
    {
        public string? FullName { get; set; }

        public string? Username { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Email must be like user@example.com ")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
           ErrorMessage = "Password must have At least one digit, At least one lowercase character, At least one uppercase character, At least one special character, At least 8 characters in length")]

        public string? Password { get; set; }

        //the format of DateOnly should be like this => "1990-05-20"
        public DateOnly BirthDate { get; set; }

        public string? Gender { get; set; }

        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must be 11 digits.")]

        public string? Phone { get; set; }

        public string? DetailedAddress { get; set; }

        public string? NationalID { get; set; }
        public string? Image { get; set; }


    }
}
