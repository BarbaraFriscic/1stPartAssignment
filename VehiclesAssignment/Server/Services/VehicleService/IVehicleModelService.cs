namespace VehiclesAssignment.Server.Services.VehicleService
{
    public interface IVehicleModelService
    {
        Task<ServiceResponse<List<VehicleModel>>> GetVehicleModelsAsync();

        Task<ServiceResponse<VehicleModel>> GetVehicleModelAsync(int vehicleModelId);

        Task<ServiceResponse<List<VehicleModel>>> Create(VehicleModel newVehicleModel);

        Task<ServiceResponse<VehicleModel>> UpdateVehicleModel(int id, VehicleModel updateVehicleModel);

        Task<ServiceResponse<List<VehicleModel>>> DeleteVehicleModel(int id);
    }
}
