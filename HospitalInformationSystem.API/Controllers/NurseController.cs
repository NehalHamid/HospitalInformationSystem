using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Action = HospitalInformationSystem.Models.Models.Action;

namespace HospitalInformationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly NurseService _nurseService;
        public static ApplicationDbContext _context;

        public NurseController(NurseService nurseService, ApplicationDbContext context)
        {

            _nurseService = nurseService;
            _context = context;

        }

        [HttpGet("GetAllNurses")]
        public IActionResult GetAllNurses()
        {
            var nurses = _nurseService.GetAll();
            return Ok(nurses);

        }




        //[Authorize(Roles = "Nurse")]
        [HttpGet("ShowProfile")]
        public IActionResult ShowProfile(string type,string ID)
        {
            NurseDTO nurse = _nurseService.ShowProfile(type,ID);
            if(nurse != null)
            {
                return Ok(nurse);

            }
            else
            {
                return Unauthorized("Unauthorized");
            }

        }



        [HttpGet("Medications")]
        public IActionResult Medications()
        {
            var medications = NurseService.Medications();
            if (medications != null)
            {
                return Ok(medications);

            }
            else
            {
                return Unauthorized("Unauthorized");
            }

        }

        [HttpPost("AddAction")]
        public IActionResult AddAction([FromBody] Action action)
        {
            var result = _nurseService.AddAction(action);
            if (result == "Action Added Successfully")
            {
                return Ok("Action Added Successfully");

            }
            else
            {
                return Unauthorized("Unauthorized");
            }

        }

        [HttpGet("GetAllShifts")]
        public IActionResult GetAllShifts()
        {
            var shifts = _nurseService.GetAllShifts();
            if (shifts != null)
            {
                return Ok(shifts);

            }
            else
            {
                return Unauthorized("Unauthorized");
            }

        }
    }
}
