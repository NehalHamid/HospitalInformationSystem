using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO.DTO;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HospitalInformationSystem.API.Helpers;
using System.Text.Json.Serialization;
using Tests = HospitalInformationSystem.Models.Models.Tests;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Request = HospitalInformationSystem.Models.Models.Request;



namespace HospitalInformationSystem.Services
{
    public class DoctorService
    {
        IRepository<Doctor> _repository;
        public static ApplicationDbContext _context;
        HistoryDTO historyDTO = new HistoryDTO();
        public static HistoryService _historyService;


        public DoctorService(IRepository<Doctor> repository, ApplicationDbContext context, HistoryService historyService)
        {
            _repository = repository;
            _context = context;
            _historyService = historyService;


        }


        ////////////////////////////// UPDATE DOCTOR ///////////////////////////////



        /*  public string Update(string ID, DoctorDTO doctorDTO)
          {
              // Fetch the existing entity
              Doctor existingEntity = _context.Doctor.FirstOrDefault(x => x.NationalId == ID);
              if (existingEntity == null)
              {
                  return "Doctor not found";
              }

              // Update the existing entity with the new values
              existingEntity.FullName = doctorDTO.FullName;
              existingEntity.Gender = doctorDTO.Gender;
              existingEntity.Email = doctorDTO.Email;
              existingEntity.Password = doctorDTO.Password;
              existingEntity.IdPicture = doctorDTO.IdPicture;
              existingEntity.DoctorPicture = doctorDTO.DoctorPicture;
              existingEntity.Phone = doctorDTO.Phone;
              existingEntity.Specialization = doctorDTO.Specialization;
              existingEntity.Salary = doctorDTO.Salary;

              // Save changes asynchronously
              _context.SaveChanges();
              return "Successfully Updated";
          }
  */

        public async Task<string> Update(string ID, DoctorDTO doctorDTO)
        {
            // Fetch the existing entity
            var existingEntity = await _context.Doctor.FirstOrDefaultAsync(x => x.NationalId == ID);
            if (existingEntity == null)
            {
                return "Doctor not found";
            }

            // Update the existing entity with the new values
            existingEntity.FullName = doctorDTO.FullName ?? existingEntity.FullName;
            existingEntity.Gender = doctorDTO.Gender ?? existingEntity.Gender;
            existingEntity.Email = doctorDTO.Email ?? existingEntity.Email;
            existingEntity.Password = doctorDTO.Password ?? existingEntity.Password;
            existingEntity.IdPicture = doctorDTO.IdPicture ?? existingEntity.IdPicture;
            existingEntity.DoctorPicture = doctorDTO.DoctorPicture ?? existingEntity.DoctorPicture;
            existingEntity.Phone = doctorDTO.Phone ?? existingEntity.Phone;
            existingEntity.Specialization = doctorDTO.Specialization ?? existingEntity.Specialization;
            existingEntity.Salary = doctorDTO.Salary != null ? doctorDTO.Salary : existingEntity.Salary;

            // Mark entity as modified
            _context.Entry(existingEntity).State = EntityState.Modified;

            // Save changes asynchronously
            await _context.SaveChangesAsync();
            return "Successfully Updated";
        }



        ////////////////////////////////////////// GETALL DOCTORS ///////////////////////////////////

        public IEnumerable<DoctorDTO> GetAll()
        {
            var doctors = _repository.GetAll();

            List<DoctorDTO> result = [];
            foreach (var item in doctors)
            {
                DoctorDTO viewModel = new()
                {
                    FullName = item.FullName,
                    NationalId = item.NationalId,
                    Gender = item.Gender,
                    Email = item.Email,
                    IdPicture = item.IdPicture,
                    Specialization = item.Specialization

                };
                result.Add(viewModel);
            }
            return result;

        }


        //////////////////////////////////////// Search By Specialization //////////////////////////////////////

        public IEnumerable<DoctorDTO> SearchBySpecialization(string specialization)
        {
            List<DoctorDTO> result = [];
            var doctors = _repository.
                Search(expression: x => x.Specialization.Contains(specialization));
            foreach (var item in doctors)
            {
                DoctorDTO doctor = new()
                {
                    FullName = item.FullName,
                    Specialization = item.Specialization,
                    DoctorPicture = item.DoctorPicture,

                };
                result.Add(doctor);
            }
            return result;
        }


        ///////////////////////////////////////////// Show Profile //////////////////////////////////////////////

        public DoctorDTO ShowProfile(string type, string ID)
        {
            if (string.Equals(type, "Doctor", StringComparison.OrdinalIgnoreCase))
            {
                Doctor doctor = _context.Doctor.FirstOrDefault(x => x.NationalId == ID);
                DoctorDTO result = new()
                {
                    FullName = doctor.FullName,
                    Email = doctor.Email,
                    Password = doctor.Password,
                    Salary = doctor.Salary,
                    Gender = doctor.Gender,
                    Specialization = doctor.Specialization,
                    Phone = doctor.Phone,
                    IdPicture = doctor.IdPicture,
                    DoctorPicture = doctor.DoctorPicture,
                    NationalId = doctor.NationalId
                };
                return result;
            }
            else
            {
                DoctorDTO resultBad = new();
                return resultBad;
            }

        }


        /////////////////////////////////// Recheck ///////////////////////////////////////////


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


        public PatientHistoryDTO Recheck(string id)
        {

            List<string> xRays = [];
            List<string> tests = [];
            List<string> examines = [];
            //List<string> diagnosis = [];
            List<string> medicines = [];

            var patient = _context.Patient.FirstOrDefault(x => x.NationalId == id);
            var histories = _context.History.Where(x => x.PatientNationalId == id).ToList();
            foreach (var item in histories)
            {
                if (item.XRay != null)
                {
                    xRays.Add(item.XRay);
                }
                if (item.Test != null)
                {
                    tests.Add(item.Test);
                }
                /* if (item.Diagnosis != null)
                 {
                     diagnosis.Add(item.Diagnosis);
                 }*/
                if (item.Medicine != null)
                {
                    foreach (var medicine in item.Medicine)
                    {
                        medicines.Add(medicine);

                    }
                }

            }

            PatientHistoryDTO history = new()
            {
                NationalId = id,
                FullName = patient.FullName,
                Age = CalculateAge(patient.BirthDate),
                //Diagnosis = diagnosis,
                XRays = xRays,
                Tests = tests,
                Medicines = medicines
            };

            return history;



        }



        /////////////////////////////////// Diagnosis ///////////////////////////////////////////

        public async Task<string> Diagnosis(string PatientId, string DoctorName, string diagnosis, string? medication)
        {

            Patient patient = _context.Patient.Where(x => x.NationalId.Equals(PatientId)).FirstOrDefault();
            int patientid = patient.Id;
            Doctor doctor = _context.Doctor.Where(x => x.FullName.Equals(DoctorName)).FirstOrDefault();
            int doctorid = doctor.Id;


            // Split the string using a comma as the delimiter
            string[] splitResult = medication.Split(',');

            // Create a list to store every other word
            List<string> medicines = new List<string>();

            // Loop through the array and add every other word to the list
            for (int i = 0; i < splitResult.Length; i += 2)
            {
                medicines.Add(splitResult[i]);

            }

            // Create a list to store every other word
            List<string> Times = new List<string>();

            // Loop through the array and add every other word to the list
            for (int i = 1; i < splitResult.Length; i += 2)
            {
                Times.Add(splitResult[i]);
            }

            Medication medicationPatient = new()
            {
                PatientNationalId = patient.NationalId,
                MedicineName = medicines,
                Time = Times,
            };
            _context.Medications.Add(medicationPatient);
            _context.SaveChanges();

            _historyService.Add(patientid, doctorid, medicines, diagnosis);
            return "Diagnosis has been written successfully";
        }


    
    ////////////////////////////////////// Transfer ///////////////////////////////////////////


    public static string PostTransfer(TransferDTO transfer)
    {

            Transfer result = new()
            {
                FromDoctorName = transfer.FromdoctorName,
                ToDoctorName = transfer.TodoctorName,
                PatientNationalId = transfer.patientID,
                DepartmentName = transfer.department,
                HospitalName = transfer.hospital
            };
            _context.Add(result);
            _context.SaveChanges();
            return "Transferred Successfully";



    }

    public static List<string> GetHospitals()
    {
            /*HospitalDTO hospital = new HospitalDTO();
            var hospitals = _context.Hospital.ToList();
            List<string> result = [];
            foreach (var item in hospitals)
            {
                var name = item.Name;
                result.Add(name);

            }
            return result;*/
            var hospitals = _context.Hospital.Select(h => h.Name).ToList();
            return hospitals;

        }

    public static List<string> GetDepartments()
    {
            /*DepartmentDTO department = new DepartmentDTO();
            var departments = _context.Department.ToList();
            List<string> result = [];
            foreach (var item in departments)
            {
                var name = item.Name;
                result.Add(name);

            }
            return result;*/
            var departments = _context.Department.Select(d => d.Name).ToList();
            return departments;

        }


    ////////////////////////////////////// Ask For X_Rays And Tests ///////////////////////////////////////////


    public string AskForX_Rays(Request request)
    {

            Requests newRequest = new()
            {
                NationalId = request.NationalId,
                Name = "XRay",
                Type = request.Type,
                DateTime = DateTime.Now

            };
            _context.Add(newRequest);
            _context.SaveChanges();
            return "Requested Successfully";
        
    }


    public string AskForTests( Request request)
    {

            Requests newRequest = new()
            {
                NationalId = request.NationalId,
                Name = "Test",
                Type = request.Type,
                DateTime = DateTime.Now

            };
            _context.Add(newRequest);
            _context.SaveChanges();
            return "Requested Successfully";

    }


    public List<string> GetXRays()
    {
        var xrays = _context.Xrays.ToList();
        List<string> result = [];
        foreach (var item in xrays)
        {
            var name = item.Name;
            result.Add(name);

        }
        return result;

    }

    public List<string> GetTests()
    {
        var tests = _context.Tests.ToList();
        List<string> result = [];
        foreach (var item in tests)
        {
            var name = item.Name;
            result.Add(name);

        }
        return result;

    }

    public string WriteMedications(string PatientId, string DoctorId, string type, List<string> medicines)
    {

        if (string.Equals(type, "Doctor", StringComparison.OrdinalIgnoreCase))
        {
            Patient patient = _context.Patient.Where(x => x.NationalId.Equals(PatientId)).FirstOrDefault();
            int patientid = patient.Id;
            Doctor doctor = _context.Doctor.Where(x => x.NationalId.Equals(DoctorId)).FirstOrDefault();
            int doctorid = doctor.Id;

            _historyService.Add(patientid, doctorid, medicines);

            return "Medicines has been written successfully";
        }
        else
        {
            return "Unauthorized";

        }
    }
}
}



       
  

