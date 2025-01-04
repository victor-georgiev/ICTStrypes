using ICTStrypes.Interfaces;
using ICTStrypes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICTStrypes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // POST: api/locations
        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] LocationRequestModel model)
        {
            try
            {
                var location = await _locationService.CreateLocationAsync(model);
                return CreatedAtAction(nameof(GetLocation), new { locationId = location.LocationId }, location);
            }
            catch(Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // PATCH: api/locations/{locationId}
        [HttpPatch("{locationId}")]
        public async Task<IActionResult> PatchLocation(string locationId, [FromBody] PatchLocationRequestModel model)
        {
            try
            {
                var updatedLocation = await _locationService.PatchLocationAsync(locationId, model);
                if (updatedLocation == null) return NotFound();
                return Ok(updatedLocation);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // GET: api/locations/{locationId}
        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetLocation(string locationId)
        {
            try
            {
                var location = await _locationService.GetLocationAsync(locationId);
                if (location == null) return NotFound();
                return Ok(location);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // PUT: api/locations/{locationId}
        [HttpPut("{locationId}")]
        public async Task<IActionResult> UpsertChargePoints(string locationId, [FromBody] ChargePointRequestModel model)
        {
            try
            {
                var result = await _locationService.UpsertChargePointsAsync(locationId, model);
                if (!result) return NotFound();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }

}
