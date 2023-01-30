using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VehiclesAssignment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService= vehicleModelService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<VehicleModel>>>> GetVehicleModels()
        {
            var result = await _vehicleModelService.GetVehicleModelsAsync();
            return Ok(result);
        }
        [HttpGet("{vehicleModelId}")]
        public async Task<ActionResult<ServiceResponse<VehicleModel>>> GetVehicleModel(int vehicleModelId)
        {
            var result = await _vehicleModelService.GetVehicleModelAsync(vehicleModelId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<VehicleModel>>>> Create(VehicleModel newVehicleModel)
        {
            var result = await _vehicleModelService.Create(newVehicleModel);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<VehicleModel>>>> UpdateVehicleModel(int id, VehicleModel updateVehicleModel)
        {
            var result = await _vehicleModelService.UpdateVehicleModel(id, updateVehicleModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<VehicleModel>>>> DeleteVehicleModel(int id)
        {
            var result = await _vehicleModelService.DeleteVehicleModel(id);
            return Ok(result);
        }
    }
}
