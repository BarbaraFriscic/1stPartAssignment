using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace VehiclesAssignment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleMake>>> GetVehicleMakes()
        {
            var result = await _vehicleMakeService.GetVehicleMakesAsync();
            return Ok(result);
        }

        [HttpGet("{vehicleMakeId}")]
        public async Task<ActionResult<VehicleMake>> GetVehicleMake(int vehicleMakeId)
        {
            var result = await _vehicleMakeService.GetVehicleMakeAsync(vehicleMakeId);
            if (result == null)
                return NotFound("No Vehicle Make here."); 
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<VehicleMake>>> Create(VehicleMake newVehicleMake)
        {
            var result = await _vehicleMakeService.Create(newVehicleMake);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<VehicleMake>>> UpdateVehicleMake(int id, VehicleMake updateVehicleMake)
        {
            var result = await _vehicleMakeService.UpdateVehicleMake(id, updateVehicleMake);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<VehicleMake>>> DeleteVehicleMake(int id)
        {
            var result = await _vehicleMakeService.DeleteVehicleMake(id);
            return Ok(result);
        }

    }
}
