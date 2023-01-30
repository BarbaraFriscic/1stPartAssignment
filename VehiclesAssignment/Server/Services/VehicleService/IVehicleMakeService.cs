namespace VehiclesAssignment.Server.Services.VehicleService
{
    public interface IVehicleMakeService
    {
        Task<ServiceResponse<List<VehicleMake>>> GetVehicleMakesAsync();

        Task<ServiceResponse<List<VehicleMake>>> GetVehicleMakeAsync(int vehicleMakeId);

        Task<ServiceResponse<List<VehicleMake>>> Create(VehicleMake newVehicleMake);

        Task<ServiceResponse<VehicleMake>> UpdateVehicleMake(int id, VehicleMake updateVehicleMake);

        Task<ServiceResponse<List<VehicleMake>>> DeleteVehicleMake(int id);
    }
}
