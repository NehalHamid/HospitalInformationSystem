using Microsoft.AspNetCore.Mvc;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.Services;

using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Data;
using Med = HospitalInformationSystem.Models.Models.Med;



namespace HospitalInformationSystem.API.Controllers
{
    //    [Authorize(Roles = "Admin")]
    //لو اتحطت هنا فا كل الاكشنز مش هتتنفذ الا لو كان ادمن
    
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;
        public static HistoryService _historyService;
        public static ApplicationDbContext _context;



        public DoctorController(DoctorService doctorService, HistoryService historyService, ApplicationDbContext context)
        {

            _doctorService = doctorService;
            _historyService = historyService;
            _context= context;
        }



        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors =  _doctorService.GetAll();
            return Ok(doctors);

        }





        [HttpGet("specialization")]
        public async Task<IActionResult> SearchBySpecialization([FromBody] string specialization)
        {
            var doctors = _doctorService.SearchBySpecialization(specialization);
            return Ok(doctors);
        }



        //[Authorize(Roles = "Doctor")]
        [HttpGet("ShowProfile")]
        public async Task<IActionResult> ShowProfile(string type,string ID)
        {
            DoctorDTO doctor = _doctorService.ShowProfile(type, ID);
            if (doctor != null)
            {
                return Ok(doctor);

            }
            else
            {
                DoctorDTO resultBad = new();
                return Unauthorized(resultBad);
            }

        }


        //[Authorize(Roles = "Doctor")]
        [HttpGet("Recheck/{nid}")]
        public IActionResult Recheck( string nid)
        {
            PatientHistoryDTO history = _doctorService.Recheck(nid);
            if (history != null)
            {
                return Ok(history);

            }
            else
            {
                PatientHistoryDTO resultBad =new();
                return Unauthorized(resultBad);
            }

        }

        //[Authorize(Roles = "Doctor")]
        [HttpPost("Diagnosis")]
        //public async Task<IActionResult> Diagnosis(string patientId, string doctorId, string diagnosis,string medicine)
        public async Task<IActionResult> Diagnosis([FromBody] Med data)
        {
            string patientId =data.NID;
            string DoctorName = data.Doctorname;
            string diagnosis =data.Diagnosis;
            string medicine =data.Medicine;

            string result = await _doctorService.Diagnosis(patientId, DoctorName, diagnosis, medicine);
            if (result == "Diagnosis has been written successfully")
            {
                return Ok(result);

            }
            else
            {
                return Unauthorized(result);
            }


        }


        //[Authorize(Roles = "Doctor")]
        [HttpGet("GetHospitals")]
        public IActionResult GetHospitals()
        {
            List<string> result =  DoctorService.GetHospitals();

            return Ok(result);
        }
        
        //[Authorize(Roles = "Doctor")]
        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments()
        {
            List<string> result =  DoctorService.GetDepartments();

            return Ok(result);
        } 

        [HttpPost("Transfer")]
        public IActionResult PostTransfer([FromBody] TransferDTO Transfer)
        {
            string result=DoctorService.PostTransfer(Transfer);
            if(result == "Transferred Successfully")
            {
                return Ok(result);

            }
            else
            {
                return Unauthorized(result);
            }

        }



        //[Authorize(Roles = "Doctor")]
        [HttpGet("GetXRays")]
        public IActionResult GetXRays()
        {
            List<string> result = _doctorService.GetXRays();

            return Ok(result);
        }

        //[Authorize(Roles = "Doctor")]
        [HttpGet("GetTests")]
        public IActionResult GetTests()
        {
            List<string> result = _doctorService.GetTests();

            return Ok(result);
        }


        //[Authorize(Roles = "Doctor")]
        [HttpPost("AskForXRays")]
        public IActionResult AskForXRays(Request request)
        {
            string result = _doctorService.AskForX_Rays(request);
            if (result == "Requested Successfully")
            {
                return Ok(result);

            }
            else
            {
                return Unauthorized(result);
            }
        }


         //[Authorize(Roles = "Doctor")]
        [HttpPost("AskForTests")]
        public IActionResult AskForTests(Request request)
        {
            string result = _doctorService.AskForTests(request);
            if (result == "Requested Successfully")
            {
                return Ok(result);

            }
            else
            {
                return Unauthorized(result);
            }
        }


        //[Authorize(Roles = "Doctor")]
        [HttpPost("WriteMedications")]
        public async Task<IActionResult> WriteMedications(string patientId, string doctorId, string type, List<string> medicines)
        {
            string result =  _doctorService.WriteMedications(patientId, doctorId, type, medicines);
            if (result == "Medicines has been written successfully")
            {
                return Ok(result);

            }
            else
            {
                return Unauthorized(result);
            }


        }

    }


}
