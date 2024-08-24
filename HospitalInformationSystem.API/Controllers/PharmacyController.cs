using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController: ControllerBase
    {
        readonly PharmacyService _pharmacyService;
        public static HistoryService _historyService;
        public static ApplicationDbContext _context;


        public PharmacyController(PharmacyService pharmacyService, HistoryService historyService, ApplicationDbContext context)
        {

            _pharmacyService = pharmacyService;
            _historyService = historyService;
            _context = context;
        }

        [HttpGet("GetPatientMedication")]
        public IActionResult GetPatientMedication(string Id, string date)
        {
            if (DateOnly.TryParse(date, out DateOnly parsedDate))
            {
                HistoryDTO history = _pharmacyService.GetPatientMedication(Id, parsedDate);
                return Ok(history);
            }
            return BadRequest("Invalid date format.");
        }


        /* [HttpGet("GetPatientMedication")]
         public IActionResult GetPatientMedication(string Id,string date)
         {
             if (DateOnly.TryParse(date, out DateOnly parsedDate))
             {
                 HistoryDTO history = _pharmacyService.GetPatientMedication(Id, parsedDate);
                 return Ok(history);
             }
             return BadRequest("Invalid date format.");
         }*/
    }
}
