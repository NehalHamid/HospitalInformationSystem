/*using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.DTO.DTO;

namespace HospitalInformationSystem.Services
{
    public class DoctorHospitalServices
    {
        IRepository<Doctor> _DoctorRepository;
        IRepository<Hospital> _HospitalRepository;
        IBridgeRepository<DoctorHospital> _BridgeRepository;
        ApplicationDbContext _context;
        public DoctorHospitalServices(IBridgeRepository<DoctorHospital> BridgeRepository,
            IRepository<Doctor> DoctorRepository, IRepository<Hospital> HospitalRepository, ApplicationDbContext context)
        {
            _BridgeRepository = BridgeRepository;
            _DoctorRepository = DoctorRepository;
            _HospitalRepository = HospitalRepository;
            _context = context;
        }
        public void Add(int doctorId, int HospitalId, DoctorHospitalDTO doctorHospitalDTO)
        {
            var doctor1 = _DoctorRepository.GetById(doctorId);
            var hospital = _HospitalRepository.GetById(HospitalId);
            if (hospital is null || doctor1 is null)
                return;

            else
            {
                DoctorHospital doctorHospital = new()
                {
                    HospitalId = HospitalId,
                    DoctorId = doctorId,
                    HiringDate = doctorHospitalDTO.HiringDate,
                    TimeSlot = doctorHospitalDTO.TimeSlot,
                    NetSalary = doctorHospitalDTO.NetSalary,
                };
                _BridgeRepository.Add(doctorHospital);

            }
        }


        public List<DoctorDTO> GetDoctors(int hospitalId)
        {
            //list to store doctor in each hospital
            var doctors = new List<Doctor>();
            //get all doctors for selected hospital
            var doctorsInHospital = _BridgeRepository.Search(expression: x => x.HospitalId == hospitalId);
            //list to store doctors id 
            List<int> doctorsId = [];
            //looping on query result and store doctors id in  doctorsId list 
            foreach (var item in doctorsInHospital)
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

                    FullName = item.FullName,
                    Specialization = item.Specialization,
                    Gender = item.Gender,
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
        public IEnumerable<HospitalDTO> GetHospitals(int doctorId)
        {
            //list to store hospitals for each doctor
            var hospitals = new List<Hospital>();
            //get all hospital  for selected doctors

            var hospitalsId = _BridgeRepository.Search(expression: x => x.DoctorId == doctorId);
            //list to store hospitals id 
            List<int> list = [];
            //looping on query result and store hospitals id in  hospitalsId list 

            foreach (var item in hospitalsId)
            {
                list.Add(item.HospitalId);
            }
            //get each hospital by id
            foreach (var item in list)
            {
                var hospital = _HospitalRepository.GetById(item);
                hospitals.Add(hospital);
            }
            //taking list of object from hospitalDTO

            var hospitalDTO = new List<HospitalDTO>();
            //looping on hospitals list 

            foreach (var item in hospitals)
            {
                // Define new object from hospitalDTO and filling its properties by item from  hospitals list

                HospitalDTO hospital = new()
                {
                    City = item.City,
                    Name = item.Name,
                    Region = item.Region,
                    Street = item.Street,
                    Type = item.Type,

                };

                hospitalDTO.Add(hospital);
            }
            return hospitalDTO;
        }
        public void Update(DoctorHospitalDTO hospitalDTO, int doctorId, int hospitalId)
        {

            DoctorHospital doctorHospital = new()
            {
                DoctorId = doctorId,
                HospitalId = hospitalId,
                HiringDate = hospitalDTO.HiringDate,
                NetSalary = hospitalDTO.NetSalary,
                TimeSlot = hospitalDTO.TimeSlot,

            };
            _BridgeRepository.Update(doctorHospital);

        }
        public DoctorHospital Search(int hospitalId, int doctorId)
        {
            DoctorHospital doctorHospital = _BridgeRepository.
                GetById(expression: x => x.DoctorId == doctorId && x.HospitalId == hospitalId);
            return doctorHospital;
        }


    }
}
*/