namespace VehiclesAssignment.Server.Services.VehicleService
{
    public interface IVehicleMakeService
    {
        Task<List<VehicleMake>> GetVehicleMakesAsync();

        Task<VehicleMake> GetVehicleMakeAsync(int vehicleMakeId);

        Task<List<VehicleMake>> Create(VehicleMake newVehicleMake);

        Task<List<VehicleMake>> UpdateVehicleMake(int id, VehicleMake updateVehicleMake);

        Task<List<VehicleMake>> DeleteVehicleMake(int id);
    }
}
