namespace VehiclesAssignment.Client.Services.VehicleService
{
    public interface IVehicleMakeService
    { 
        List<VehicleMake> VehicleMakes { get; set; }
        Task GetVehicleMakes();
    }
}
