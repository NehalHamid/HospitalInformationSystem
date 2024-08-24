using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ReceptionController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ReceptionService _receptionService;
        public ReceptionController(IAuthService authService, ReceptionService receptionService)
        {
            _authService = authService;
            _receptionService = receptionService;
        }

        //[Authorize(Policy = "ReceptionPolicy")]
        [HttpPost("CreateAccount")] 
        public IActionResult CreateAccount( [FromBody] Patientdto model)
        {

            var result =  _receptionService.CreateAccount(model);

            if (result != "Successfully Added")
                return BadRequest(result);

            return Ok(result);
        }
        
        
        //[Authorize(Policy = "ReceptionPolicy")]
        [HttpPost("ReserveOperationRoom")] 
        public IActionResult ReserveOperationRoom( [FromBody] OperationRoom model)
        {

            var result =  _receptionService.ReserveOperationRoom(model);

            if (result != "Successfully reserved")
                return BadRequest(result);

            return Ok(result);
        }

        //[Authorize(Policy = "ReceptionPolicy")]
        [HttpPost("ReserveNormalRoom")]
        public IActionResult ReserveNormalRoom([FromBody] NormalRoom model)
        {

            var result = _receptionService.ReserveNormalRoom(model);

            if (result != "Successfully reserved")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("ReturnPrices/{nid}")]
        public IActionResult ReturnPrices(string nid)
        {

            var result = _receptionService.ReturnPrices(nid);

            if (result == null )
                return BadRequest(result);

            return Ok(result);
        }

    }
}
 