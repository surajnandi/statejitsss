using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using statejitsss.BAL.Interfaces;
using statejitsss.DAL.Entities;
using statejitsss.Helpers;

namespace statejitsss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpPost("GetAllDdos")]
        public async Task<ActionResult<ServiceResponse<PagedResult<MmGenDdo>>>> GetAllDdos([FromBody] DapperQueryParameter parameters)
        {
            parameters ??= new DapperQueryParameter();
            var result = await _masterService.GetAllDdos(parameters);
            return Ok(result);
        }

        [HttpGet("GetDdoDetails")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<MmGenDdo>>>> GetDdoDetails()
        {
            var result = await _masterService.GetDdoDetails();
            return result;
        }
    }
}
