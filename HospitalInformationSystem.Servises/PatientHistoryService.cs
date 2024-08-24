using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Services
{
    public class PatientHistoryService
    {
        // Method to calculate age based on birth date
        public static int CalculateAge(DateOnly? birthDate)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - birthDate.Value.Year;

            if (today < birthDate.Value.AddYears(age))
            {
                age--;
            }

            return age;
        }





    }
}
