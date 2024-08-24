using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Services
{
    public class PatientService
    {
        IRepository<Patient> _repository;
        ApplicationDbContext _context;

        public PatientService(IRepository<Patient> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;

        }

        ///////////////////////////////////////////// Show Profile //////////////////////////////////////////////

        public PatientDTO ShowProfile(string ID)
        {
            Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == ID);
            PatientDTO result = new()
            {
                 FullName = patient.FullName,
                 BirthDate=patient.BirthDate,
                 Gender=patient.Gender,
                 Phone = patient.Phone,
                 RelativePhone=patient.RelativePhone,
                 Email = patient.Email,
                 Password = patient.Password,
                 NationalId = patient.NationalId
             };
             return result;         

        }

        /* public void Update(PatientDTO patientDTO)
         {
             Patient patient = new ()
             {
                 FullName = patientDTO.FullName,
                 Email = patientDTO.Email,
                 Password = patientDTO.Password,
                 BirthDate = patientDTO.BirthDate,
                 NationalId = patientDTO.NationalId,
                 Phone = patientDTO.Phone,
                 RelativePhone = patientDTO.RelativePhone,
                 Type = patientDTO.Type,
                 Governorate = patientDTO.Governorate,
                 CityOrVillage = patientDTO.CityOrVillage,
                 DetailedAddress = patientDTO.DetailedAddress



             };

             _repository.Update(patient);

         }*/

        public IEnumerable<PatientDTO> GetAll()
        {
            var patients = _repository.GetAll();

            List<PatientDTO> result = [];
            foreach (var item in patients)
            {
                PatientDTO viewModel = new()
                {
                    FullName = item.FullName,
                    Email = item.Email,
                    Password = item.Password,
                    BirthDate = item.BirthDate,
                    Gender = item.Gender,
                    NationalId = item.NationalId,
                    Phone = item.Phone,
                    RelativePhone = item.RelativePhone,
                    Type = item.Type,
                    Governorate = item.Governorate,
                    CityOrVillage = item.CityOrVillage,
                    DetailedAddress = item.DetailedAddress

                };
                result.Add(viewModel);
            }
            return result;

        }


        public PatientDTO GetOnePatient(string id)
        {
            var patient = _context.Patient.FirstOrDefault(x => x.NationalId == id);
            PatientDTO viewModel = new()
            {

                FullName = patient.FullName,
                Email = patient.Email,
                Password = patient.Password,
                BirthDate = patient.BirthDate,
                NationalId = patient.NationalId,
                Gender = patient.Gender,
                Phone = patient.Phone,
                RelativePhone = patient.RelativePhone,
                Type = patient.Type,
                Governorate = patient.Governorate,
                CityOrVillage = patient.CityOrVillage,
                DetailedAddress = patient.DetailedAddress

            };

            return viewModel;

        }

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

        public PatientXraydto GetXrays(string email)
        {
            List<string> XRays = [];
            var patient = _context.Patient.FirstOrDefault(x => x.Email == email);
            string patientId= patient.NationalId;
            var histories = _context.History.Where(x => x.PatientNationalId == patientId).ToList();
            foreach (var item in histories)
            {
                if (item.XRay != null)
                {
                    XRays.Add(item.XRay);
                }
            }

            PatientXraydto history = new()
            {
                xrays = XRays
            };
            return history;

        }


        public PatientTestdto GetTests(string email)
        {
            List<string> Tests = [];
            var patient = _context.Patient.FirstOrDefault(x => x.Email == email);
            string patientId = patient.NationalId;
            var histories = _context.History.Where(x => x.PatientNationalId == patientId).ToList();
            foreach (var item in histories)
            {
                if (item.Test != null)
                {
                    Tests.Add(item.Test);
                }
            }

            PatientTestdto history = new()
            {
                tests = Tests
            };
            return history;

        }

        public PatientHistoryDTO GetHistory(string id) {
            List<string> xRays = [];
            List<string> tests = [];
            List<string> examines = [];
            List<string> diagnosis = [];
            List<string> medicines = [];

            var patient = _context.Patient.FirstOrDefault(x => x.NationalId == id);
            var histories = _context.History.Where(x=>x.PatientNationalId == id).ToList();
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
                if (item.Diagnosis != null)
                {
                    diagnosis.Add(item.Diagnosis);
                }
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
                Diagnosis = diagnosis,
                XRays = xRays,
                Tests = tests,
                Medicines = medicines
            };

            return history;

        }


/*
        public  List<string> GetHospitals()
        {
            var hospitals = _context.Hospital.ToList();
            List<string> result = [];
            foreach (var item in hospitals)
            {
                var name = item.Name;
                result.Add(name);

            }
            return result;

        }
*/
    /*    public  List<string> GetDepartments()
        {
            DepartmentDTO department = new DepartmentDTO();
            var departments = _context.Department.ToList();
            List<string> result = [];
            foreach (var item in departments)
            {
                var name = item.Name;
                result.Add(name);

            }
            return result;

        }
*/


        public string ReserveHospital(ReserveHospital reserve)
        {
            Reservations reservations = new()
            {
                PatientNationalId = reserve.nationalID,
                Name = reserve.hospital,
                DepartmentName = reserve.department,
                PatientName = reserve.name,
                date = DateTime.Now,
            };
            _context.Add(reservations);
            _context.SaveChanges();

            return "Successfully Reserved";

        }
        public List<Clinics> GetClinics(string region,string department)
        {
            List<Clinics> clinics = _context.Clinics.ToList();
            Console.WriteLine(clinics);
            List<Clinics> result = new();
            foreach (var item in clinics)
            {
                if(item.Region == region && item.Department == department)
                {
                    result.Add(item);
                }
            };

            return result;

        }

        public string ReserveClinic(Reserveclinic reserve)
        {
            Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == reserve.patientId);
            string patientname = patient.FullName;


            Clinics clinic = _context.Clinics.FirstOrDefault(x => x.Name == reserve.clinicName );
            string dapartment = clinic.Department;


            Reservations reservations = new()
            {
                PatientName = patientname,
                PatientNationalId = reserve.patientId,
                Name = reserve.clinicName,
                DepartmentName = dapartment,
                time = reserve.appointments[0]
            };
            _context.Add(reservations);
            _context.SaveChanges();

            return "Successfully Reserved";

        }

        public string FeedBack(FeedBacks feedback)
        {
            FeedBack result = new()
            {
                PatientNationalId = feedback.nationalID,
                NameOfService = feedback.Name,
                Rate = feedback.rate,
                FeedBackContent = feedback.feedback,
            };
            _context.Add(result);
            _context.SaveChanges();

            return "Successfully Added FeedBack";

        }



    }

}
