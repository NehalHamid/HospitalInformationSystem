using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        readonly EmployeeService _employeeService;
        public static ApplicationDbContext _context;


        public EmployeeController(EmployeeService employeeService, ApplicationDbContext context)
        {

            _employeeService = employeeService;
            _context = context;
        }



        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);

        }




        /*  [Authorize(Roles = "IT")]
          [HttpPatch]
          public void UpdateEmployee(EmployeeDTO viewModel)
          {
              _employeeService.Update(viewModel);
          }*/


        //[Authorize(Roles = "Employee")]
        [HttpGet("ShowProfile")]
        public IActionResult ShowProfile(string type,string ID)
        {
            EmployeeDTO employee = _employeeService.ShowProfile(type,ID);
            if(employee != null)
            {
                return Ok(employee);

            }
            else
            {
                EmployeeDTO resultBad= new EmployeeDTO();
                return Unauthorized(resultBad);
            }

        }

    }
}
