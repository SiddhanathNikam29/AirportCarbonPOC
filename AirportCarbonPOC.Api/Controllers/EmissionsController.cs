using AirportCarbonPOC.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static AirportCarbonPOC.Api.Models.Dtos;

namespace AirportCarbonPOC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmissionsController : ControllerBase
    {
        private readonly EmissionService _service;
        private readonly ILogger<EmissionsController> _logger;

        public EmissionsController(EmissionService service, ILogger<EmissionsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// GET /api/emissions/hotspot
        /// Returns current emission totals and identifies the single operational hotspot.
        /// </summary>
        [HttpGet("hotspot")]
        public IActionResult GetHotspot()
        {
            _logger.LogInformation("Hotspot requested");
            var result = _service.GetCurrentHotspot();
            return Ok(result);
        }

        /// <summary>
        /// POST /api/emissions/simulate
        /// Simulates an operational intervention and returns before/after comparison.
        /// </summary>
        [HttpPost("simulate")]
        public IActionResult Simulate([FromBody] SimulationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Strategy))
                return BadRequest(new { error = "Strategy is required." });

            try
            {
                _logger.LogInformation("Simulation requested: {Strategy}", request.Strategy);
                var result = _service.SimulateIntervention(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
