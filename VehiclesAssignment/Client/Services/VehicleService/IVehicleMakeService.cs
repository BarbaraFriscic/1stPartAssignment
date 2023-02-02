namespace VehiclesAssignment.Client.Services.VehicleService
{
    public interface IVehicleMakeService
    { 
        List<VehicleMake> VehicleMakes { get; set; }
        Task GetVehicleMakes();
        Task<VehicleMake> GetVehicleMake(int id);
        Task CreateVehicleMake(VehicleMake vehicleMake);
        Task UpdateVehicleMake(VehicleMake vehicleMake);
        Task DeleteVehicleMake(int id);
    }
}
