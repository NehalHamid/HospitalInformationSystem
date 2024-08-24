/*using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using System.IO;

namespace HospitalInformationSystem.Services
{
    public class HospitalDepartmentService
    {
        IRepository<Hospital> _HospitalRepository;
        IRepository<Department> _DepartmentRepository;
        IBridgeRepository<HospitalDepartment> _BridgeRepository;
        ApplicationDbContext _context;
        public HospitalDepartmentService(IBridgeRepository<HospitalDepartment> BridgeRepository,
            IRepository<Hospital> HospitalRepository, IRepository<Department> DepartmentRepository, ApplicationDbContext context)
        {
            _BridgeRepository = BridgeRepository;
            _HospitalRepository = HospitalRepository;
            _DepartmentRepository = DepartmentRepository;
            _context = context;
        }
        public void Add(int hospitalId, int departmentId, HospitalDepartmentDTO hospitalDepartmentDTO)
        {
            var hospital = _HospitalRepository.GetById(hospitalId);
            var department = _DepartmentRepository.GetById(departmentId);
            if (hospital is null || department is null)
                return;

            else
            {
                HospitalDepartment hospitalDepartment = new()
                {
                    HospitalId = hospitalId,
                    DepartmentId = departmentId,
                    NumberOfClinics=hospitalDepartmentDTO.NumberOfClinics,
                    NumberOfEmployees = hospitalDepartmentDTO.NumberOfEmployees,
                    Floor=hospitalDepartmentDTO.Floor,
                    NumberOfOperationsRooms= hospitalDepartmentDTO.NumberOfOperationsRooms
                };
                _BridgeRepository.Add(hospitalDepartment);

            }
        }


        public List<HospitalDTO> GetHospitals(int departmentId)
        {
            //list to store doctor in each hospital
            var hospitals = new List<Hospital>();
            //get all doctors for selected hospital
            var hospitalDepartments = _BridgeRepository.Search(expression: x => x.DepartmentId == departmentId);

            //list to store doctors id 
            List<int> hospitalsId = [];
            //looping on query result and store doctors id in  doctorsId list 
            foreach (var item in hospitalDepartments)
            {
                hospitalsId.Add(item.HospitalId);
            }
            //get each doctor by id
            foreach (int id in hospitalsId)
            {
                var hospital = _HospitalRepository.GetById(id);
                hospitals.Add(hospital);
            }
            //taking list of object from DoctorDTO
            var hospitalDTO = new List<HospitalDTO>();
            //looping on Doctors list 
            foreach (var item in hospitals)
            {
                // Define new object from DoctorDTO and filling its properties by item from  doctor list

                HospitalDTO hospital = new()
                {
                    Name=item.Name, 
                    City=item.City, 
                    Region=item.Region, 
                    Street=item.Street, 
                    Type=item.Type, 

            };

                hospitalDTO.Add(hospital);
            }
            return hospitalDTO;
        }
    public IEnumerable<DepartmentDTO> GetDepartments(int departmentId)
        {
            //list to store patients for each doctor
            var departments = new List<Department>();
            //get all patients  for selected doctors

            var departmentsHospital = _BridgeRepository.Search(expression: x => x.DepartmentId == departmentId);
            //list to store hospitals id 
            List<int> list = [];
            //looping on query result and store hospitals id in  hospitalsId list 

            foreach (var item in departmentsHospital)
            {
                list.Add(item.DepartmentId);
            }
            //get each hospital by id
            foreach (var item in list)
            {
                var department = _DepartmentRepository.GetById(item);
                departments.Add(department);
            }
            //taking list of object from hospitalDTO

            var departmentDTO = new List<DepartmentDTO>();
            //looping on hospitals list 

            foreach (var item in departments)
            {
                // Define new object from hospitalDTO and filling its properties by item from  hospitals list

                DepartmentDTO department = new()
                {
                    Name = item.Name,

                };

                departmentDTO.Add(department);
            }
            return departmentDTO;
        }
        public void Update(HospitalDepartmentDTO departmentDTO, int hospitalId, int departmentId)
        {

            HospitalDepartment hospitalDepartment = new()
            {
                HospitalId = hospitalId,
                DepartmentId = departmentId,
                NumberOfClinics=departmentDTO.NumberOfClinics,
                NumberOfEmployees=departmentDTO.NumberOfEmployees,
                NumberOfOperationsRooms=departmentDTO.NumberOfOperationsRooms,
                Floor=departmentDTO.Floor

            };
            _BridgeRepository.Update(hospitalDepartment);

        }
        public HospitalDepartment Search(int hospitalId, int departmentId)
        {
            HospitalDepartment hospitalDepartment = _BridgeRepository.
                GetById(expression: x => x.HospitalId == hospitalId && x.DepartmentId == departmentId);
            return hospitalDepartment;
        }
    }
}
*/