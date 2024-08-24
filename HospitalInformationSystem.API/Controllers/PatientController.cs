using Microsoft.AspNetCore.Mvc;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.Services;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Data;
using Microsoft.AspNetCore.Authorization;
using PatientService = HospitalInformationSystem.Services.PatientService;



namespace HospitalInformationSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController:ControllerBase
    {
        private readonly PatientService _patientService;
        public static HistoryService _historyService;
        public static ApplicationDbContext _context;



        public PatientController(PatientService patientService, HistoryService historyService, ApplicationDbContext context)
        {

            _patientService = patientService;
            _historyService = historyService;
            _context = context;
        }


        //[Authorize(Roles = "Patient")]
        [HttpGet("ShowProfile")]
        public IActionResult ShowProfile( string ID)
        {
            PatientDTO patient = _patientService.ShowProfile(ID);
            
                return Ok(patient);


        }

        //[Authorize(Roles = "Patient")]
        [HttpGet("GetHistory")]
        public IActionResult GetHistory(string ID)
        {
            PatientHistoryDTO history = _patientService.GetHistory(ID);

            return Ok(history);


        }
        
        [HttpGet("GetOnePatient")]
        public IActionResult GetOnePatient(string ID)
        {
            PatientDTO history = _patientService.GetOnePatient(ID);

            return Ok(history);


        }

        [HttpGet("GetAllPatient")]
        public IActionResult GetAllPatient()
        {
            List<PatientDTO> history = _patientService.GetAll().ToList();

            return Ok(history);


        }



/*        [HttpGet("GetHospitals")]
        public IActionResult GetHospitals()
        {
            List<string> result = _patientService.GetHospitals();

            return Ok(result);
        }

        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments()
        {
            List<string> result = _patientService.GetDepartments();

            return Ok(result);
        }
*/

        //[Authorize(Roles = "Patient")]

        [HttpPost("ReserveHospital")]
        public IActionResult ReserveHospital([FromBody] ReserveHospital reserve)
        {
            string result = _patientService.ReserveHospital(reserve);

            return Ok(result);
        }




        //[Authorize(Roles = "Patient")]

        [HttpPost("ReserveClinic")]
        public IActionResult ReserveClinic([FromBody] Reserveclinic clinic)
        {
            string result = _patientService.ReserveClinic(clinic);

            return Ok(result);
        }



        [HttpGet("GetClinics")]
        public IActionResult GetClinics([FromQuery] string selectedRegion, [FromQuery] string selectedDepartment)
        {
            List<Clinics> result = _patientService.GetClinics(selectedRegion,selectedDepartment);

            return Ok(result);
        }


        [HttpGet("GetXrays/{email}")]
        public IActionResult GetXrays(string email )
        {
            PatientXraydto result = _patientService.GetXrays(email);

            return Ok(result);
        }


        [HttpGet("GetTests/{email}")]
        public IActionResult GetTests(string email)
        {
            PatientTestdto result = _patientService.GetTests(email);

            return Ok(result);
        }

      /*  [HttpGet("GetExaminations/{email}")]
        public IActionResult GetExaminations(string email)
        {
            PatientTestdto result = _patientService.GetExaminations(email);

            return Ok(result);
        }*/



        [HttpPost("FeedBack")]
        public IActionResult FeedBack(FeedBacks feedBack)
        {
            string result = _patientService.FeedBack(feedBack);

            return Ok(result);
        }



    }
}
