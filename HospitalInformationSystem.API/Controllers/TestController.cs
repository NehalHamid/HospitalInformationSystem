using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.Services;
using Microsoft.AspNetCore.Mvc;
using NPOI.POIFS.Properties;
using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;


namespace HospitalInformationSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController:ControllerBase
    {
        private readonly TestService _testService;
        public static ApplicationDbContext _context;


        public TestController(TestService testService, ApplicationDbContext context)
        {
            _testService = testService;
            _context = context;
        }

        [HttpGet("ShowAllTests")]
        public IActionResult ShowTests()
        {
            List<Requests> result = _testService.ShowTests();

            return Ok(result);


        }

        /*
                [HttpPost("UploadTest")]
                [ProducesResponseType(StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                public async Task<IActionResult> UploadXRay([FromForm] Test test, CancellationToken cancellationToken)
                {
                    var patient = _context.Patient.FirstOrDefault(x => x.NationalId == test.NID);
                    string patientId = patient.NationalId;
                    var result = await _testService.WriteFile(HttpContext, test);
                    if (result != "Unauthorized")
                    {
                        return Ok(result);

                    }
                    else
                    {
                        return Unauthorized("Unauthorized");
                    }
                }*/

        [HttpPost("UploadTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadTest([FromForm] Test test, CancellationToken cancellationToken)
        {
            try
            {
                var patient = _context.Patient.FirstOrDefault(x => x.NationalId == test.NID);
                if (patient == null)
                {
                    return BadRequest("Patient not found");
                }

                string patientId = patient.NationalId;
                var result = await _testService.WriteFile(HttpContext, patientId, test);
                if (result != "Unauthorized")
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized("Unauthorized");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (assuming you have a logging mechanism set up)
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
