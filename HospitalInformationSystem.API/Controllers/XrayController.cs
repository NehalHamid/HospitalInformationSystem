using HospitalInformationSystem.Data;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XrayController:ControllerBase
    {
        private readonly XRayService _xRayService;
        public static ApplicationDbContext _context;

        public XrayController(XRayService xRayService, ApplicationDbContext context)
        {
            _xRayService = xRayService;
            _context= context;
        }

        [HttpGet("ShowAllXRays")]
        public IActionResult ShowXRays()
        {
            List<Requests> result = _xRayService.ShowXRays();

            return Ok(result);


        }


        [HttpPost("UploadXRay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UploadXRay(string patientId, string doctorId, string type, IFormFile file, CancellationToken cancellationToken)
        public async Task<IActionResult> UploadXRay([FromForm] XRay ray, CancellationToken cancellationToken)
        {
            var patient = _context.Patient.FirstOrDefault(x => x.NationalId == ray.NID);
            string patientId = patient.NationalId;
            var result = await _xRayService.WriteFile(HttpContext, ray);
            if (result != "Unauthorized")
            {
                return Ok(result);

            }
            else
            {
                return Unauthorized("Unauthorized");
            }
        }


    }
}
