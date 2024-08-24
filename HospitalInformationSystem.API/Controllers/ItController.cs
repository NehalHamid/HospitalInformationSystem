using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItController: ControllerBase
    {
        public static ApplicationDbContext _context;
        private readonly ItService _service;

        public ItController( ApplicationDbContext context, ItService service)
        {

            _context = context;
            _service = service;
        }


        [HttpPost("Add")]
        public ActionResult Add([FromBody] FormData data) {
            if (data.Type.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
            {
                DoctorDTO doctor = new()
                {
                    FullName = data.DoctorName,
                    Password = data.DoctorPassword,
                    Email = data.DoctorEmail,
                    Phone = data.DoctorPhone,
                    Gender = data.DoctorGender,
                    NationalId = data.DoctorNationalId,
                    Salary = data.DoctorSalary,
                    Department = data.DoctorDepartment,
                    BirthDate = data.DoctorBirthDate,
                    DoctorPicture = data.DoctorPicture

                };

                var result = _service.AddDoctor(data,doctor);
                if (result != "Unauthorized")
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized("Bad");

                }

            }
            else if(data.Type.Equals("Nurse", StringComparison.OrdinalIgnoreCase))
            {
                NurseDTO nurse = new()
                {

                    FullName = data.NurseName,
                    Email = data.NurseEmail,
                    Password = data.NursePassword,
                    NationalId = data.NurseNationalId,
                    Phone = data.NursePhone,
                    TimeSlot = data.NurseTimeSlot,
                    Salary = data.NurseSalary,
                    Gender=data.NurseGender,
                    Department=data.NurseDepartment,
                    BirthDate=data.NurseBirthDate,
                    Image= data.NurseImage,
                };

                string result = _service.AddNurse(data, nurse);
                if (result != "Unauthorized")
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized("Bad");

                }

            }
            else if(data.Type.Equals("XRay", StringComparison.OrdinalIgnoreCase))
            {

                EmployeeDTO employee = new()
                {
                    FullName= data.EmployeeName,
                    Email = data.EmployeeEmail,
                    Password = data.EmployeePassword,
                    Phone = data.EmployeePhone,
                    Gender = data.EmployeeGender,
                    Department=data.EmployeeDepartment,
                    BirthDate=data.EmployeeBirthDate,
                    Image= data.EmployeeImage,
                    NationalId=data.EmployeeNationalId,
                    Salary=data.EmployeeSalary,
                    TypeOfEmployee="XRay",
                };

                var result = _service.AddEmployee(data, employee);
                if (result != "Unauthorized")
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized("Bad");

                }
            }
            else if(data.Type.Equals("Test", StringComparison.OrdinalIgnoreCase))
            {
                EmployeeDTO employee = new()
                {
                    FullName = data.EmployeeName,
                    Email = data.EmployeeEmail,
                    Password = data.EmployeePassword,
                    Phone = data.EmployeePhone,
                    Gender = data.EmployeeGender,
                    Department = data.EmployeeDepartment,
                    BirthDate = data.EmployeeBirthDate,
                    Image = data.EmployeeImage,
                    NationalId = data.EmployeeNationalId,
                    Salary = data.EmployeeSalary,
                    TypeOfEmployee = "Test",
                };

                var result = _service.AddEmployee(data, employee);
                if (result != "Unauthorized")
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized("Bad");

                }
            }
            else if (data.Type.Equals("Pharmacy", StringComparison.OrdinalIgnoreCase))
            {
                EmployeeDTO employee = new()
                {
                    FullName = data.EmployeeName,
                    Email = data.EmployeeEmail,
                    Password = data.EmployeePassword,
                    Phone = data.EmployeePhone,
                    Gender = data.EmployeeGender,
                    Department = data.EmployeeDepartment,
                    BirthDate = data.EmployeeBirthDate,
                    Image = data.EmployeeImage,
                    NationalId = data.EmployeeNationalId,
                    Salary = data.EmployeeSalary,
                    TypeOfEmployee = "Pharmacy",
                };

                var result = _service.AddEmployee(data, employee);
                if (result != "Unauthorized")
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized("Bad");

                }
            }
            else if (data.Type.Equals("Reception", StringComparison.OrdinalIgnoreCase))
            {
                EmployeeDTO employee = new()
                {
                    FullName = data.EmployeeName,
                    Email = data.EmployeeEmail,
                    Password = data.EmployeePassword,
                    Phone = data.EmployeePhone,
                    Gender = data.EmployeeGender,
                    Department = data.EmployeeDepartment,
                    BirthDate = data.EmployeeBirthDate,
                    Image = data.EmployeeImage,
                    NationalId = data.EmployeeNationalId,
                    Salary = data.EmployeeSalary,
                    TypeOfEmployee = "Reception",
                };

                var result = _service.AddEmployee(data, employee);
                if (result != "Unauthorized")
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized("Bad");

                }
            }
            else
            {
                return Unauthorized("Bad");

            }

        }



        [HttpDelete("Delete/{NID}")]
        public IActionResult Delete(string NID)
        {
            var result = ItService.Delete(NID);
            if (result == "NotFound")
            {
                return NotFound("Item not found");
            }
            else
            {
                return Ok("Item deleted successfully");
            }

        }


        [HttpGet("GetInfo")]
        public ActionResult GetInfo(string Role, string ID)
        {
            //if (data.Type.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
            if (Role.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
            {
                Doctor doctor = _context.Doctor.FirstOrDefault(x => x.NationalId == ID);
                DoctorDTO doctor1 = new()
                {
                    FullName = doctor.FullName,
                    Email = doctor.Email,
                    Password = doctor.Password,
                    Department = doctor.Department,
                    BirthDate = doctor.BirthDate,
                    Gender = doctor.Gender,
                    NationalId = doctor.NationalId,
                    Phone = doctor.Phone,
                    Salary = doctor.Salary,
                    Specialization = doctor.Specialization,
                    Image = doctor.DoctorPicture
                };

                if (doctor is not null)
                {
                    return Ok(doctor1);
                }
                else
                {
                    return BadRequest("NotFound");

                }

            }
            else if (Role.Equals("Nurse", StringComparison.OrdinalIgnoreCase))
            {
                Nurse nurse = _context.Nurse.FirstOrDefault(x => x.NationalId == ID);
                NurseDTO nurse1 = new()
                {
                    FullName = nurse.FullName,
                    Email = nurse.Email,
                    Password = nurse.Password,
                    Department = nurse.Department,
                    BirthDate = nurse.BirthDate,
                    Gender = nurse.Gender,
                    NationalId = nurse.NationalId,
                    Phone = nurse.Phone,
                    Salary = nurse.Salary,
                    Image = nurse.Image
                };

                if (nurse is not null)
                {
                    return Ok(nurse1);
                }
                else
                {
                    return BadRequest("NotFound");

                }

            }
            else if (Role.Equals("XRay", StringComparison.OrdinalIgnoreCase))
            {

                Employee employee = _context.Employee.FirstOrDefault(x => x.NationalId == ID);
                EmployeeDTO employee1 = new()
                {
                    FullName = employee.FullName,
                    Email = employee.Email,
                    Password = employee.Password,
                    Department = employee.Department,
                    BirthDate = employee.BirthDate,
                    Gender = employee.Gender,
                    NationalId = employee.NationalId,
                    Phone = employee.Phone,
                    Salary = employee.Salary,
                    Image = employee.Image
                };

                if (employee is not null)
                {
                    return Ok(employee1);
                }
                else
                {
                    return BadRequest("NotFound");

                }
            }
            else if (Role.Equals("Test", StringComparison.OrdinalIgnoreCase))
            {
                Employee employee = _context.Employee.FirstOrDefault(x => x.NationalId == ID);
                EmployeeDTO employee1 = new()
                {
                    FullName = employee.FullName,
                    Email = employee.Email,
                    Password = employee.Password,
                    Department = employee.Department,
                    BirthDate = employee.BirthDate,
                    Gender = employee.Gender,
                    NationalId = employee.NationalId,
                    Phone = employee.Phone,
                    Salary = employee.Salary,
                    Image = employee.Image
                };

                if (employee is not null)
                {
                    return Ok(employee1);
                }
                else
                {
                    return BadRequest("NotFound");

                }
            }
            else if (Role.Equals("Pharmacy", StringComparison.OrdinalIgnoreCase))
            {
                Employee employee = _context.Employee.FirstOrDefault(x => x.NationalId == ID);
                EmployeeDTO employee1 = new()
                {
                    FullName = employee.FullName,
                    Email = employee.Email,
                    Password = employee.Password,
                    Department = employee.Department,
                    BirthDate = employee.BirthDate,
                    Gender = employee.Gender,
                    NationalId = employee.NationalId,
                    Phone = employee.Phone,
                    Salary = employee.Salary,
                    Image = employee.Image
                };

                if (employee is not null)
                {
                    return Ok(employee1);
                }
                else
                {
                    return BadRequest("NotFound");

                }
            }
            else if (Role.Equals("Reception", StringComparison.OrdinalIgnoreCase))
            {
                Employee employee = _context.Employee.FirstOrDefault(x => x.NationalId == ID);
                EmployeeDTO employee1 = new()
                {
                    FullName = employee.FullName,
                    Email = employee.Email,
                    Password = employee.Password,
                    Department = employee.Department,
                    BirthDate = employee.BirthDate,
                    Gender = employee.Gender,
                    NationalId = employee.NationalId,
                    Phone = employee.Phone,
                    Salary = employee.Salary,
                    Image = employee.Image
                };

                if (employee is not null)
                {
                    return Ok(employee1);
                }
                else
                {
                    return BadRequest("NotFound");

                }
            }
            else
            {
                return BadRequest("NotFound");

            }


        }



        /* [HttpPut("Update/{NID}")]
         public IActionResult Update(string NID, [FromBody] FormData data)
         {
             if (data.Type.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
             {


                 var result = ItService.UpdateDoctor(NID, data);
                 if (result == "Successfully Updated")
                 {
                     return Ok(result);
                 }
                 else
                 {
                     return Unauthorized("Bad");

                 }

             }
             return null;
         }*/

        /*DoctorDTO doctor = new()
                {
                    FullName = data.DoctorName,
                    Password = data.DoctorPassword,
                    Email = data.DoctorEmail,
                    Phone = data.DoctorPhone,
                    Gender = data.DoctorGender,
                    NationalId = data.DoctorNationalId,
                    Salary = data.DoctorSalary,
                    Department = data.DoctorDepartment,
                    BirthDate = data.DoctorBirthDate,
                    DoctorPicture = data.DoctorPicture

                };*/



        /*else if (data.Type.Equals("Nurse", StringComparison.OrdinalIgnoreCase))
        {
            NurseDTO nurse = new()
            {

                FullName = data.NurseName,
                Email = data.NurseEmail,
                Password = data.NursePassword,
                NationalId = data.NurseNationalId,
                Phone = data.NursePhone,
                TimeSlot = data.NurseTimeSlot,
                Salary = data.NurseSalary,
                Gender = data.NurseGender,
                Department = data.NurseDepartment,
                BirthDate = data.NurseBirthDate,
                Image = data.NurseImage,
            };

            string result = _service.AddNurse(data, nurse);
            if (result != "Unauthorized")
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized("Bad");

            }

        }
        else if (data.Type.Equals("XRay", StringComparison.OrdinalIgnoreCase))
        {

            EmployeeDTO employee = new()
            {
                FullName = data.EmployeeName,
                Email = data.EmployeeEmail,
                Password = data.EmployeePassword,
                Phone = data.EmployeePhone,
                Gender = data.EmployeeGender,
                Department = data.EmployeeDepartment,
                BirthDate = data.EmployeeBirthDate,
                Image = data.EmployeeImage,
                NationalId = data.EmployeeNationalId,
                Salary = data.EmployeeSalary,
                TypeOfEmployee = "XRay",
            };

            var result = _service.AddEmployee(data, employee);
            if (result != "Unauthorized")
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized("Bad");

            }
        }
        else if (data.Type.Equals("Test", StringComparison.OrdinalIgnoreCase))
        {
            EmployeeDTO employee = new()
            {
                FullName = data.EmployeeName,
                Email = data.EmployeeEmail,
                Password = data.EmployeePassword,
                Phone = data.EmployeePhone,
                Gender = data.EmployeeGender,
                Department = data.EmployeeDepartment,
                BirthDate = data.EmployeeBirthDate,
                Image = data.EmployeeImage,
                NationalId = data.EmployeeNationalId,
                Salary = data.EmployeeSalary,
                TypeOfEmployee = "Test",
            };

            var result = _service.AddEmployee(data, employee);
            if (result != "Unauthorized")
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized("Bad");

            }
        }
        else if (data.Type.Equals("Pharmacy", StringComparison.OrdinalIgnoreCase))
        {
            EmployeeDTO employee = new()
            {
                FullName = data.EmployeeName,
                Email = data.EmployeeEmail,
                Password = data.EmployeePassword,
                Phone = data.EmployeePhone,
                Gender = data.EmployeeGender,
                Department = data.EmployeeDepartment,
                BirthDate = data.EmployeeBirthDate,
                Image = data.EmployeeImage,
                NationalId = data.EmployeeNationalId,
                Salary = data.EmployeeSalary,
                TypeOfEmployee = "Pharmacy",
            };

            var result = _service.AddEmployee(data, employee);
            if (result != "Unauthorized")
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized("Bad");

            }
        }
        else if (data.Type.Equals("Reception", StringComparison.OrdinalIgnoreCase))
        {
            EmployeeDTO employee = new()
            {
                FullName = data.EmployeeName,
                Email = data.EmployeeEmail,
                Password = data.EmployeePassword,
                Phone = data.EmployeePhone,
                Gender = data.EmployeeGender,
                Department = data.EmployeeDepartment,
                BirthDate = data.EmployeeBirthDate,
                Image = data.EmployeeImage,
                NationalId = data.EmployeeNationalId,
                Salary = data.EmployeeSalary,
                TypeOfEmployee = "Reception",
            };

            var result = _service.AddEmployee(data, employee);
            if (result != "Unauthorized")
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized("Bad");

            }
        }
        else
        {
            return Unauthorized("Bad");

        }

    }*/



        [HttpPut("Update/{NID}")]
        public IActionResult Update(string NID, [FromBody] UpdateForm data)
        {

            var result =  ItService.Update(NID, data);
            if (result == "Successfully Updated")
            {
                return Ok("Item Updated successfully");

            }
            return NotFound("Item not found");


        }




    }
}
