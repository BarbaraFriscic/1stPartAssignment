namespace VehiclesAssignment.Client.Services.VehicleService
{
    public interface IVehicleModelService
    {
        List<VehicleModel> VehicleModels { get; set; }
        Task GetVehicleModels();
    }
}
