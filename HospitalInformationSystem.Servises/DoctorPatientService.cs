using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Services
{
    public class DoctorPatientService
    {
        IRepository<Doctor> _DoctorRepository;
        IRepository<Patient> _PatientRepository;
        IBridgeRepository<DoctorPatient> _BridgeRepository;
        ApplicationDbContext _context;
        public DoctorPatientService(IBridgeRepository<DoctorPatient> BridgeRepository,
            IRepository<Doctor> DoctorRepository, IRepository<Patient> PatientRepository, ApplicationDbContext context)
        {
            _BridgeRepository = BridgeRepository;
            _DoctorRepository = DoctorRepository;
            _PatientRepository = PatientRepository;
            _context = context;
        }
        public void Add(int doctorId, int PatientId, DoctorPatientDTO doctorPatientDTO)
        {
            var doctor1 = _DoctorRepository.GetById(doctorId);
            var patient= _PatientRepository.GetById(PatientId);
            if (patient is null || doctor1 is null)
                return;

            else
            {
                DoctorPatient doctorPatient = new()
                {
                    PatientId = PatientId,
                    DoctorId = doctorId,
                    DateOfVisiting = doctorPatientDTO.DateOfVisiting
                };
                _BridgeRepository.Add(doctorPatient);

            }
        }


    public List<DoctorDTO> GetDoctors(int patientId)
        {
            //list to store doctor in each hospital
            var doctors = new List<Doctor>();
            //get all doctors for selected hospital
            var doctorWithPatients = _BridgeRepository.Search(expression: x => x.PatientId == patientId);
            //list to store doctors id 
            List<int> doctorsId = [];
            //looping on query result and store doctors id in  doctorsId list 
            foreach (var item in doctorWithPatients)
            {
                doctorsId.Add(item.DoctorId);
            }
            //get each doctor by id
            foreach (int id in doctorsId)
            {
                var doctor = _DoctorRepository.GetById(id);
                doctors.Add(doctor);
            }
            //taking list of object from DoctorDTO
            var doctorDTO = new List<DoctorDTO>();
            //looping on Doctors list 
            foreach (var item in doctors)
            {
                // Define new object from DoctorDTO and filling its properties by item from  doctor list

                DoctorDTO doctor = new()
                {

                    FullName=item.FullName,
                    Specialization = item.Specialization,
                    //Gender = item.Gender,
                    DoctorPicture = item.DoctorPicture,
                    IdPicture = item.IdPicture,
                    Email = item.Email,
                    NationalId = item.NationalId,
                    Phone = item.Phone,
                    Password = item.Password
                };

                doctorDTO.Add(doctor);
            }
            return doctorDTO;
        }
    public IEnumerable<PatientDTO> GetPatients(int doctorId)
        {
            //list to store patients for each doctor
            var patients = new List<Patient>();
            //get all patients  for selected doctors

            var patientsId = _BridgeRepository.Search(expression: x => x.DoctorId == doctorId);
            //list to store hospitals id 
            List<int> list = [];
            //looping on query result and store hospitals id in  hospitalsId list 

            foreach (var item in patientsId)
            {
                list.Add(item.PatientId);
            }
            //get each hospital by id
            foreach (var item in list)
            {
                var patient = _PatientRepository.GetById(item);
                patients.Add(patient);
            }
            //taking list of object from hospitalDTO

            var patientDTO = new List<PatientDTO>();
            //looping on hospitals list 

            foreach (var item in patients)
            {
                // Define new object from hospitalDTO and filling its properties by item from  hospitals list

                PatientDTO patient = new()
                {
                    FullName = item.FullName,
                    Email = item.Email,
                    Password = item.Password,
                    BirthDate = item.BirthDate,
                    NationalId = item.NationalId,
                    Phone = item.Phone,
                    RelativePhone = item.RelativePhone,
                    Type = item.Type,
                    Governorate = item.Governorate,
                    CityOrVillage = item.CityOrVillage,
                    DetailedAddress = item.DetailedAddress

                };

                patientDTO.Add(patient);
            }
            return patientDTO;
        }
        public void Update(DoctorPatientDTO patientDTO, int doctorId, int patientId)
        {

            DoctorPatient doctorPatient = new()
            {
                PatientId = patientId,
                DoctorId = doctorId,
                DateOfVisiting = patientDTO.DateOfVisiting

            };
            _BridgeRepository.Update(doctorPatient);

        }
        public DoctorPatient Search(int patientId, int doctorId)
        {
            DoctorPatient doctorPatient = _BridgeRepository.
                GetById(expression: x => x.DoctorId == doctorId && x.PatientId == patientId);
            return doctorPatient;
        }
    }
}
