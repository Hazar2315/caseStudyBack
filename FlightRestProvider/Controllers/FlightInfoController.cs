using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Repositories.Abstract;

namespace FlightRestProvider.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightInfoController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightInfoController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost("GetFlightInfo")]
        public async Task<IActionResult> SearchFlight([FromBody] FlightSearchRequest value)
        {
            return Ok(await _flightService.SearchFlightAsync(value));
        }

        [HttpGet("GetFlightDetailById/{id}")]
        public async Task<IActionResult> GetFlightDetailById(int id)
        {
            return Ok(await _flightService.GetFlightDetailById(id));
        }
    }
}

