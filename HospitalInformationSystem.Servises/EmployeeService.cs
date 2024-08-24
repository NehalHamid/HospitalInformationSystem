using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalInformationSystem.Services
{
    public class EmployeeService
    {
        IRepository<Employee> _repository;
        public static ApplicationDbContext _context;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }


        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = _repository.GetAll();

            List<EmployeeDTO> result = [];
            foreach (var item in employees)
            {
                EmployeeDTO viewModel = new()
                {
                    FullName = item.FullName,
                    Email = item.Email,
                    Password = item.Password,
                    NationalId = item.NationalId,
                    Phone = item.Phone

                };
                result.Add(viewModel);
            }
            return result;

        }

        /*public void Update(EmployeeDTO employeeDTO)
        {
            Employee employee = new ()
            {
                FullName = employeeDTO.FullName,
                Email = employeeDTO.Email,
                Password = employeeDTO.Password,
                NationalId = employeeDTO.NationalId,
                Phone = employeeDTO.Phone



            };

            _repository.Update(employee);
        }
*/

        public EmployeeDTO ShowProfile(string type,string ID)
        {
            if (string.Equals(type, "Employee", StringComparison.OrdinalIgnoreCase))
            {
                Employee employee = _context.Employee.FirstOrDefault(x => x.NationalId == ID);

                EmployeeDTO result = new()
                {
                    FullName = employee.FullName,
                    Email = employee.Email,
                    Password = employee.Password,
                    NationalId = employee.NationalId,
                    Phone = employee.Phone
                };
                return result;

            }
            else
            {
                EmployeeDTO resultBad = new();

                return resultBad;
            }

        }


    }
}
