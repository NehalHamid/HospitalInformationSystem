using HospitalInformationSystem.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{

    public class UpdateForm
    {

        public string Role { get; set; }
        public string Type { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPassword { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPhone { get; set; }
        public string DoctorGender { get; set; }
        public string DoctorNationalId { get; set; }
        public decimal? DoctorSalary { get; set; }
        public string DoctorDepartment { get; set; }
        public string? DoctorPicture { get; set; }
        public DateOnly? DoctorBirthDate { get; set; }



        public string NurseName { get; set; }
        public string NursePassword { get; set; }
        public string NurseEmail { get; set; }
        public string NursePhone { get; set; }
        public string NurseGender { get; set; }
        public string NurseNationalId { get; set; }
        public decimal? NurseSalary { get; set; }
        public string NurseDepartment { get; set; }
        public string? NursePicture { get; set; }
        public DateOnly? NurseBirthDate { get; set; }



        public string EmployeeName { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeNationalId { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public string EmployeeDepartment { get; set; }
        public string? EmployeePicture { get; set; }
        public DateOnly? EmployeeBirthDate { get; set; }
        public string? TypeOfEmployee { get; set; }
    }
    public class FormData
    {

        public string? Role {  get; set; }
        public string? Type {  get; set; }


        ////////////////////////// DOCTOR //////////////////////////////////
        public string? DoctorName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
                        ErrorMessage = "Email must be like user@example.com ")]

        public string? DoctorEmail { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "Password must have At least one digit, At least one lowercase character, At least one uppercase character, At least one special character, At least 8 characters in length")]

        public string? DoctorPassword { get; set; }

        public string? DoctorGender { get; set; }

        //public string? DoctorIdPicture { get; set; }
        public string? DoctorPicture { get; set; } 
        public DateOnly? DoctorBirthDate { get; set; }
        public string? DoctorDepartment { get; set; }

        public string? DoctorNationalId { get; set; }

        public string? DoctorSpecialization { get; set; }

        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string? DoctorPhone { get; set; }

        public decimal? DoctorSalary { get; set; }



        ///////////////////////////// DEPARTMENT ////////////////////////////////
        public string? DepartmentName { get; set; }




        //////////////////////////// DRUGS ///////////////////////////////////////
        public string? MedicineName { get; set; }
        public DateTime? DateOfDrugApproval { get; set; }
        public string? FromInternalPharmacy { get; set; }



        //////////////////////////// EMPLOYEE /////////////////////////////////////////
        public string? EmployeeName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Email must be like user@example.com ")]
        public string? EmployeeEmail { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must have At least one digit, At least one lowercase character, At least one uppercase character, At least one special character, At least 8 characters in length")]
        public string? EmployeePassword { get; set; }

        public string? TypeOfEmployee { get; set; }
        public string? EmployeeGender { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public string? EmployeeDepartment { get; set; }
        public string? EmployeeImage { get; set; }
        public DateOnly? EmployeeBirthDate { get; set; }

        public string? EmployeeNationalId { get; set; }


        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string? EmployeePhone { get; set; }


        /////////////////////////////// FEEDBACK ///////////////////////////////////////
        public string? NameOfService { get; set; }
        public int Rate { get; set; }
        public string? FeedBackContent { get; set; }

        //////////////////////////// HISTORY //////////////////////////////

        public string? Diagnosis { get; set; }

        public string? XRay { get; set; }
        public string? Test { get; set; }

        public DateTime ExamenDate { get; set; }

        public virtual List<string>? Medicine { get; set; }


        //////////////////////////////// HOSPITAL /////////////////////////////////
        public string? HospitalName { get; set; }

        public string? HospitalCity { get; set; }

        public string? HospitalRegion { get; set; }

        public string? HospitalStreet { get; set; }

        public string? HospitalType { get; set; }


        /////////////////////////////////// MEDICATION //////////////////////////////////////////
        public List<string>? Time { get; set; }


        //////////////////////////////////////// NURSE ///////////////////////////////////////////
        public string? NurseName { get; set; }



        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Email must be like user@example.com ")]
        public string? NurseEmail { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must have At least one digit, At least one lowercase character, At least one uppercase character, At least one special character, At least 8 characters in length")]
        public string? NursePassword { get; set; }

        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string? NursePhone { get; set; }

        public decimal? NurseSalary { get; set; }

        public string? NurseNationalId { get; set; }

        public string? NurseTimeSlot { get; set; }

        public string? NurseGender { get; set; }
        public string? NurseDepartment { get; set; }
        public string? NurseImage { get; set; }
        public DateOnly? NurseBirthDate { get; set; }


        ///////////////////////////////// PATIENT ///////////////////////////////////////////
        public string? PatientName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
         ErrorMessage = "Email must be like user@example.com ")]
        public string? PatientEmail { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must have At least one digit, At least one lowercase character, At least one uppercase character, At least one special character, At least 8 characters in length")]
        public string? PatientPassword { get; set; }

        public string? PatientUsername { get; set; }


        public DateOnly? PatientBirthDate { get; set; }

        public string? PatientGender { get; set; }


        [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string? PatientPhone { get; set; }

        public string? PatientImage { get; set; }

        public string? PatientRelativePhone { get; set; }

        public string? PatientType { get; set; }

        public string? PatientNationalId { get; set; }

        public string? PatientGovernorate { get; set; }

        public string? PatientCityOrVillage { get; set; }

        public string? PatientDetailedAddress { get; set; }

        ////////////////////////////////// PHARMACY //////////////////////////////////////////
        public string? PharmacyName { get; set; }


        //////////////////////////////////////// ROOM ///////////////////////////////////////////
        public int RoomNumber { get; set; }
        public string? RoomType { get; set; }

        public int? RoomNumberOfBeds { get; set; }

        public decimal? RoomNightPrice { get; set; }


        /////////////////////////////////// SERVICE //////////////////////////////////
        public string? ServiceName { get; set; }
        public decimal ServicePrice { get; set; }

        ///////////////////////////////// TEST ////////////////////////////////
        public string? TestName { get; set; }
        public decimal TestPrice { get; set; }


        /////////////////////////////////// XRAY //////////////////////////////////
        public string? XRayName { get; set; }
        public decimal XRayPrice { get; set; }


        ///////////////////////////////// TRANSFER /////////////////////////////
        public string? FromDoctorName { get; set; }
        public string? ToDoctorName { get; set; }


    }
}
