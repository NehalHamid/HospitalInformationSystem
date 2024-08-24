using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalInformationSystem.DTO;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace HospitalInformationSystem.Services
{
    public class ItService
    {
        //IRepository<Doctor> _repository;
        //public static HistoryService _historyService;

        public static ApplicationDbContext _context;
        IRepository<Doctor> _doctorrepository;
        IRepository<Nurse> _nurserepository;
        IRepository<Employee> _employeerepository;



        public ItService(ApplicationDbContext context, IRepository<Doctor> doctorrepository,
             IRepository<Nurse> nurserepository, IRepository<Employee> employeerepository)
        {
            _context = context;
            _doctorrepository = doctorrepository;
            _nurserepository = nurserepository;
            _employeerepository = employeerepository;


        }

        public string AddDoctor(FormData form,DoctorDTO data)
        {
            if (form.Role.Equals("IT", StringComparison.OrdinalIgnoreCase))
            {
                Doctor doctor = new()
                {
                    FullName = data.FullName,
                    Password = data.Password,
                    Email = data.Email,
                    Phone = data.Phone,
                    Gender = data.Gender,
                    NationalId = data.NationalId,
                    Salary = data.Salary,
                    Department = data.Department,
                    BirthDate = data.BirthDate,
                    DoctorPicture = data.DoctorPicture,
                    Type = "Doctor"
                };
                string success = _doctorrepository.Add(doctor);
                if (success is not null)
                    return success;

                else
                    return null;
            }
            else
            {
                return "Unauthorized";
            }         

        }

        public string AddNurse(FormData form, NurseDTO data)
        {
            if (form.Role.Equals("IT", StringComparison.OrdinalIgnoreCase))
            {
                Nurse nurse = new()
                {
                    FullName = data.FullName,
                    Email = data.Email,
                    Password = data.Password,
                    NationalId = data.NationalId,
                    Phone = data.Phone,
                    TimeSlot = data.TimeSlot,
                    Salary = data.Salary,
                };
                string success = _nurserepository.Add(nurse);
                if (success is not null)
                    return success;

                else
                    return null;
            }
            else
            {
                return "Unauthorized";

            }
        }

        public string AddEmployee(FormData form, EmployeeDTO data)
        {
            if (form.Role.Equals("IT", StringComparison.OrdinalIgnoreCase))
            {

                Employee employee = new()
                {
                    FullName = data.FullName,
                    Email = data.Email,
                    Password = data.Password,
                    NationalId = data.NationalId,
                    Phone = data.Phone,
                    Gender= data.Gender,
                    Salary= (decimal)data.Salary,
                    Department= data.Department,
                    BirthDate= data.BirthDate,
                    Image= data.Image,
                    Type = "Employee",
                    TypeOfEmployee=form.TypeOfEmployee
                };
                string success = _employeerepository.Add(employee);
                if (success is not null)
                    return success;

                else
                    return null;
            }
            else
            {
                return "Unauthorized";

            }

        }


        public static string Delete(string NID)
        {
            var doctor = _context.Doctor.FirstOrDefault(x=>x.NationalId== NID);
            if (doctor != null)
            {
                _context.Remove(doctor);
                _context.SaveChanges();
                return "Success";
            }

            var nurse = _context.Nurse.FirstOrDefault(x => x.NationalId == NID);
            if (nurse != null)
            {
                _context.Remove(nurse);
                _context.SaveChanges();
                return "Success";
            }

            var employee = _context.Employee.FirstOrDefault(x => x.NationalId == NID);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChanges();
                return "Success";
            }

            return "NotFound";
        }

  
        /*  public static string UpdateDoctor(string NID,FormData data)
          {
              var doctor = _context.Doctor.FirstOrDefault(x => x.NationalId == NID);
              if (doctor != null)
              {
                  doctor.FullName = data.DoctorName ?? doctor.FullName;
                  doctor.Gender = data.DoctorGender ?? doctor.Gender;
                  doctor.Email = data.DoctorEmail ?? doctor.Email;
                  doctor.Password = data.DoctorPassword ?? doctor.Password;
                  doctor.DoctorPicture = data.DoctorPicture ?? doctor.DoctorPicture;
                  doctor.Phone = data.DoctorPhone ?? doctor.Phone;
                  doctor.Department = data.DoctorDepartment ?? doctor.Department;
                  doctor.Salary = data.DoctorSalary ?? doctor.Salary;
                  doctor.NationalId = data.DoctorNationalId ?? doctor.NationalId;
                  doctor.BirthDate = data.DoctorBirthDate ?? doctor.BirthDate;
              }
              // Mark entity as modified
              //_context.Entry(doctor).State = EntityState.Modified;

              // Save changes
              _context.SaveChanges();
              return "Successfully Updated";


          }*/

        /*Doctor doctor = new()
               {
                   FullName = data.FullName,
                   Password = data.Password,
                   Email = data.Email,
                   Phone = data.Phone,
                   Gender = data.Gender,
                   NationalId = data.NationalId,
                   Salary = data.Salary,
                   Department = data.Department,
                   BirthDate = data.BirthDate,
                   DoctorPicture = data.DoctorPicture,
                   Type = "Doctor"
               };*/



        public static string Update(string NID, UpdateForm data)
        {
            if (data.Type == "Doctor")
            {
                // Check if it's a doctor
                var doctor =  _context.Doctor.FirstOrDefault(x => x.NationalId == NID);
                Console.WriteLine(doctor);
                if (doctor != null)
                {
                    doctor.FullName = data.DoctorName ?? doctor.FullName;
                    doctor.Gender = data.DoctorGender ?? doctor.Gender;
                    doctor.Email = data.DoctorEmail ?? doctor.Email;
                    doctor.Password = data.DoctorPassword ?? doctor.Password;
                    doctor.DoctorPicture = data.DoctorPicture ?? doctor.DoctorPicture;
                    doctor.Phone = data.DoctorPhone ?? doctor.Phone;
                    doctor.Department = data.DoctorDepartment ?? doctor.Department;
                    doctor.Salary = data.DoctorSalary ?? doctor.Salary;
                    doctor.NationalId = data.DoctorNationalId ?? doctor.NationalId;
                    doctor.BirthDate = data.DoctorBirthDate ?? doctor.BirthDate;

                    // Mark entity as modified
                    _context.Entry(doctor).State = EntityState.Modified;

                    // Save changes
                     _context.SaveChanges();
                    return "Successfully Updated";


                }
                else
                {
                    return "NotFound";
                }


            }else if (data.Type == "Nurse")
            {
                // Check if it's a nurse
                var nurse = _context.Nurse.FirstOrDefault(x => x.NationalId == NID);
                if (nurse != null)
                {
                    nurse.FullName = data.NurseName ?? nurse.FullName;
                    nurse.Gender = data.NurseGender ?? nurse.Gender;
                    nurse.Email = data.NurseEmail ?? nurse.Email;
                    nurse.Password = data.NursePassword ?? nurse.Password;
                    nurse.Image = data.NursePicture ?? nurse.Image;
                    nurse.Phone = data.NursePhone ?? nurse.Phone;
                    nurse.Salary = data.NurseSalary ?? nurse.Salary;

                    // Mark entity as modified
                    _context.Entry(nurse).State = EntityState.Modified;

                    // Save changes
                    _context.SaveChanges();
                    return "Successfully Updated";
                }
                else
                {
                    return "NotFound";
                }

            }
            else if(data.Type=="Employee")
            {

                // Check if it's an employee
                var employee = _context.Employee.FirstOrDefault(x => x.NationalId == NID);
                if (employee != null)
                {
                    employee.FullName = data.EmployeeName ?? employee.FullName;
                    employee.Email = data.EmployeeEmail ?? employee.Email;
                    employee.Phone = data.EmployeePhone ?? employee.Phone;
                    employee.Gender = data.EmployeeGender ?? employee.Gender;
                    employee.NationalId = data.EmployeeNationalId ?? employee.NationalId;
                    employee.Salary = data.EmployeeSalary ?? employee.Salary;
                    employee.Department = data.EmployeeDepartment ?? employee.Department;
                    employee.BirthDate = data.EmployeeBirthDate ?? employee.BirthDate;
                    employee.Image = data.EmployeePicture ?? employee.Image;
                    employee.TypeOfEmployee = data.TypeOfEmployee ?? employee.TypeOfEmployee;

                    // Mark entity as modified
                    _context.Entry(employee).State = EntityState.Modified;

                    // Save changes
                    _context.SaveChanges();
                    return "Successfully Updated";
                }
                else
                {
                    return "NotFound";
                }

            }
            else
            {
                return "NotFound";
            }

            

        }


        /*        public static async Task<string> Update(string NID, FormData data)
                {

                    var doctor = await _context.Doctor.FirstOrDefaultAsync(x => x.NationalId == NID);
                    if (doctor != null)
                    {

                        // Update the existing entity with the new values
                        doctor.FullName = data.DoctorName ?? doctor.FullName;
                        doctor.Gender = data.DoctorGender ?? doctor.Gender;
                        doctor.Email = data.DoctorEmail ?? doctor.Email;
                        doctor.Password = data.DoctorPassword ?? doctor.Password;
                        doctor.IdPicture = data.DoctorIdPicture ?? doctor.IdPicture;
                        doctor.DoctorPicture = data.DoctorPicture ?? doctor.DoctorPicture;
                        doctor.Phone = data.DoctorPhone ?? doctor.Phone;
                        doctor.Specialization = data.DoctorSpecialization ?? doctor.Specialization;
                        doctor.Salary = data.DoctorSalary != null ? data.DoctorSalary : doctor.Salary;

                        // Mark entity as modified
                        _context.Entry(doctor).State = EntityState.Modified;

                        // Save changes asynchronously
                        await _context.SaveChangesAsync();
                        return "Successfully Updated";
                    }

                    var nurse = await _context.Doctor.FirstOrDefaultAsync(x => x.NationalId == id);
                    if (nurse != null)
                    {

                        // Update the existing entity with the new values
                        nurse.FullName = data.DoctorName ?? nurse.FullName;
                        nurse.Gender = data.DoctorGender ?? nurse.Gender;
                        nurse.Email = data.DoctorEmail ?? nurse.Email;
                        nurse.Password = data.DoctorPassword ?? nurse.Password;
                        nurse.IdPicture = data.DoctorIdPicture ?? nurse.IdPicture;
                        nurse.DoctorPicture = data.DoctorPicture ?? nurse.DoctorPicture;
                        nurse.Phone = data.DoctorPhone ?? nurse.Phone;
                        nurse.Specialization = data.DoctorSpecialization ?? nurse.Specialization;
                        nurse.Salary = data.DoctorSalary != null ? data.DoctorSalary : nurse.Salary;

                        // Mark entity as modified
                        _context.Entry(nurse).State = EntityState.Modified;

                        // Save changes asynchronously
                        await _context.SaveChangesAsync();
                        return "Successfully Updated";
                    }

                    var employee = await _context.Employee.FirstOrDefaultAsync(x => x.NationalId == id);
                    if (employee != null)
                    {
                        employee.FullName = data.EmployeeName;
                        employee.Email = data.EmployeeEmail;
                        employee.Phone = data.EmployeePhone;
                        employee.Gender = data.EmployeeGender;
                        employee.NationalId = data.EmployeeNationalId;
                        employee.Salary = data.EmployeeSalary;
                        employee.Department = data.EmployeeDepartment;
                        employee.BirthDate = data.EmployeeBirthDate;
                        employee.Image = data.EmployeeImage;
                        employee.TypeOfEmployee = data.TypeOfEmployee;
                        _context.SaveChanges();
                        return "Success";
                    }

                    return "NotFound";
                }*/


    }
}
