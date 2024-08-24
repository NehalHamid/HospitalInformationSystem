using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalInformationSystem.Models.Models;
public class Patientdto
{
    public string? fullname { get; set; } 
    public string? password { get; set; } 
    public string? email { get; set; }
    public string? phone { get; set; }
    public string? gender { get; set; }
    public string?  NID { get; set; }
    public string? img { get; set; }
    public DateOnly? Bdate { get; set; }
}
public partial class Patient:BaseModel
{
   

    public string? FullName { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
          ErrorMessage = "Email must be like user@example.com ")]
    public string? Email { get; set; }

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must have At least one digit, At least one lowercase character, At least one uppercase character, At least one special character, At least 8 characters in length")]
    public string? Password { get; set; }

    public string? Username { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Gender { get; set; }


    [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must be 11 digits.")]
    public string? Phone { get; set; }

    public string? RelativePhone { get; set; }

    public string? Type { get; set; }

    public string? NationalId { get; set; }

    public string? Governorate { get; set; }

    public string? CityOrVillage { get; set; }

    public string? DetailedAddress { get; set; }
    public string? Image {  get; set; }

    public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }

    public virtual ICollection<HospitalFeedBack> Feedbacks { get; set; }

    public virtual ICollection<History> Histories { get; set; }

    public virtual ICollection<PatientHospital> PatientHospitals { get; set; }

    public virtual ICollection<PatientNurse> PatientNurses { get; set; }

    public virtual ICollection<PatientRoom> PatientRooms { get; set; }

    public virtual ICollection<PatientService> PatientServices { get; set; }
}
